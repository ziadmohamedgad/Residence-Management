using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentation_Layer.Residences
{
    public partial class frmAddUpdateResidence : Form
    {
        public frmAddUpdateResidence()
        {
            InitializeComponent();
        }

        private void txtNotes_KeyPress(object sender, KeyPressEventArgs e)
        {
            //messagebox noooo if exceeded 500 chars
        }
    }
}
