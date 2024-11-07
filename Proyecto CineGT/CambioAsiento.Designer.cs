namespace Proyecto_CineGT
{
    partial class CambioAsiento
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CambioAsiento));
            this.lblPelicula = new System.Windows.Forms.Label();
            this.lblSala = new System.Windows.Forms.Label();
            this.lblFechaSesion = new System.Windows.Forms.Label();
            this.comboBoxSesiones = new System.Windows.Forms.ComboBox();
            this.btnConfirmarCambio = new System.Windows.Forms.Button();
            this.dgAsientoNuevo = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgAsientoNuevo)).BeginInit();
            this.SuspendLayout();
            // 
            // lblPelicula
            // 
            this.lblPelicula.AutoSize = true;
            this.lblPelicula.Location = new System.Drawing.Point(61, 48);
            this.lblPelicula.Name = "lblPelicula";
            this.lblPelicula.Size = new System.Drawing.Size(44, 16);
            this.lblPelicula.TabIndex = 0;
            this.lblPelicula.Text = "label1";
            // 
            // lblSala
            // 
            this.lblSala.AutoSize = true;
            this.lblSala.Location = new System.Drawing.Point(61, 84);
            this.lblSala.Name = "lblSala";
            this.lblSala.Size = new System.Drawing.Size(44, 16);
            this.lblSala.TabIndex = 1;
            this.lblSala.Text = "label1";
            // 
            // lblFechaSesion
            // 
            this.lblFechaSesion.AutoSize = true;
            this.lblFechaSesion.Location = new System.Drawing.Point(61, 118);
            this.lblFechaSesion.Name = "lblFechaSesion";
            this.lblFechaSesion.Size = new System.Drawing.Size(44, 16);
            this.lblFechaSesion.TabIndex = 2;
            this.lblFechaSesion.Text = "label1";
            // 
            // comboBoxSesiones
            // 
            this.comboBoxSesiones.FormattingEnabled = true;
            this.comboBoxSesiones.Location = new System.Drawing.Point(35, 182);
            this.comboBoxSesiones.Name = "comboBoxSesiones";
            this.comboBoxSesiones.Size = new System.Drawing.Size(152, 24);
            this.comboBoxSesiones.TabIndex = 3;
            // 
            // btnConfirmarCambio
            // 
            this.btnConfirmarCambio.Location = new System.Drawing.Point(24, 250);
            this.btnConfirmarCambio.Name = "btnConfirmarCambio";
            this.btnConfirmarCambio.Size = new System.Drawing.Size(138, 48);
            this.btnConfirmarCambio.TabIndex = 4;
            this.btnConfirmarCambio.Text = "Confirmar Cambio";
            this.btnConfirmarCambio.UseVisualStyleBackColor = true;
            this.btnConfirmarCambio.Click += new System.EventHandler(this.btnConfirmarCambio_Click_1);
            // 
            // dgAsientoNuevo
            // 
            this.dgAsientoNuevo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgAsientoNuevo.Location = new System.Drawing.Point(263, 74);
            this.dgAsientoNuevo.Name = "dgAsientoNuevo";
            this.dgAsientoNuevo.RowHeadersWidth = 51;
            this.dgAsientoNuevo.RowTemplate.Height = 24;
            this.dgAsientoNuevo.Size = new System.Drawing.Size(600, 367);
            this.dgAsientoNuevo.TabIndex = 5;
            // 
            // CambioAsiento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(907, 499);
            this.Controls.Add(this.dgAsientoNuevo);
            this.Controls.Add(this.btnConfirmarCambio);
            this.Controls.Add(this.comboBoxSesiones);
            this.Controls.Add(this.lblFechaSesion);
            this.Controls.Add(this.lblSala);
            this.Controls.Add(this.lblPelicula);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CambioAsiento";
            this.Text = "CambioAsiento";
            ((System.ComponentModel.ISupportInitialize)(this.dgAsientoNuevo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPelicula;
        private System.Windows.Forms.Label lblSala;
        private System.Windows.Forms.Label lblFechaSesion;
        private System.Windows.Forms.ComboBox comboBoxSesiones;
        private System.Windows.Forms.Button btnConfirmarCambio;
        private System.Windows.Forms.DataGridView dgAsientoNuevo;
    }
}