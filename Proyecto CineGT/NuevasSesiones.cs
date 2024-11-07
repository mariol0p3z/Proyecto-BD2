using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Collections.Specialized.BitVector32;

namespace Proyecto_CineGT
{
    public partial class NuevasSesiones : Form
    {
        private int usuarioId;
        private string rol;
        public NuevasSesiones(int usuarioId, string rol)
        {
            InitializeComponent();
            this.usuarioId = usuarioId;
            cmbEstado.Items.Clear();
            cmbEstado.Items.Add("Activo");
            cmbEstado.Items.Add("Inactivo");
            this.rol = rol;
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            if (rol == "admin")
            {
                MenuAdmin ma = new MenuAdmin(usuarioId, rol);
                ma.Show();
                this.Close();
            }
            else
            {
                MenuUser user = new MenuUser(usuarioId, rol);
                user.Show();
                this.Close();
            }
        }

        private void btnLoadCSV_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "CSV files (*.csv)|*.csv",
                Title = "Seleccione el archivo CSV de sesiones"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string rutaArchivo = openFileDialog.FileName;

                DialogResult modoDialogo = MessageBox.Show(
                    "¿Desea crear solo las sesiones válidas (Sí) o anular toda la operación en caso de errores (No)?",
                    "Seleccionar Modo de Inserción",
                    MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Question
                );

                int modo;
                if (modoDialogo == DialogResult.Yes)
                {
                    modo = 1; // Solo insertar sesiones válidas
                }
                else if (modoDialogo == DialogResult.No)
                {
                    modo = 0; // Anular todo si hay errores
                }
                else
                {
                    MessageBox.Show("Operación cancelada.", "Cancelar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                CargarSesionesDesdeCSV(rutaArchivo, modo);
            }
        }

        private void CargarSesionesDesdeCSV(string rutaArchivo, int modo)
        {
            string cnn = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
            var sesionesValidas = new List<Sesion>();
            var sesionesInvalidas = new List<string>();

            try
            {
                using (var reader = new StreamReader(rutaArchivo))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        var datos = line.Split(',');

                        if (datos.Length < 4) continue; // Asegura que haya suficientes datos

                        var sesion = new Sesion
                        {
                            FechaInicio = DateTime.Parse(datos[0]),
                            Estado = int.Parse(datos[1]), // Ahora Estado es int (0 o 1)
                            PeliculaId = int.Parse(datos[2]),
                            SalaId = int.Parse(datos[3])
                        };

                        // Calcula fecha de fin
                        sesion.FechaFin = ObtenerFechaFin(cnn, sesion.FechaInicio, sesion.PeliculaId);

                        // Valida la sesión antes de insertarla
                        if (ValidarSesion(cnn, sesion))
                        {
                            sesionesValidas.Add(sesion);
                        }
                        else
                        {
                            sesionesInvalidas.Add(line);
                        }
                    }
                }

                if (sesionesInvalidas.Count > 0 && modo == 0)
                {
                    MessageBox.Show("Operación cancelada debido a conflictos en las sesiones.", "Conflictos detectados", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Inserta las sesiones válidas en la base de datos
                InsertarSesiones(cnn, sesionesValidas);

                MessageBox.Show($"Operación completada.\nSesiones válidas insertadas: {sesionesValidas.Count}\nSesiones rechazadas: {sesionesInvalidas.Count}",
                    "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al procesar el archivo CSV: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private DateTime ObtenerFechaFin(string cnn, DateTime fechaInicio, int peliculaId)
        {
            using (var connection = new SqlConnection(cnn))
            {
                connection.Open();
                using (var command = new SqlCommand("SELECT duracion FROM pelicula WHERE pelicula_id = @peliculaId", connection))
                {
                    command.Parameters.AddWithValue("@peliculaId", peliculaId);
                    var duracion = (int)command.ExecuteScalar();
                    return fechaInicio.AddMinutes(duracion);
                }
            }
        }

        private bool ValidarSesion(string cnn, Sesion sesion)
        {
            using (var connection = new SqlConnection(cnn))
            {
                connection.Open();
                using (var command = new SqlCommand(@"
                    SELECT COUNT(1) FROM sesion 
                    WHERE sala_id = @salaId
                    AND ((@fechaInicio < DATEADD(MINUTE, 15, fechaFin) AND @fechaFin > fechaInicio))", connection))
                {
                    command.Parameters.AddWithValue("@salaId", sesion.SalaId);
                    command.Parameters.AddWithValue("@fechaInicio", sesion.FechaInicio);
                    command.Parameters.AddWithValue("@fechaFin", sesion.FechaFin);

                    return (int)command.ExecuteScalar() == 0;
                }
            }
        }

        private void InsertarSesiones(string cnn, List<Sesion> sesiones)
        {
            using (var connection = new SqlConnection(cnn))
            {
                connection.Open();
                foreach (var sesion in sesiones)
                {
                    using (var command = new SqlCommand(@"
                        INSERT INTO sesion (fechaInicio, fechaFin, estado, pelicula_id, sala_id) 
                        VALUES (@fechaInicio, @fechaFin, @estado, @peliculaId, @salaId)", connection))
                    {
                        command.Parameters.AddWithValue("@fechaInicio", sesion.FechaInicio);
                        command.Parameters.AddWithValue("@fechaFin", sesion.FechaFin);
                        command.Parameters.AddWithValue("@estado", sesion.Estado); 
                        command.Parameters.AddWithValue("@peliculaId", sesion.PeliculaId);
                        command.Parameters.AddWithValue("@salaId", sesion.SalaId);
                        command.ExecuteNonQuery();
                    }
                }
            }
        }

        public class Sesion
        {
            public DateTime FechaInicio { get; set; }
            public int Estado { get; set; } 
            public int PeliculaId { get; set; }
            public int SalaId { get; set; }
            public DateTime FechaFin { get; set; }
        }

        private void btnCrearSesion_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtPelicula.Text) || !int.TryParse(txtPelicula.Text, out int peliculaId))
            {
                MessageBox.Show("Ingrese un ID de Película válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(txtSala.Text) || !int.TryParse(txtSala.Text, out int salaId))
            {
                MessageBox.Show("Ingrese un ID de Sala válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DateTime fechaInicio = dtpFechaInicio.Value;

            int estado = cmbEstado.SelectedItem?.ToString() == "Activo" ? 1 : 0;
            if (cmbEstado.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione un estado para la sesión.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            InsertarSesion(fechaInicio, estado, peliculaId, salaId);
        }

        private void InsertarSesion(DateTime fechaInicio, int estado, int peliculaId, int salaId)
        {
            string cnn = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(cnn))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("sp_InsertarSesion", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@fechaInicio", fechaInicio);
                    command.Parameters.AddWithValue("@estado", estado);
                    command.Parameters.AddWithValue("@peliculaId", peliculaId);
                    command.Parameters.AddWithValue("@salaId", salaId);

                    try
                    {
                        command.ExecuteNonQuery();
                        MessageBox.Show("Sesión creada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al crear la sesión: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
