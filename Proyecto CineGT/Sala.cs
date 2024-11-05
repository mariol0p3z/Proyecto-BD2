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
    public partial class Sala : Form
    {
        private int usuarioId;
        public Sala(int usuarioId)
        {
            InitializeComponent();
            this.Load += Sala_Load; // Asocia el evento Load con el método Sala_Load
            this.usuarioId = usuarioId;
        }
        //genera tablero 
        private void Sala_Load(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Tu lógica para el evento CellContentClick, si la necesitas
        }

        private void Sala_Load_1(object sender, EventArgs e)
        {

        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            PreVenta preventa = new PreVenta(usuarioId);
            preventa.Show();
            this.Close();
        }
    }
}

