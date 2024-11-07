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
    public partial class LogTransacciones : Form
    {
        public LogTransacciones()
        {
            InitializeComponent();
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime horaInicio = txtFechaInicio.Value;
                DateTime horaFin = txtFechaFin.Value;

                this.fn_LogTransaccionTableAdapter.Fill(this.dataSourceLogTransacciones.fn_LogTransaccion, horaInicio, horaFin);

                ReportParameter[] parametros = new ReportParameter[]
                {
                    new ReportParameter("HoraInicio", horaInicio.ToString("yyyy-MM-dd HH:mm:ss.fff")),
                    new ReportParameter("HoraFin", horaFin.ToString("yyyy-MM-dd HH:mm:ss.fff"))
                };

                reportViewer1.LocalReport.DataSources.Clear();
                ReportDataSource reportDataSource = new ReportDataSource("DataSetLogTransacciones", this.dataSourceLogTransacciones.Tables["fn_LogTransaccion"]);
                reportViewer1.LocalReport.SetParameters(parametros);
                this.reportViewer1.LocalReport.DataSources.Add(reportDataSource);
                reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar el reporte: " + ex.Message);
            }
        }

        private void LogTransacciones_Load(object sender, EventArgs e)
        {
            txtFechaInicio.Format = DateTimePickerFormat.Custom;
            txtFechaInicio.CustomFormat = "yyyy/dd/MM HH:mm:ss.fff";
            txtFechaInicio.ShowUpDown = true;
            txtFechaFin.Format = DateTimePickerFormat.Custom;
            txtFechaFin.CustomFormat = "yyyy/dd/MM HH:mm:ss.fff";
            txtFechaFin.ShowUpDown = true;
            this.reportViewer1.RefreshReport();
        }
    }
}
