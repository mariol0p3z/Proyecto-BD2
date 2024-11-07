namespace Proyecto_CineGT
{
    partial class LogTransacciones
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
            this.fnLogTransaccionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSourceLogTransacciones = new Proyecto_CineGT.DataSourceLogTransacciones();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnReporte = new System.Windows.Forms.Button();
            this.txtFechaFin = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtFechaInicio = new System.Windows.Forms.DateTimePicker();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.fn_LogTransaccionTableAdapter = new Proyecto_CineGT.DataSourceLogTransaccionesTableAdapters.fn_LogTransaccionTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.fnLogTransaccionBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSourceLogTransacciones)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // fnLogTransaccionBindingSource
            // 
            this.fnLogTransaccionBindingSource.DataMember = "fn_LogTransaccion";
            this.fnLogTransaccionBindingSource.DataSource = this.dataSourceLogTransacciones;
            // 
            // dataSourceLogTransacciones
            // 
            this.dataSourceLogTransacciones.DataSetName = "DataSourceLogTransacciones";
            this.dataSourceLogTransacciones.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
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
            this.panel1.Size = new System.Drawing.Size(746, 73);
            this.panel1.TabIndex = 2;
            // 
            // btnReporte
            // 
            this.btnReporte.Location = new System.Drawing.Point(619, 23);
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
            this.txtFechaFin.Location = new System.Drawing.Point(411, 35);
            this.txtFechaFin.Name = "txtFechaFin";
            this.txtFechaFin.Size = new System.Drawing.Size(179, 22);
            this.txtFechaFin.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(321, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Fecha Fin:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Fecha Inicio:";
            // 
            // txtFechaInicio
            // 
            this.txtFechaInicio.CustomFormat = "yyyy/MM/dd HH:mm:ss.fff";
            this.txtFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtFechaInicio.Location = new System.Drawing.Point(116, 35);
            this.txtFechaInicio.Name = "txtFechaInicio";
            this.txtFechaInicio.Size = new System.Drawing.Size(178, 22);
            this.txtFechaInicio.TabIndex = 0;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Proyecto_CineGT.Reportes.ReporteLogTransaccion.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 73);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(746, 377);
            this.reportViewer1.TabIndex = 3;
            // 
            // fn_LogTransaccionTableAdapter
            // 
            this.fn_LogTransaccionTableAdapter.ClearBeforeFill = true;
            // 
            // LogTransacciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(746, 450);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.panel1);
            this.Name = "LogTransacciones";
            this.Text = "LogTransacciones";
            this.Load += new System.EventHandler(this.LogTransacciones_Load);
            ((System.ComponentModel.ISupportInitialize)(this.fnLogTransaccionBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSourceLogTransacciones)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnReporte;
        private System.Windows.Forms.DateTimePicker txtFechaFin;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker txtFechaInicio;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource fnLogTransaccionBindingSource;
        private DataSourceLogTransacciones dataSourceLogTransacciones;
        private DataSourceLogTransaccionesTableAdapters.fn_LogTransaccionTableAdapter fn_LogTransaccionTableAdapter;
    }
}