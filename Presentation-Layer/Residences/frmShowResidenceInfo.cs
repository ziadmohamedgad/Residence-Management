using Business_Layer;
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
    public partial class frmShowResidenceInfo : Form
    {
        private int _ResidenceID = -1;
        public frmShowResidenceInfo(int ResidenceID)
        {
            InitializeComponent();
            this._ResidenceID = ResidenceID;
            clsResidence Residence = clsResidence.FindByResidenceID(ResidenceID);
            if (Residence == null)
            {
                MessageBox.Show("لا يوجد إقامة بالرقم التعريفي " +  this._ResidenceID,
                    "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

        }
    }
}
