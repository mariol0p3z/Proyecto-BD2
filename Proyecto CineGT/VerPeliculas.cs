using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;

namespace Proyecto_CineGT
{
    public partial class VerPeliculas : Form
    {
        private int usuarioId;
        public VerPeliculas(int usuarioId)
        {
            InitializeComponent();
            // comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged; // Comentado o eliminado
            comboBox2.SelectedIndexChanged += comboBox2_SelectedIndexChanged;
            this.usuarioId = usuarioId;
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            //modificar para usuario y admin
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Validar que el usuario haya hecho una selección en ambos ComboBoxes
            if (comboBox2.SelectedValue == null || comboBox3.SelectedValue == null)
            {
                MessageBox.Show("Por favor, selecciona tanto el horario de inicio como la sala.");
                return;
            }

            // Obtener los valores seleccionados del ComboBox de horarios y de salas
            int sesionId = (int)comboBox2.SelectedValue; // ID de sesión basado en el horario de inicio
            int salaId = (int)comboBox3.SelectedValue;   // ID de sala

            // Conectar a la base de datos y verificar la combinación en la tabla sesión
            try
            {
                string cnn = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
                using (SqlConnection conexion = new SqlConnection(cnn))
                {
                    conexion.Open();

                    // Query para verificar si existe la combinación de sesion_id y sala_id
                    string query = @"
                SELECT COUNT(*)
                FROM sesion 
                WHERE sesion_id = @sesionId AND sala_id = @salaId AND pelicula_id = @peliculaId";

                    using (SqlCommand cmd = new SqlCommand(query, conexion))
                    {
                        // Parámetros para la consulta
                        cmd.Parameters.AddWithValue("@sesionId", sesionId);
                        cmd.Parameters.AddWithValue("@salaId", salaId);
                        cmd.Parameters.AddWithValue("@peliculaId", (int)comboBox1.SelectedValue);

                        // Ejecutar la consulta
                        int count = (int)cmd.ExecuteScalar();

                        if (count == 0)
                        {
                            MessageBox.Show("La combinación de horario de inicio y sala no es válida para esta película.");
                        }
                        else
                        {
                            // Si la combinación es válida, abrir la ventana de Preventa
                            PreVenta pv = new PreVenta(usuarioId, sesionId);
                            pv.Show();
                            this.Close();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al validar la combinación de horario y sala: " + ex.Message);
            }
        }

        private void VerPeliculas_Load_1(object sender, EventArgs e)
        {
            try
            {
                string cnn = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
                using (SqlConnection conexion = new SqlConnection(cnn))
                {
                    conexion.Open();
                    string query = "SELECT pelicula_id, nombre FROM pelicula";
                    using (SqlCommand cmd = new SqlCommand(query, conexion))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            DataTable dt = new DataTable();
                            dt.Load(reader);

                            comboBox1.DisplayMember = "nombre";
                            comboBox1.ValueMember = "pelicula_id";
                            comboBox1.DataSource = dt;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar las películas: " + ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedValue != null)
            {
                int peliculaId;
                if (int.TryParse(comboBox1.SelectedValue.ToString(), out peliculaId))
                {
                    // Limpiar datos previos
                    textBox2.Clear();
                    textBox3.Clear();
                    textBox4.Clear();
                    comboBox2.DataSource = null;
                    textBox1.Clear();
                    comboBox3.DataSource = null;

                    try
                    {
                        string cnn = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
                        using (SqlConnection conexion = new SqlConnection(cnn))
                        {
                            conexion.Open();

                            // Obtener duracion, descripcion y clasificacion_id de la película
                            string queryPelicula = "SELECT duracion, descripcion, clasificacion_id FROM pelicula WHERE pelicula_id = @peliculaId";
                            using (SqlCommand cmdPelicula = new SqlCommand(queryPelicula, conexion))
                            {
                                cmdPelicula.Parameters.AddWithValue("@peliculaId", peliculaId);

                                using (SqlDataReader reader = cmdPelicula.ExecuteReader())
                                {
                                    if (reader.Read())
                                    {
                                        textBox2.Text = reader["duracion"].ToString();
                                        textBox4.Text = reader["descripcion"].ToString();
                                        int clasificacionId = Convert.ToInt32(reader["clasificacion_id"]);

                                        // Obtener Tclasificacion de la tabla clasificacion
                                        reader.Close();

                                        string queryClasificacion = "SELECT Tclasificacion FROM clasificacion WHERE clasificacion_id = @clasificacionId";
                                        using (SqlCommand cmdClasificacion = new SqlCommand(queryClasificacion, conexion))
                                        {
                                            cmdClasificacion.Parameters.AddWithValue("@clasificacionId", clasificacionId);

                                            object Tclasificacion = cmdClasificacion.ExecuteScalar();
                                            textBox3.Text = Tclasificacion != null ? Tclasificacion.ToString() : "";
                                        }
                                    }
                                }
                            }

                            // Poblar comboBox2 con las fechas de inicio de sesiones de la película
                            string querySesiones = "SELECT sesion_id, fechaInicio FROM sesion WHERE pelicula_id = @peliculaId";
                            using (SqlCommand cmdSesiones = new SqlCommand(querySesiones, conexion))
                            {
                                cmdSesiones.Parameters.AddWithValue("@peliculaId", peliculaId);
                                using (SqlDataReader readerSesiones = cmdSesiones.ExecuteReader())
                                {
                                    DataTable dtSesiones = new DataTable();
                                    dtSesiones.Load(readerSesiones);

                                    // Formatear fechaInicio si es necesario
                                    foreach (DataRow row in dtSesiones.Rows)
                                    {
                                        DateTime fechaInicio = Convert.ToDateTime(row["fechaInicio"]);
                                        row["fechaInicio"] = fechaInicio.ToString("g");
                                    }

                                    comboBox2.DisplayMember = "fechaInicio";
                                    comboBox2.ValueMember = "sesion_id";
                                    comboBox2.DataSource = dtSesiones;
                                }
                            }

                            // Poblar comboBox3 con los nombres de las salas disponibles para la película
                            string querySalas = @"
                        SELECT DISTINCT s.sala_id, s.nombre 
                        FROM sala s 
                        INNER JOIN sesion se ON s.sala_id = se.sala_id 
                        WHERE se.pelicula_id = @peliculaId";
                            using (SqlCommand cmdSalas = new SqlCommand(querySalas, conexion))
                            {
                                cmdSalas.Parameters.AddWithValue("@peliculaId", peliculaId);
                                using (SqlDataReader readerSalas = cmdSalas.ExecuteReader())
                                {
                                    DataTable dtSalas = new DataTable();
                                    dtSalas.Load(readerSalas);

                                    comboBox3.DisplayMember = "nombre";
                                    comboBox3.ValueMember = "sala_id";
                                    comboBox3.DataSource = dtSalas;
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al cargar la información de la película: " + ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("ID de película no válido.");
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecciona una película.");
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedValue != null)
            {
                int sesionId;
                if (int.TryParse(comboBox2.SelectedValue.ToString(), out sesionId))
                {
                    try
                    {
                        string cnn = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
                        using (SqlConnection conexion = new SqlConnection(cnn))
                        {
                            conexion.Open();

                            string queryFechaFin = "SELECT fechaFin FROM sesion WHERE sesion_id = @sesionId";
                            using (SqlCommand cmdFechaFin = new SqlCommand(queryFechaFin, conexion))
                            {
                                cmdFechaFin.Parameters.AddWithValue("@sesionId", sesionId);

                                object fechaFin = cmdFechaFin.ExecuteScalar();
                                if (fechaFin != null)
                                {
                                    DateTime fechaFinValue = Convert.ToDateTime(fechaFin);
                                    textBox1.Text = fechaFinValue.ToString("g");
                                }
                                else
                                {
                                    textBox1.Clear();
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al obtener la fecha fin: " + ex.Message);
                    }
                }
                else
                {
                    textBox1.Clear();
                }
            }
            else
            {
                textBox1.Clear();
            }
        }

    }
}
