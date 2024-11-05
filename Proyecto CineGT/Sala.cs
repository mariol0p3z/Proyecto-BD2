﻿using System;
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
                foreach (Button asiento in this.Controls.OfType<Button>().Where(b => b.Tag?.ToString() == "Asiento"))
                {
                    asiento.Click += Asiento_Click;
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
                    string query = "SELECT id_asiento FROM reserva WHERE sesion_id = @sesionId";

                    using (SqlCommand cmd = new SqlCommand(query, conexion))
                    {
                        cmd.Parameters.AddWithValue("@sesionId", sesionId);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int idAsiento = reader.GetInt32(0);
                                Button asientoBtn = ObtenerBotonAsientoPorId(idAsiento);
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

        private Button ObtenerBotonAsientoPorId(int idAsiento)
        {
            // Buscar el botón correspondiente al asiento en base al id (según tu lógica de mapeo)
            return this.Controls.OfType<Button>().FirstOrDefault(b => b.Name == "btnAsiento" + idAsiento);
        }

        private void SeleccionarAsientosAutomaticamente()
        {
            foreach (Button asiento in this.Controls.OfType<Button>().Where(b => b.Enabled && b.Tag?.ToString() == "Asiento"))
            {
                asiento.BackColor = Color.LightGreen;
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
    }
}

