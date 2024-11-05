namespace Proyecto_CineGT
{
    partial class DetallePeliculas
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.fnTop5BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSetTop5BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSetTop5 = new Proyecto_CineGT.DataSetTop5();
            this.panel1 = new System.Windows.Forms.Panel();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.fn_Top5TableAdapter = new Proyecto_CineGT.DataSetTop5TableAdapters.fn_Top5TableAdapter();
            this.fnTop5BindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.fnTop5BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetTop5BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetTop5)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fnTop5BindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // fnTop5BindingSource
            // 
            this.fnTop5BindingSource.DataMember = "fn_Top5";
            this.fnTop5BindingSource.DataSource = this.dataSetTop5BindingSource;
            // 
            // dataSetTop5BindingSource
            // 
            this.dataSetTop5BindingSource.DataSource = this.dataSetTop5;
            this.dataSetTop5BindingSource.Position = 0;
            // 
            // dataSetTop5
            // 
            this.dataSetTop5.DataSetName = "DataSetTop5";
            this.dataSetTop5.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.reportViewer1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 450);
            this.panel1.TabIndex = 0;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSetPeliculas";
            reportDataSource1.Value = this.fnTop5BindingSource1;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Proyecto_CineGT.Reportes.ReportePeliculas.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(800, 450);
            this.reportViewer1.TabIndex = 0;
            // 
            // fn_Top5TableAdapter
            // 
            this.fn_Top5TableAdapter.ClearBeforeFill = true;
            // 
            // fnTop5BindingSource1
            // 
            this.fnTop5BindingSource1.DataMember = "fn_Top5";
            this.fnTop5BindingSource1.DataSource = this.dataSetTop5BindingSource;
            // 
            // DetallePeliculas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.Name = "DetallePeliculas";
            this.Text = "DetallePeliculas";
            this.Load += new System.EventHandler(this.DetallePeliculas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.fnTop5BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetTop5BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetTop5)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fnTop5BindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private DataSetTop5 dataSetTop5;
        private System.Windows.Forms.BindingSource dataSetTop5BindingSource;
        private System.Windows.Forms.BindingSource fnTop5BindingSource;
        private DataSetTop5TableAdapters.fn_Top5TableAdapter fn_Top5TableAdapter;
        private System.Windows.Forms.BindingSource fnTop5BindingSource1;
    }
}