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
    public partial class DetalleSesiones : Form
    {
        public DetalleSesiones()
        {
            InitializeComponent();
        }

        private void DetalleSesiones_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }
    }
}
