using Microsoft.Reporting.WinForms;
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
    public partial class DetalleSala : Form
    {
        public DetalleSala()
        {
            InitializeComponent();
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            try
            {
                string opcion = comboBox1.SelectedItem.ToString();
                int id = 0;
                switch(opcion)
                {
                    case "Sala 1":
                        id = 1;
                        break;
                    case "Sala 2":
                        id = 2;
                        break;
                    case "Sala 3":
                        id = 3;
                        break;
                    case "Sala 4":
                        id = 4;
                        break;
                    case "Sala 5":
                        id = 5;
                        break;
                }

                this.fn_PromedioAsientosOcupadosPorMesTableAdapter.Fill(this.dataSetAsientosOcupados.fn_PromedioAsientosOcupadosPorMes, id);

                ReportParameter[] parametro = new ReportParameter[]
                {
                    new ReportParameter("SalaID", id.ToString())
                };

                reportViewer1.LocalReport.SetParameters(parametro);
                reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar el reporte: " + ex.Message);
            }
        }


        private void DetalleSala_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
        }
    }
}
