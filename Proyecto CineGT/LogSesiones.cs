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
    public partial class LogSesiones : Form
    {
        public LogSesiones()
        {
            InitializeComponent();
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime horaInicio = txtFechaInicio.Value;
                DateTime horaFin = txtFechaFin.Value;
                this.fn_LogSesionesTableAdapter1.Fill(this.dataSourceLogSesiones1.fn_LogSesiones, horaInicio, horaFin);
                ReportParameter[] parametros = new ReportParameter[]
                {
                        new ReportParameter("HoraInicio", horaInicio.ToString("yyyy-MM-dd HH:mm:ss.fff")),
                        new ReportParameter("HoraFin", horaFin.ToString("yyyy-MM-dd HH:mm:ss.fff"))
                };

                reportViewer1.LocalReport.DataSources.Clear();

                ReportDataSource dataSource = new ReportDataSource("DataSetLogSesion", this.dataSourceLogSesiones1.Tables["fn_LogSesiones"]);
                reportViewer1.LocalReport.SetParameters(parametros);
                this.reportViewer1.LocalReport.DataSources.Add(dataSource);
                reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar el reporte: " + ex.Message);
            }
        }

        private void LogSesiones_Load(object sender, EventArgs e)
        {
            txtFechaInicio.Format = DateTimePickerFormat.Custom;
            txtFechaInicio.CustomFormat = "yyyy/MM/dd HH:mm:ss.fff";
            txtFechaInicio.ShowUpDown = true;
            txtFechaFin.Format = DateTimePickerFormat.Custom;
            txtFechaFin.CustomFormat = "yyyy/MM/dd HH:mm:ss.fff";
            txtFechaFin.ShowUpDown = true;
            this.reportViewer1.RefreshReport();
        }
    }
}
