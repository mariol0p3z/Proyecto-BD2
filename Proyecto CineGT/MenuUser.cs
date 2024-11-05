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
    public partial class MenuUser : Form
    {
        private int usuarioId;
        public MenuUser(int usuarioId)
        {
            InitializeComponent();
            this.usuarioId = usuarioId;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RegistroPeliculas pelicula = new RegistroPeliculas(usuarioId);
            pelicula.Show();
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            CineGT cine = new CineGT();
            cine.Show();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            PreVenta preventa = new PreVenta(usuarioId);
            preventa.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            VerPeliculas verpeliculas = new VerPeliculas(usuarioId);
            verpeliculas.Show();
            this.Close();
        }

        private void MenuUser_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            EdicionBoletos edicionboletos = new EdicionBoletos();
            edicionboletos.Show();
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            CancelacionBoletos cancelarboletos = new CancelacionBoletos(usuarioId);
            cancelarboletos.Show();
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Reportes historial = new Reportes();
            historial.Show();
            this.Close();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            VerPeliculas verpeliculas = new VerPeliculas(usuarioId);
            verpeliculas.Show();
            this.Close();
        }
    }
}
