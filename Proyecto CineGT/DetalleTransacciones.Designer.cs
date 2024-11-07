namespace Proyecto_CineGT
{
    partial class DetalleTransacciones
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnReporte = new System.Windows.Forms.Button();
            this.txtFechaFin = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtFechaInicio = new System.Windows.Forms.DateTimePicker();
            this.dataSourceListaTransacciones = new Proyecto_CineGT.DataSourceListaTransacciones();
            this.listadoTransaccionesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.listadoTransaccionesTableAdapter = new Proyecto_CineGT.DataSourceListaTransaccionesTableAdapters.ListadoTransaccionesTableAdapter();
            this.panel2 = new System.Windows.Forms.Panel();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataSourceListaTransacciones)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.listadoTransaccionesBindingSource)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnReporte);
            this.panel1.Controls.Add(this.txtFechaFin);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtFechaInicio);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(871, 73);
            this.panel1.TabIndex = 1;
            // 
            // btnReporte
            // 
            this.btnReporte.Location = new System.Drawing.Point(704, 23);
            this.btnReporte.Name = "btnReporte";
            this.btnReporte.Size = new System.Drawing.Size(110, 39);
            this.btnReporte.TabIndex = 3;
            this.btnReporte.Text = "Ver Reporte";
            this.btnReporte.UseVisualStyleBackColor = true;
            this.btnReporte.Click += new System.EventHandler(this.btnReporte_Click);
            // 
            // txtFechaFin
            // 
            this.txtFechaFin.CustomFormat = "yyyy/MM/dd HH:mm:ss.fff";
            this.txtFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtFechaFin.Location = new System.Drawing.Point(487, 35);
            this.txtFechaFin.Name = "txtFechaFin";
            this.txtFechaFin.ShowUpDown = true;
            this.txtFechaFin.Size = new System.Drawing.Size(179, 22);
            this.txtFechaFin.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(348, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Fecha Fin Compra:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Fecha Inicio Compra:";
            // 
            // txtFechaInicio
            // 
            this.txtFechaInicio.CustomFormat = "yyyy/MM/dd HH:mm:ss.fff";
            this.txtFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtFechaInicio.Location = new System.Drawing.Point(161, 34);
            this.txtFechaInicio.Name = "txtFechaInicio";
            this.txtFechaInicio.ShowUpDown = true;
            this.txtFechaInicio.Size = new System.Drawing.Size(166, 22);
            this.txtFechaInicio.TabIndex = 0;
            // 
            // dataSourceListaTransacciones
            // 
            this.dataSourceListaTransacciones.DataSetName = "DataSourceListaTransacciones";
            this.dataSourceListaTransacciones.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // listadoTransaccionesBindingSource
            // 
            this.listadoTransaccionesBindingSource.DataMember = "ListadoTransacciones";
            this.listadoTransaccionesBindingSource.DataSource = this.dataSourceListaTransacciones;
            // 
            // listadoTransaccionesTableAdapter
            // 
            this.listadoTransaccionesTableAdapter.ClearBeforeFill = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.reportViewer1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 73);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(871, 377);
            this.panel2.TabIndex = 2;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Proyecto_CineGT.Reportes.ReporteTransacciones.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(871, 377);
            this.reportViewer1.TabIndex = 0;
            // 
            // DetalleTransacciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(871, 450);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "DetalleTransacciones";
            this.Text = "DetalleTransacciones";
            this.Load += new System.EventHandler(this.DetalleTransacciones_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataSourceListaTransacciones)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.listadoTransaccionesBindingSource)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnReporte;
        private System.Windows.Forms.DateTimePicker txtFechaFin;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker txtFechaInicio;
        private System.Windows.Forms.BindingSource listadoTransaccionesBindingSource;
        private DataSourceListaTransacciones dataSourceListaTransacciones;
        private DataSourceListaTransaccionesTableAdapters.ListadoTransaccionesTableAdapter listadoTransaccionesTableAdapter;
        private System.Windows.Forms.Panel panel2;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
    }
}