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
using System.Security.Cryptography;

namespace Proyecto_CineGT
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private byte[] CifrarSha256(string input)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                return sha256.ComputeHash(Encoding.Unicode.GetBytes(input));
            }
        }

        private void btnIncioSesion_Click(object sender, EventArgs e)
        {

            try
            {
                string cnn = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
                using (SqlConnection conexion = new SqlConnection(cnn))
                {
                    conexion.Open();
                    using (SqlCommand cmd = new SqlCommand("sp_login", conexion))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        byte[] passwordhashed = CifrarSha256(txtPassword.Text);
                        cmd.Parameters.AddWithValue("@usuario", txtUsuario.Text);
                        cmd.Parameters.AddWithValue("@password", passwordhashed);
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

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RegistroUser registro = new RegistroUser();
            registro.Show();
            this.Hide();
        }
    }
}
