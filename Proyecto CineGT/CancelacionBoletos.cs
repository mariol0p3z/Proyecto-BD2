using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
    }
}
