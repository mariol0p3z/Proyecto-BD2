using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace Proyecto_CineGT
{
    public partial class DetalleAsientos : Form
    {
        public DetalleAsientos()
        {
            InitializeComponent();
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            try
            {
                decimal porcentaje = decimal.Parse(txtPorcentaje.Text);
                this.fn_SesionesPorcentajeOcupacionTableAdapter1.Fill(this.cineGTDataSet1.fn_SesionesPorcentajeOcupacion, porcentaje);
                ReportParameter[] parametros = new ReportParameter[]
                {
                    new ReportParameter("Porcentaje", porcentaje.ToString())
                };

                ReportDataSource reportDataSource = new ReportDataSource("DataSetAsientos", this.cineGTDataSet1.Tables["fn_SesionesPorcentajeOcupacion"]);
                reportViewer1.LocalReport.SetParameters(parametros);
                this.reportViewer1.LocalReport.DataSources.Add(reportDataSource);
                reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar el reporte: " + ex.Message);
            }
        }

        private void DetalleAsientos_Load(object sender, EventArgs e)
        {

        }
    }
}
