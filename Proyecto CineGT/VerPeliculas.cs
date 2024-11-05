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
    public partial class VerPeliculas : Form
    {
        private int usuarioId;
        public VerPeliculas(int usuarioId)
        {
            InitializeComponent();
            this.usuarioId = usuarioId;
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            //modificar para usuario y admin
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PreVenta pv = new PreVenta(usuarioId);
            pv.Show();
            this.Close();
        }
    }
}
