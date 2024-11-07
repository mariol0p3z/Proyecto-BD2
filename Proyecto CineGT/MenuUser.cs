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
        private string rol;
        public MenuUser(int usuarioId, string rol)
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
            CancelacionBoletos cancelarboletos = new CancelacionBoletos(usuarioId, rol);
            cancelarboletos.Show();
            this.Close();
        }


        private void button4_Click_1(object sender, EventArgs e)
        {
            VerPeliculas verpeliculas = new VerPeliculas(usuarioId, rol);
            verpeliculas.Show();
            this.Close();
        }
    }
}
