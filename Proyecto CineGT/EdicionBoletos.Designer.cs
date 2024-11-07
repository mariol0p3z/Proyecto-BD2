namespace Proyecto_CineGT
{
    partial class EdicionBoletos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EdicionBoletos));
            this.label3 = new System.Windows.Forms.Label();
            this.txtTransaccionID = new System.Windows.Forms.TextBox();
            this.btnValidarT = new System.Windows.Forms.Button();
            this.dgDetallesReserva = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.btnModificar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgDetallesReserva)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(463, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(165, 25);
            this.label3.TabIndex = 8;
            this.label3.Text = "ID Transacción:";
            // 
            // txtTransaccionID
            // 
            this.txtTransaccionID.Location = new System.Drawing.Point(453, 92);
            this.txtTransaccionID.Name = "txtTransaccionID";
            this.txtTransaccionID.Size = new System.Drawing.Size(192, 22);
            this.txtTransaccionID.TabIndex = 9;
            // 
            // btnValidarT
            // 
            this.btnValidarT.Location = new System.Drawing.Point(473, 145);
            this.btnValidarT.Name = "btnValidarT";
            this.btnValidarT.Size = new System.Drawing.Size(155, 50);
            this.btnValidarT.TabIndex = 10;
            this.btnValidarT.Text = "Validar Transacción";
            this.btnValidarT.UseVisualStyleBackColor = true;
            this.btnValidarT.Click += new System.EventHandler(this.btnValidarT_Click);
            // 
            // dgDetallesReserva
            // 
            this.dgDetallesReserva.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgDetallesReserva.Location = new System.Drawing.Point(23, 228);
            this.dgDetallesReserva.Name = "dgDetallesReserva";
            this.dgDetallesReserva.RowHeadersWidth = 51;
            this.dgDetallesReserva.RowTemplate.Height = 24;
            this.dgDetallesReserva.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgDetallesReserva.Size = new System.Drawing.Size(1007, 350);
            this.dgDetallesReserva.TabIndex = 11;
            this.dgDetallesReserva.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgDetallesReserva_CellClick);
            this.dgDetallesReserva.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgDetallesReserva_CellValueChanged);
            this.dgDetallesReserva.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgDetallesReserva_CurrentCellDirtyStateChanged_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(47, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(206, 25);
            this.label1.TabIndex = 12;
            this.label1.Text = "Cambio de Asientos";
            // 
            // btnModificar
            // 
            this.btnModificar.Location = new System.Drawing.Point(806, 145);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(155, 50);
            this.btnModificar.TabIndex = 13;
            this.btnModificar.Text = "Modificar Transacción";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // EdicionBoletos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1067, 607);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgDetallesReserva);
            this.Controls.Add(this.btnValidarT);
            this.Controls.Add(this.txtTransaccionID);
            this.Controls.Add(this.label3);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "EdicionBoletos";
            this.Text = "EdicionBoletos";
            ((System.ComponentModel.ISupportInitialize)(this.dgDetallesReserva)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTransaccionID;
        private System.Windows.Forms.Button btnValidarT;
        private System.Windows.Forms.DataGridView dgDetallesReserva;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnModificar;
    }
}