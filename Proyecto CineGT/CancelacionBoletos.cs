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
    public partial class CancelacionBoletos : Form
    {
        private int usuarioId;
        private string rol;
        public CancelacionBoletos(int usuarioId, string rol)
        {
            InitializeComponent();
            this.usuarioId = usuarioId;
            this.rol = rol;
            CargarReservas();
        }

        private void label1_Click(object sender, EventArgs e)
        {

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

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void CargarReservas()
        {
            string cnn = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(cnn))
            {
                using (SqlCommand command = new SqlCommand("sp_detalleReserva", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@usuario_id", usuarioId);

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();

                    try
                    {
                        connection.Open();
                        adapter.Fill(dataTable);
                        listaReservaUsuario.DataSource = dataTable;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al cargar las reservas: " + ex.Message);
                    }
                }
            }
        }
            private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                string cnn = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
                using (SqlConnection conexion = new SqlConnection(cnn))
                {
                    conexion.Open();
                    using (SqlCommand cmd = new SqlCommand("ups_eliminar_reserva", conexion))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@transaccion_id", txtTransaccion.Text);
                        cmd.Parameters.AddWithValue("@usuario_id", txtUsuario.Text);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Anulacion de Transaccion realizada exitosamente");
                        txtUsuario.Clear();
                        txtTransaccion.Clear();
                        CargarReservas();
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void listaReservaUsuario_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = listaReservaUsuario.Rows[e.RowIndex];
                txtUsuario.Text = row.Cells["usuario_id"].Value.ToString();
                txtTransaccion.Text = row.Cells["transaccion_id"].Value.ToString();
            }
        }
    }
}
