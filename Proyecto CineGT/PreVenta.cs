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
    public partial class PreVenta : Form
    {
        public PreVenta()
        {
            InitializeComponent();
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            MenuUser menuser = new MenuUser();
            menuser.Show();
            this.Close();
        }
    }
}
