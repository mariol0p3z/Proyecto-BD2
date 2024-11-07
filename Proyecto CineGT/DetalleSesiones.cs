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
    public partial class DetalleSesiones : Form
    {
        public DetalleSesiones()
        {
            InitializeComponent();
        }

        private void DetalleSesiones_Load(object sender, EventArgs e)
        {

            txtFechaInicio.Format = DateTimePickerFormat.Custom;
            txtFechaInicio.CustomFormat = "yyyy/MM/dd HH:mm:ss.fff";
            txtFechaInicio.ShowUpDown = true;
            txtFechaFin.Format = DateTimePickerFormat.Custom;
            txtFechaFin.CustomFormat = "yyyy/MM/dd HH:mm:ss.fff";
            txtFechaFin.ShowUpDown = true;
            this.reportViewer1.RefreshReport();
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime fechaInicio = txtFechaInicio.Value;
                DateTime fechaFin = txtFechaFin.Value;
                this.listadoSesionesConAsientosOcupadosTableAdapter.Fill(this.dataSourceListaSesiones.ListadoSesionesConAsientosOcupados, fechaInicio, fechaFin);

                ReportParameter[] parametros = new ReportParameter[]
                {
                    new ReportParameter("fechaInicio", fechaInicio.ToString("yyyy-MM-dd HH:mm:ss.fff")),
                    new ReportParameter("fechaFin", fechaFin.ToString("yyyy-MM-dd HH:mm:ss.fff"))
                };

                reportViewer1.LocalReport.SetParameters(parametros);
                reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar el reporte: " + ex.Message);
            }
        }
    }
}
