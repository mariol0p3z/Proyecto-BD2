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
    public partial class Reportes : Form
    {
        public Reportes()
        {
            InitializeComponent();
        }

        private void MostrarFormPanel(Form form)
        {
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;

            panelReportes.Controls.Clear();
            panelReportes.Controls.Add(form);
            panelReportes.Tag = form;
            form.Show();
        }

        private Form ObtenerFormularioSeleccionado(string form)
        {
            switch (form)
            {
                case "Detalle Sesiones":
                    return new DetalleSesiones();
                case "Detalle Transacciones":
                    return new DetalleTransacciones();
                case "Promedio asientos por sala":
                    return new DetalleSala();
                case "Sesiones con asientos ocupados menor a un porcentaje dado":
                    return new DetalleAsientos();
                case "Top 5 peliculas con mayor promedio de asientos vendidos":
                    return new DetallePeliculas();
                case "Log de Transacciones":
                    return new LogTransacciones();
                case "Log de Sesiones":
                    return new LogSesiones();
                default:
                    return null;
            }
        }

        private void Reportes_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            string reporteSeleccionado = comboBox1.SelectedItem.ToString();
            Form form = ObtenerFormularioSeleccionado(reporteSeleccionado);

            if (form != null)
            {
                MostrarFormPanel(form);
            }
            else
            {
                MessageBox.Show("No se encontro ningun reporte");
            }
        }
    }
}
