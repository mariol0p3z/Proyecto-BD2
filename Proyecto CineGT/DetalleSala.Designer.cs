namespace Proyecto_CineGT
{
    partial class DetalleSala
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource3 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.panel1 = new System.Windows.Forms.Panel();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnReporte = new System.Windows.Forms.Button();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.dataSetAsientosOcupados = new Proyecto_CineGT.DataSetAsientosOcupados();
            this.dataSetAsientosOcupadosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.fnPromedioAsientosOcupadosPorMesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.fn_PromedioAsientosOcupadosPorMesTableAdapter = new Proyecto_CineGT.DataSetAsientosOcupadosTableAdapters.fn_PromedioAsientosOcupadosPorMesTableAdapter();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetAsientosOcupados)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetAsientosOcupadosBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fnPromedioAsientosOcupadosPorMesBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.comboBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnReporte);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 73);
            this.panel1.TabIndex = 4;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Sala 1",
            "Sala 2",
            "Sala 3",
            "Sala 4",
            "Sala 5"});
            this.comboBox1.Location = new System.Drawing.Point(234, 31);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(196, 24);
            this.comboBox1.TabIndex = 5;

            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(161, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "Sala:";
            // 
            // btnReporte
            // 
            this.btnReporte.Location = new System.Drawing.Point(531, 23);
            this.btnReporte.Name = "btnReporte";
            this.btnReporte.Size = new System.Drawing.Size(110, 39);
            this.btnReporte.TabIndex = 3;
            this.btnReporte.Text = "Ver Reporte";
            this.btnReporte.UseVisualStyleBackColor = true;
            this.btnReporte.Click += new System.EventHandler(this.btnReporte_Click);
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource3.Name = "DataSetSala";
            reportDataSource3.Value = this.fnPromedioAsientosOcupadosPorMesBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource3);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Proyecto_CineGT.Reportes.ReporteSalas.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 73);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(800, 377);
            this.reportViewer1.TabIndex = 5;
            // 
            // dataSetAsientosOcupados
            // 
            this.dataSetAsientosOcupados.DataSetName = "DataSetAsientosOcupados";
            this.dataSetAsientosOcupados.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dataSetAsientosOcupadosBindingSource
            // 
            this.dataSetAsientosOcupadosBindingSource.DataSource = this.dataSetAsientosOcupados;
            this.dataSetAsientosOcupadosBindingSource.Position = 0;
            // 
            // fnPromedioAsientosOcupadosPorMesBindingSource
            // 
            this.fnPromedioAsientosOcupadosPorMesBindingSource.DataMember = "fn_PromedioAsientosOcupadosPorMes";
            this.fnPromedioAsientosOcupadosPorMesBindingSource.DataSource = this.dataSetAsientosOcupadosBindingSource;
            // 
            // fn_PromedioAsientosOcupadosPorMesTableAdapter
            // 
            this.fn_PromedioAsientosOcupadosPorMesTableAdapter.ClearBeforeFill = true;
            // 
            // DetalleSala
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.panel1);
            this.Name = "DetalleSala";
            this.Text = "DetalleSala";
            this.Load += new System.EventHandler(this.DetalleSala_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetAsientosOcupados)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetAsientosOcupadosBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fnPromedioAsientosOcupadosPorMesBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnReporte;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource fnPromedioAsientosOcupadosPorMesBindingSource;
        private System.Windows.Forms.BindingSource dataSetAsientosOcupadosBindingSource;
        private DataSetAsientosOcupados dataSetAsientosOcupados;
        private DataSetAsientosOcupadosTableAdapters.fn_PromedioAsientosOcupadosPorMesTableAdapter fn_PromedioAsientosOcupadosPorMesTableAdapter;
    }
}