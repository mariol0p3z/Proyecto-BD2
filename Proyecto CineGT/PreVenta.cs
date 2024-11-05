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
    public partial class PreVenta : Form
    {
        private int usuarioId;
        public PreVenta(int usuarioId)
        {
            InitializeComponent();
            this.usuarioId = usuarioId;
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            VerPeliculas vp = new VerPeliculas(usuarioId);
            vp.Show();
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Sala sala = new Sala(usuarioId);
            sala.Show();
            this.Close();
        }

        private void PreVenta_Load(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }
    }
}
