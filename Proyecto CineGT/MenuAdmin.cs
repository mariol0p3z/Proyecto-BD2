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
        private string rol;

        public MenuAdmin(int usuarioId, string rol)
        {
            InitializeComponent();
            this.usuarioId = usuarioId;
            this.rol = rol;
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            CineGT cine = new CineGT();
            cine.Show();
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            VerPeliculas verpeliculas = new VerPeliculas(usuarioId, rol);
            verpeliculas.Show();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            RegistroPeliculas rp = new RegistroPeliculas(usuarioId, rol);
            rp.Show();
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            NuevasSesiones ns = new NuevasSesiones(usuarioId, rol);
            ns.Show();
            this.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Reportes rep = new Reportes();
            rep.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CancelacionBoletos cancelacion = new CancelacionBoletos(usuarioId, rol);
            cancelacion.Show();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            EdicionBoletos edicion = new EdicionBoletos();
            edicion.Show();
            this.Close();
        }
    }
}
