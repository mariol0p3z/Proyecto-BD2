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
    public partial class MenuAdmin : Form
    {
        public MenuAdmin()
        {
            InitializeComponent();
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            CineGT cine = new CineGT();
            cine.Show();
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            VerPeliculas verpeliculas = new VerPeliculas();
            verpeliculas.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PreVenta preVenta = new PreVenta();
            preVenta.Show();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            RegistroPeliculas rp = new RegistroPeliculas();
            rp.Show();
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }
    }
}
