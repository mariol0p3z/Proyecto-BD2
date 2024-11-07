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

namespace Proyecto_CineGT
{
    public partial class Sala : Form
    {
        private int usuarioId;
        private int sesionId;
        private int cantidad;
        private string modo;
        private int seleccionados = 0; // Contador de asientos seleccionados

        public Sala(int usuarioId, int sesionId, int cantidad, string modo)
        {
            InitializeComponent();
            this.Load += Sala_Load; // Asocia el evento Load con el método Sala_Load
            this.usuarioId = usuarioId;
            this.sesionId = sesionId;
            this.cantidad = cantidad;
            this.modo = modo;
        }
        //genera tablero 
        private void Sala_Load(object sender, EventArgs e)
        {
            // Consultar asientos reservados y marcarlos en azul marino
            MarcarAsientosReservados();

            // Cargar los datos de la sesión y mostrar en los campos correspondientes
            CargarDatosSesion();

            // Mostrar la cantidad en txtCantidad y el modo en lblModo
            txtCantMax.Text = cantidad.ToString();
            lblModo.Text = modo == "Automático" ? "MODO AUTOMÁTICO" : "MODO MANUAL";

            // En modo automático, seleccionar asientos automáticamente
            if (modo == "Automático")
            {
                SeleccionarAsientosAutomaticamente();
            }
            else
            {
                // En modo manual, agregar el evento Click a los botones de asientos
                foreach (Button Asiento in this.Controls.OfType<Button>().Where(b => b.Tag?.ToString() == "Asiento"))
                {
                    Asiento.Click -= Asiento_Click; // Detach any existing handlers
                    Asiento.Click += Asiento_Click; // Attach the handler once
                }
            }
        }

