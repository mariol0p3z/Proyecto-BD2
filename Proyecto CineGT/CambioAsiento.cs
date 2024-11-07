using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Proyecto_CineGT.EdicionBoletos;
using static Proyecto_CineGT.NuevasSesiones;

namespace Proyecto_CineGT
{
    public partial class CambioAsiento : Form
    {
        private DetallesCambioAsientos detallesCambio;

        public CambioAsiento(DetallesCambioAsientos detalles)
        {
            InitializeComponent();
            detallesCambio = detalles;

            // Mostrar detalles de la sesión original
            MostrarDetallesSesionOriginal();

            // Cargar sesiones disponibles
            CargarSesionesDisponibles();
        }

        private void MostrarDetallesSesionOriginal()
        {
            lblPelicula.Text = detallesCambio.PeliculaID.ToString(); // O mostrar el nombre de la película
            lblSala.Text = detallesCambio.SalaID.ToString(); // O el nombre de la sala
            lblFechaSesion.Text = detallesCambio.FechaSesion.ToString("dd/MM/yyyy HH:mm");
        }

        private void CargarSesionesDisponibles()
        {
            var sesionesDisponibles = ObtenerSesionesFuturas();
            comboBoxSesiones.Items.Clear();
            foreach (var sesion in sesionesDisponibles)
            {
                comboBoxSesiones.Items.Add(sesion); // Aquí se agrega la sesión al ComboBox
            }
        }

        private List<Sesion> ObtenerSesionesFuturas()
        {
            List<Sesion> sesionesFuturas = new List<Sesion>();

            // Conectar a la base de datos usando la cadena de conexión desde el archivo de configuración
            string conn = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(conn))
            {
                // Consulta SQL para obtener las sesiones futuras (donde fechaInicio es mayor que la fecha actual)
                string query = @"
            SELECT sesion_id, pelicula_id, sala_id, fechaInicio, fechaFin
            FROM sesion
            WHERE fechaInicio > @FechaActual"; // Filtra las sesiones cuya fechaInicio sea posterior a la fecha actual

                // Crear un comando SQL
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Añadir el parámetro para la fecha actual
                    command.Parameters.AddWithValue("@FechaActual", DateTime.Now);

                    // Abrir la conexión
                    connection.Open();

                    // Ejecutar la consulta
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Crear una nueva instancia de la clase Sesion
                            Sesion sesion = new Sesion
                            {
                                SesionID = reader.GetInt32(0),
                                PeliculaID = reader.GetInt32(1),
                                SalaID = reader.GetInt32(2),
                                FechaInicio = reader.GetDateTime(3),
                                FechaFin = reader.GetDateTime(4)
                            };

                            // Añadir la sesión a la lista
                            sesionesFuturas.Add(sesion);
                        }
                    }
                }
            }

            return sesionesFuturas; // Devuelve la lista de sesiones futuras
        }

        public class Sesion
        {
            public int SesionID { get; set; }
            public int PeliculaID { get; set; }
            public int SalaID { get; set; }
            public DateTime FechaInicio { get; set; }
            public DateTime FechaFin { get; set; }
        }

        private void CambiarAsientos(List<Tuple<string, int>> asientosNuevos,
                                     int sesionIDOriginal,
                                     int sesionIDNueva,
                                     int usuarioID,
                                     int transaccionID)
        {
            string conn = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(conn))
            {
                connection.Open();

                // Comienza una transacción para garantizar la atomicidad
                using (SqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        foreach (var asiento in asientosNuevos)
                        {
                            // Verificar si el asiento ya está reservado en la nueva sesión
                            string checkQuery = @"
                        SELECT COUNT(*) 
                        FROM reserva 
                        WHERE id_asiento = @AsientoNumero 
                        AND sesion_id = @SesionIDNueva";

                            using (SqlCommand checkCommand = new SqlCommand(checkQuery, connection, transaction))
                            {
                                checkCommand.Parameters.AddWithValue("@AsientoNumero", asiento.Item2);
                                checkCommand.Parameters.AddWithValue("@SesionIDNueva", sesionIDNueva);

                                int asientoReservado = (int)checkCommand.ExecuteScalar();

                                // Si el asiento ya está reservado en la nueva sesión, mostrar un mensaje y cancelar
                                if (asientoReservado > 0)
                                {
                                    MessageBox.Show($"El asiento {asiento.Item1}{asiento.Item2} ya está reservado en la nueva sesión.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return;
                                }
                            }

                            // Si el asiento está reservado en la sesión original, eliminar la reserva anterior
                            string deleteQuery = @"
                        DELETE FROM reserva 
                        WHERE id_asiento = @AsientoNumero 
                        AND sesion_id = @SesionIDOriginal
                        AND usuario_id = @UsuarioID";

                            using (SqlCommand deleteCommand = new SqlCommand(deleteQuery, connection, transaction))
                            {
                                deleteCommand.Parameters.AddWithValue("@AsientoNumero", asiento.Item2);
                                deleteCommand.Parameters.AddWithValue("@SesionIDOriginal", sesionIDOriginal);
                                deleteCommand.Parameters.AddWithValue("@UsuarioID", usuarioID);

                                deleteCommand.ExecuteNonQuery();
                            }

                            // Insertar el nuevo asiento en la reserva de la nueva sesión
                            string insertQuery = @"
                        INSERT INTO reserva (usuario_id, sesion_id, transaccion_id, id_asiento) 
                        VALUES (@UsuarioID, @SesionIDNueva, @TransaccionID, @AsientoNumero)";

                            using (SqlCommand insertCommand = new SqlCommand(insertQuery, connection, transaction))
                            {
                                insertCommand.Parameters.AddWithValue("@UsuarioID", usuarioID);
                                insertCommand.Parameters.AddWithValue("@SesionIDNueva", sesionIDNueva);
                                insertCommand.Parameters.AddWithValue("@TransaccionID", transaccionID);
                                insertCommand.Parameters.AddWithValue("@AsientoNumero", asiento.Item2);

                                insertCommand.ExecuteNonQuery();
                            }
                        }

                        // Si todo va bien, confirmar la transacción
                        transaction.Commit();
                        MessageBox.Show("Los asientos han sido cambiados correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        // Si algo falla, revertir la transacción
                        transaction.Rollback();
                        MessageBox.Show($"Error al cambiar los asientos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnConfirmarCambio_Click_1(object sender, EventArgs e)
        {
           
        }
    }
}
