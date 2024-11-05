﻿using System;
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
    public partial class NuevasSesiones : Form
    {
        private int usuarioId;
        public NuevasSesiones(int usuarioId)
        {
            InitializeComponent();
            this.usuarioId = usuarioId;
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            MenuAdmin ma = new MenuAdmin(usuarioId);
            ma.Show();
            this.Close();
        }
    }
}
