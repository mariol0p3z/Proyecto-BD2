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
        private int usuarioId;

        public MenuAdmin(int usuarioId)
        {
            InitializeComponent();
            this.usuarioId = usuarioId; 
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            CineGT cine = new CineGT();
            cine.Show();
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            VerPeliculas verpeliculas = new VerPeliculas(usuarioId);
            verpeliculas.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*PreVenta preVenta = new PreVenta(usuarioId);
            preVenta.Show();
            this.Close();*/
        }

        private void button4_Click(object sender, EventArgs e)
        {
            RegistroPeliculas rp = new RegistroPeliculas(usuarioId);
            rp.Show();
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            Reportes rep = new Reportes();
            rep.Show();
            this.Close();
        }
    }
}
