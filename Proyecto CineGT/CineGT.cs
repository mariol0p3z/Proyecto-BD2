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
    public partial class CineGT : Form
    {
        public CineGT()
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
                            int usuarioId = (int)lector["usuario_id"];
                            string rol = lector["rol"].ToString();
                            MessageBox.Show("Bienvenido " + txtUsuario.Text, "Login Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            if (rol == "admin")
                            {
                                MenuAdmin admin = new MenuAdmin(usuarioId);
                                admin.Show();
                            }
                            else
                            {
                                MenuUser user = new MenuUser(usuarioId);
                                user.Show();
                            }
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

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void CineGT_Load(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = true;
        }

        private void label4_Click(object sender, EventArgs e)
        {
            RegistroUser registro = new RegistroUser();
            registro.Show();
            this.Hide();
        }
    }
}