        private void MarcarAsientosReservados()
        {
            try
            {
                string cnn = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
                using (SqlConnection conexion = new SqlConnection(cnn))
                {
                    conexion.Open();

                    // Obtener el salaId asociado al sesionId
                    int salaId;
                    string querySala = "SELECT sala_id FROM sesion WHERE sesion_id = @sesionId";
                    using (SqlCommand cmdSala = new SqlCommand(querySala, conexion))
                    {
                        cmdSala.Parameters.AddWithValue("@sesionId", sesionId);
                        salaId = (int)cmdSala.ExecuteScalar();
                    }

                    // Consultar los asientos reservados para el salaId y sesionId especificados
                    string queryAsientos = "SELECT a.fila, a.numero FROM reserva r " +
                                            "INNER JOIN asiento a ON r.id_asiento = a.id_asiento " +
                                            "WHERE r.sesion_id = @sesionId AND a.sala_id = @salaId";

                    using (SqlCommand cmdAsientos = new SqlCommand(queryAsientos, conexion))
                    {
                        cmdAsientos.Parameters.AddWithValue("@sesionId", sesionId);
                        cmdAsientos.Parameters.AddWithValue("@salaId", salaId);

                        using (SqlDataReader reader = cmdAsientos.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // Obtenemos la fila y el número del asiento reservado
                                string fila = reader.GetString(0); // 'fila' es de tipo char(1)
                                int numero = reader.GetInt32(1);   // 'numero' es un int

                                // Convertimos fila + numero a la clave que usamos en los botones
                                string claveAsiento = fila + numero.ToString();

                                // Buscamos el botón cuyo .Text coincida con la clave del asiento
                                Button asientoBtn = ObtenerBotonAsientoPorClave(claveAsiento);
                                if (asientoBtn != null)
                                {
                                    asientoBtn.BackColor = Color.Navy;
                                    asientoBtn.Enabled = false; // Deshabilitar el asiento ya reservado
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los asientos reservados: " + ex.Message);
            }
        }

        // Método modificado para buscar el botón basado en la clave fila + numero
        private Button ObtenerBotonAsientoPorClave(string claveAsiento)
        {
            // Buscar el botón correspondiente al asiento usando fila+numero como clave en su .Text
            return this.Controls.OfType<Button>().FirstOrDefault(b => b.Text == claveAsiento);
        }

        private void SeleccionarAsientosAutomaticamente()
        {
            // Reinicia el contador de seleccionados
            seleccionados = 0;

            // Ordena los botones de asiento en función de la fila (letra) y luego por número
            var asientosOrdenados = this.Controls.OfType<Button>()
                                   .Where(b => b.Enabled && b.Tag?.ToString() == "Asiento")
                                   .OrderBy(b => b.Text[0])    // Ordena por la letra de la fila (primero A, luego B, etc.)
                                   .ThenBy(b => int.Parse(b.Text.Substring(1))); // Luego ordena por número en la fila

            // Selecciona los primeros "cantidad" asientos disponibles en el orden deseado
            foreach (Button Asiento in asientosOrdenados)
            {
                Asiento.BackColor = Color.LightGreen;
                seleccionados++;

                if (seleccionados >= cantidad)
                    break;
            }
        }

        private void CargarDatosSesion()
        {
            try
            {
                string cnn = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
                using (SqlConnection conexion = new SqlConnection(cnn))
                {
                    conexion.Open();

                    // Consulta para obtener el nombre de la película y el horario de inicio basado en el sesionId
                    string query = @"
                    SELECT p.nombre, s.fechaInicio
                    FROM sesion s
                    JOIN pelicula p ON s.pelicula_id = p.pelicula_id
                    WHERE s.sesion_id = @sesionId";

                    using (SqlCommand cmd = new SqlCommand(query, conexion))
                    {
                        cmd.Parameters.AddWithValue("@sesionId", sesionId);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Llenar los campos con los datos obtenidos
                                txtPelicula.Text = reader["nombre"].ToString();
                                txtHoraI.Text = reader["fechaInicio"].ToString();
                            }
                            else
                            {
                                MessageBox.Show("No se encontraron detalles para la sesión seleccionada.");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los detalles de la sesión: " + ex.Message);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Tu lógica para el evento CellContentClick, si la necesitas
        }

        private void Sala_Load_1(object sender, EventArgs e)
        {

        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            PreVenta preventa = new PreVenta(usuarioId, sesionId);
            preventa.Show();
            this.Close();
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            foreach (Button asiento in this.Controls.OfType<Button>().Where(b => b.BackColor == Color.LightGreen))
            {
                string asientoInfo = asiento.Text; // Ej: "A11"
                string fila = asientoInfo.Substring(0, 1);
                int numeroAsiento = int.Parse(asientoInfo.Substring(1));

                ReservarAsiento(fila, numeroAsiento);
            }

            MessageBox.Show("Asientos reservados exitosamente.");
            this.Close();
            CineGT cineGT = new CineGT();
            cineGT.Show();
        }

        private void ReservarAsiento(string fila, int numeroAsiento)
        {
            try
            {
                string cnn = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
                using (SqlConnection conexion = new SqlConnection(cnn))
                {
                    conexion.Open();
                    using (SqlCommand cmd = new SqlCommand("ups_reservar_asiento", conexion))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@usuario_id", usuarioId);
                        cmd.Parameters.AddWithValue("@sesion_id", sesionId);
                        cmd.Parameters.AddWithValue("@numero_asiento", numeroAsiento);
                        cmd.Parameters.AddWithValue("@fila", fila);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al reservar el asiento: " + ex.Message);
            }
        }

        private void Asiento_Click(object sender, EventArgs e)
        {
            if (seleccionados < cantidad)
            {
                Button asiento = (Button)sender;
                asiento.BackColor = Color.LightGreen;
                asiento.Enabled = false; // Deshabilitar el asiento para evitar selección doble
                seleccionados++;
            }
            else
            {
                MessageBox.Show("Ya has seleccionado la cantidad máxima de asientos.");
            }
        }

        private void btnResetSelection_Click(object sender, EventArgs e)
        {
            if (modo == "Manual")
            {
                foreach (Control control in this.Controls)
                {
                    if (control is Button asiento && asiento.BackColor == Color.LightGreen)
                    {
                        asiento.BackColor = SystemColors.Control;
                        asiento.Enabled = true;
                    }
                }

                seleccionados = 0;
                MessageBox.Show("Selección de asientos reiniciada. Puede volver a elegir los asientos.", "Selección reiniciada", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Error, no es posible resetear en modo Automático, únicamente en modo Manual", "Selección reiniciada", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}

