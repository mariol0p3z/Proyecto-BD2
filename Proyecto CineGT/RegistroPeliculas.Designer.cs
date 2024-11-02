namespace Proyecto_CineGT
{
    partial class RegistroPeliculas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegistroPeliculas));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtClasificacion = new System.Windows.Forms.ComboBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtDuracion = new System.Windows.Forms.TextBox();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.btnRegistro = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.btnRegresar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Unispace", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(37, 163);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(229, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "NOMBRE DE LA PELÍCULA:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Unispace", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(37, 209);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(199, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "DURACIÓN (MINUTOS):";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Unispace", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(438, 163);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(129, 19);
            this.label3.TabIndex = 2;
            this.label3.Text = "DESCRIPCIÓN:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Unispace", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(37, 255);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(149, 19);
            this.label4.TabIndex = 3;
            this.label4.Text = "CLASIFICACIÓN:";
            // 
            // txtClasificacion
            // 
            this.txtClasificacion.FormattingEnabled = true;
            this.txtClasificacion.Items.AddRange(new object[] {
            "ATP",
            "ATPR",
            "P-13",
            "P-13R",
            "P-16",
            "P-16R",
            "P-18"});
            this.txtClasificacion.Location = new System.Drawing.Point(270, 253);
            this.txtClasificacion.Margin = new System.Windows.Forms.Padding(2);
            this.txtClasificacion.Name = "txtClasificacion";
            this.txtClasificacion.Size = new System.Drawing.Size(128, 21);
            this.txtClasificacion.TabIndex = 4;
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(270, 162);
            this.txtNombre.Margin = new System.Windows.Forms.Padding(2);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(128, 20);
            this.txtNombre.TabIndex = 5;
            // 
            // txtDuracion
            // 
            this.txtDuracion.Location = new System.Drawing.Point(270, 208);
            this.txtDuracion.Margin = new System.Windows.Forms.Padding(2);
            this.txtDuracion.Name = "txtDuracion";
            this.txtDuracion.Size = new System.Drawing.Size(128, 20);
            this.txtDuracion.TabIndex = 6;
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(571, 162);
            this.txtDescripcion.Margin = new System.Windows.Forms.Padding(2);
            this.txtDescripcion.Multiline = true;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(285, 94);
            this.txtDescripcion.TabIndex = 7;
            // 
            // btnRegistro
            // 
            this.btnRegistro.Font = new System.Drawing.Font("Unispace", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegistro.Location = new System.Drawing.Point(384, 313);
            this.btnRegistro.Margin = new System.Windows.Forms.Padding(2);
            this.btnRegistro.Name = "btnRegistro";
            this.btnRegistro.Size = new System.Drawing.Size(104, 42);
            this.btnRegistro.TabIndex = 8;
            this.btnRegistro.Text = "REGISTRAR PELÍCULA";
            this.btnRegistro.UseVisualStyleBackColor = true;
            this.btnRegistro.Click += new System.EventHandler(this.btnRegistro_Click);
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.ForeColor = System.Drawing.Color.Transparent;
            this.label5.Image = ((System.Drawing.Image)(resources.GetObject("label5.Image")));
            this.label5.Location = new System.Drawing.Point(-5, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(893, 129);
            this.label5.TabIndex = 9;
            // 
            // btnRegresar
            // 
            this.btnRegresar.Image = ((System.Drawing.Image)(resources.GetObject("btnRegresar.Image")));
            this.btnRegresar.Location = new System.Drawing.Point(817, 345);
            this.btnRegresar.Margin = new System.Windows.Forms.Padding(2);
            this.btnRegresar.Name = "btnRegresar";
            this.btnRegresar.Size = new System.Drawing.Size(60, 35);
            this.btnRegresar.TabIndex = 10;
            this.btnRegresar.UseVisualStyleBackColor = true;
            this.btnRegresar.Click += new System.EventHandler(this.btnRegresar_Click);
            // 
            // RegistroPeliculas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(888, 391);
            this.Controls.Add(this.btnRegresar);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnRegistro);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.txtDuracion);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.txtClasificacion);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "RegistroPeliculas";
            this.Text = "RegistroPeliculas";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox txtClasificacion;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtDuracion;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Button btnRegistro;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnRegresar;
    }
}