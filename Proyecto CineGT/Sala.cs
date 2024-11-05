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
            // Cargar los datos de la sesión y mostrar en los campos correspondientes
            CargarDatosSesion();

            // Mostrar la cantidad en txtCantidad y el modo en lblModo
            txtCantMax.Text = cantidad.ToString();
            lblModo.Text = modo == "Automático" ? "MODO AUTOMÁTICO" : "MODO MANUAL";
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
            //Comentado Temporal
            PreVenta preventa = new PreVenta(usuarioId, sesionId);
            preventa.Show();
            this.Close();
        }
    }
}

