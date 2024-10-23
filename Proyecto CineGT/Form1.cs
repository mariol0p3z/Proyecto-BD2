using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace Proyecto_CineGT
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnIncioSesion_Click(object sender, EventArgs e)
        {

            try
            {
                string cnn = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
                using (SqlConnection conexion = new SqlConnection(cnn))
                {
                    conexion.Open();
                    using (SqlCommand cmd = new SqlCommand("SELECT usuarioNombre, contraseña from usuario WHERE usuarioNombre = '" + txtUsuario.Text + "' AND contraseña = '" + txtPassword.Text + "'", conexion))
                    {
                        SqlDataReader lector = cmd.ExecuteReader();
                        if (lector.Read())
                        {
                            MessageBox.Show("Bienvenido " + txtUsuario.Text, "Login Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            MenuUser user = new MenuUser();
                            user.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Usuario y/o Contraseña Incorrectos", "Error");
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }
    }
}
