using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace Proyecto_CineGT
{

    public partial class RegistroPeliculas : Form
    {
        private int usuarioId;
        private string rol;
        public RegistroPeliculas(int usuarioId, string rol)
        {
            InitializeComponent();
            this.usuarioId = usuarioId;
            this.rol = rol;
        }

        private void btnRegistro_Click(object sender, EventArgs e)
        {
            try
            {
                string cnn = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
                using (SqlConnection conexion = new SqlConnection(cnn))
                {
                    conexion.Open();
                    using (SqlCommand cmd = new SqlCommand("sp_insertar_pelicula", conexion))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Nombre", txtNombre.Text);
                        cmd.Parameters.AddWithValue("@Duracion", txtDuracion.Text);
                        cmd.Parameters.AddWithValue("@Descripcion", txtDescripcion.Text);
                        cmd.Parameters.AddWithValue("@Tclasificacion", txtClasificacion.SelectedItem.ToString());
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Pelicula Agregada Exitosamente");
                        txtNombre.Clear();
                        txtDuracion.Clear();
                        txtDescripcion.Clear();
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            if (rol == "admin")
            {
                MenuAdmin menuser = new MenuAdmin(usuarioId, rol);
                menuser.Show();
                this.Close();
            }
            else
            {
                MenuUser user = new MenuUser(usuarioId, rol);
                user.Show();
                this.Close();
            }
        }
    }
}
