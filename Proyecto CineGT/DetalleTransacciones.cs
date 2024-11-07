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
    public partial class DetalleTransacciones : Form
    {
        public DetalleTransacciones()
        {
            InitializeComponent();
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime fechaInicio = txtFechaInicio.Value;
                DateTime fechaFin = txtFechaFin.Value;
               
                this.listadoTransaccionesTableAdapter.Fill(this.dataSourceListaTransacciones.ListadoTransacciones, fechaInicio, fechaFin);
                
                ReportParameter[] parametros = new ReportParameter[]
                {
                        new ReportParameter("FechaInicio", fechaInicio.ToString("yyyy-MM-dd HH:mm:ss.fff")),
                        new ReportParameter("FechaFin", fechaFin.ToString("yyyy-MM-dd HH:mm:ss.fff"))
                };
                reportViewer1.LocalReport.DataSources.Clear();
                ReportDataSource reportDataSource = new ReportDataSource("DataSetListaTransacciones", this.dataSourceListaTransacciones.Tables["ListadoTransacciones"]);
                reportViewer1.LocalReport.SetParameters(parametros);
                this.reportViewer1.LocalReport.DataSources.Add(reportDataSource);
                reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar el reporte: " + ex.Message);
            }
        }

        private void DetalleTransacciones_Load(object sender, EventArgs e)
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
