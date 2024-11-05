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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Proyecto_CineGT
{
    public partial class PreVenta : Form
    {
        private int usuarioId;
        private int sesionId;

        public PreVenta(int usuarioId, int sesionId)
        {
            InitializeComponent();
            this.usuarioId = usuarioId;
            this.sesionId = sesionId;
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            VerPeliculas vp = new VerPeliculas(usuarioId);
            vp.Show();
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            // Validar que txtCantidad no esté vacío y contenga un número entero
            if (string.IsNullOrWhiteSpace(txtCantidad.Text) || !int.TryParse(txtCantidad.Text, out int cantidad))
            {
                MessageBox.Show("Por favor, ingresa una cantidad válida de asientos.");
                return;
            }

            // Validar que se haya seleccionado una opción en comboBox
            if (cmbAsignar.SelectedItem == null)
            {
                MessageBox.Show("Por favor, selecciona un modo (Automático o Manual).");
                return;
            }

            // Obtener el modo seleccionado en el ComboBox
            string modo = cmbAsignar.SelectedItem.ToString();

            // Crear y abrir el formulario Sala con los parámetros
            Sala sala = new Sala(usuarioId, sesionId, cantidad, modo);
            sala.Show();
            this.Close();
        }

        private void PreVenta_Load(object sender, EventArgs e)
        {
            CargarDatosSesion();
            cmbAsignar.Items.Clear();

            cmbAsignar.Items.Add("Automático");
            cmbAsignar.Items.Add("Manual");
            cmbAsignar.SelectedIndex = 0;
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void CargarDatosSesion()
        {
            try
            {
                string cnn = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
                using (SqlConnection conexion = new SqlConnection(cnn))
                {
                    conexion.Open();
                    // Consulta para obtener el nombre de la película y el horario de inicio basados en el sesionId
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
                                txtPelicula.Text = reader["nombre"].ToString();
                                txtHorarioI.Text = reader["fechaInicio"].ToString();
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
    }
}
