using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentation_Layer.Employees
{
    public partial class frmChooseSponsor : Form
    {
        public delegate void DataBackEventHandler(int SponsorPersonID);
        public event DataBackEventHandler DataBack;
        private int _SelectedPersonID = -1;
        public frmChooseSponsor()
        {
            InitializeComponent();
        }
        private void ctrlPersonCardWithFilter1_OnPersonSelected(int PersonID)
        {
            _SelectedPersonID = PersonID;
            btnEnsureChoice.Visible = true;
            ctrlPersonCardWithFilter1.FilterEnabled = false;
        }
        private void btnEnsureChoice_Click(object sender, EventArgs e)
        {
            if (ctrlPersonCardWithFilter1.PersonID != -1)
            {
                _SelectedPersonID = ctrlPersonCardWithFilter1.PersonID;
                DataBack?.Invoke(_SelectedPersonID);
                this.Close();
            }
            else
            {
                MessageBox.Show("يجب أن تقوم باختيار شخص أولًأ", "خطأ",  MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnEnsureChoice.Visible = false;
            }
        }
        private void frmChooseSponsor_Activated(object sender, EventArgs e)
        {
            ctrlPersonCardWithFilter1.FilterFocus();

        }
    }
}