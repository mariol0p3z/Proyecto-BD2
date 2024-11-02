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
using System.Security.Cryptography;

namespace Proyecto_CineGT
{
    public partial class RegistroUser : Form
    {
        public RegistroUser()
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

        private void btnRegistro_Click(object sender, EventArgs e)
        {
            try
            {
                string cnn = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
                using(SqlConnection conexion = new SqlConnection(cnn))
                {
                    conexion.Open();
                    if(txtPassword.Text == txtConfirmarPass.Text)
                    {
                        using(SqlCommand cmd = new SqlCommand("sp_insertar_usuario", conexion))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            byte[] passwordhashed = CifrarSha256(txtPassword.Text);
                            cmd.Parameters.AddWithValue("@primerNombre", txtPrimerNombre.Text);
                            cmd.Parameters.AddWithValue("@segundoNombre", txtSegundoNombre.Text);
                            cmd.Parameters.AddWithValue("@primerApellido", txtPrimerApellido.Text);
                            cmd.Parameters.AddWithValue("@segundoApellido", txtSegundoApellido.Text);
                            cmd.Parameters.AddWithValue("@usuario", txtUsuario.Text);
                            cmd.Parameters.AddWithValue("@rol", 0);
                            cmd.Parameters.AddWithValue("@contraseña", passwordhashed);
                            
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Usuario Agregado Exitosamente");
                            txtPrimerNombre.Clear();
                            txtSegundoNombre.Clear();
                            txtPrimerApellido.Clear();
                            txtSegundoApellido.Clear();
                            txtUsuario.Clear();
                            txtPassword.Clear();
                            txtConfirmarPass.Clear();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Las contraseñas no son identicas", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            CineGT inicio = new CineGT();
            inicio.Show();
            this.Close();
        }

        private void RegistroUser_Load(object sender, EventArgs e)
        {

        }
    }
}
