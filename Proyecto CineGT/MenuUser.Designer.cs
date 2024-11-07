namespace Proyecto_CineGT
{
    partial class MenuUser
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuUser));
            this.label1 = new System.Windows.Forms.Label();
            this.btnModificarB = new System.Windows.Forms.Button();
            this.btnAnularB = new System.Windows.Forms.Button();
            this.btnRegresar = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.Transparent;
            this.label1.Image = ((System.Drawing.Image)(resources.GetObject("label1.Image")));
            this.label1.Location = new System.Drawing.Point(72, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1033, 187);
            this.label1.TabIndex = 1;
            // 
            // btnModificarB
            // 
            this.btnModificarB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModificarB.Location = new System.Drawing.Point(785, 222);
            this.btnModificarB.Margin = new System.Windows.Forms.Padding(4);
            this.btnModificarB.Name = "btnModificarB";
            this.btnModificarB.Size = new System.Drawing.Size(160, 64);
            this.btnModificarB.TabIndex = 4;
            this.btnModificarB.Text = "MODIFICAR BOLETOS";
            this.btnModificarB.UseVisualStyleBackColor = true;
            this.btnModificarB.Click += new System.EventHandler(this.button4_Click);
            // 
            // btnAnularB
            // 
            this.btnAnularB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAnularB.Location = new System.Drawing.Point(541, 222);
            this.btnAnularB.Margin = new System.Windows.Forms.Padding(4);
            this.btnAnularB.Name = "btnAnularB";
            this.btnAnularB.Size = new System.Drawing.Size(172, 64);
            this.btnAnularB.TabIndex = 5;
            this.btnAnularB.Text = "CANCELACIÓN DE BOLETOS";
            this.btnAnularB.UseVisualStyleBackColor = true;
            this.btnAnularB.Click += new System.EventHandler(this.button5_Click);
            // 
            // btnRegresar
            // 
            this.btnRegresar.Image = ((System.Drawing.Image)(resources.GetObject("btnRegresar.Image")));
            this.btnRegresar.Location = new System.Drawing.Point(1083, 383);
            this.btnRegresar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnRegresar.Name = "btnRegresar";
            this.btnRegresar.Size = new System.Drawing.Size(80, 43);
            this.btnRegresar.TabIndex = 11;
            this.btnRegresar.UseVisualStyleBackColor = true;
            this.btnRegresar.Click += new System.EventHandler(this.btnRegresar_Click);
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.Location = new System.Drawing.Point(313, 222);
            this.button4.Margin = new System.Windows.Forms.Padding(4);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(172, 64);
            this.button4.TabIndex = 12;
            this.button4.Text = "CARTELERA";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click_1);
            // 
            // MenuUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1177, 439);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.btnRegresar);
            this.Controls.Add(this.btnAnularB);
            this.Controls.Add(this.btnModificarB);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "MenuUser";
            this.Text = "MenuUser";
            this.Load += new System.EventHandler(this.MenuUser_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnModificarB;
        private System.Windows.Forms.Button btnAnularB;
        private System.Windows.Forms.Button btnRegresar;
        private System.Windows.Forms.Button button4;
    }
}