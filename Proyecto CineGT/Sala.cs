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
        public Sala()
        {
            InitializeComponent();
            this.Load += Sala_Load; // Asocia el evento Load con el método Sala_Load
        }

        private void Sala_Load(object sender, EventArgs e)
        {
            // Limpia las columnas y filas actuales
            dataGridView1.Columns.Clear();
            dataGridView1.Rows.Clear();

            // Agrega 11 columnas con encabezados de 11 a 1
            for (int i = 11; i >= 1; i--)
            {
                DataGridViewTextBoxColumn column = new DataGridViewTextBoxColumn();
                column.HeaderText = i.ToString();
                column.Name = $"Column{i}";
                dataGridView1.Columns.Add(column);
            }

            // Agrega las filas con etiquetas de A a F
            string[] rowLabels = { "A", "B", "C", "D", "E", "F" };
            foreach (string label in rowLabels)
            {
                dataGridView1.Rows.Add();
                dataGridView1.Rows[dataGridView1.Rows.Count - 1].HeaderCell.Value = label;
            }

            // Habilita los encabezados de fila
            dataGridView1.RowHeadersVisible = true;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Tu lógica para el evento CellContentClick, si la necesitas
        }

        private void Sala_Load_1(object sender, EventArgs e)
        {

        }
    }
}

