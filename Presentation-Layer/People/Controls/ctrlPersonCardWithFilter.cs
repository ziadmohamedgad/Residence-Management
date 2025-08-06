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

namespace Presentation_Layer.People.Controls
{
    public partial class ctrlPersonCardWithFilter : UserControl
    {
        public event Action<int> OnPersonSelected;
        protected virtual void PersonSelected(int PersonID)
        {
            Action<int> Handler = OnPersonSelected;
            if (Handler != null)
                Handler.Invoke(PersonID);
        }
        private int _PersonID = -1;
        public int PersonID
        {
            get { return _PersonID; }
        }
        private bool _ShowAddPerson = true;
        public bool ShowAddPerson
        {
            get { return _ShowAddPerson; }
            set
            {
                _ShowAddPerson = value;
                btnAddNewPerson.Visible = _ShowAddPerson;
            }
        }
        private bool _FilterEnabled = true;
        public bool FilterEnabled
        {
            get
                { return _FilterEnabled; }
            set
            {
                _FilterEnabled = value;
                gbFilters.Enabled = _FilterEnabled;
            }
        }
        private clsPerson SelectedPersonInfo
        {
            get
            {
                return ctrlPersonCard1.SelectedPersonInfo;
            }
        }
        public ctrlPersonCardWithFilter()
        {
            InitializeComponent();
        }
        private void txtFilterValue_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtFilterValue.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtFilterValue, "هذا الحقل متطلب!");
            }
            else
                errorProvider1.SetError(txtFilterValue, null);
        }
        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13) //Enter Pressed
                btnFind.PerformClick();
            if (cbFilterBy.SelectedIndex == 0)
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilterValue.Text = "";
            txtFilterValue.Focus();
        }
        public void LoadPersonInfo(int PersonID)
        {
            cbFilterBy.SelectedIndex = 0;
            txtFilterValue.Text = PersonID.ToString();
            _FindNow();
        }
        private void _FindNow()
        {
            ctrlPersonCard1.LoadPersonInfo(int.Parse(txtFilterValue.Text.Trim()));
            if (OnPersonSelected != null && FilterEnabled && ctrlPersonCard1.SelectedPersonInfo != null)
                PersonSelected(ctrlPersonCard1.PersonID);
        }
        private void btnAddNewPerson_Click(object sender, EventArgs e)
        {
            // here we will call the add\update new person form in add mode
            // adn subscribe the databack event with the current databaceevent method then show dialog
            frmAddUpdatePerson frm = new frmAddUpdatePerson();
            frm.DataBack += DataBackEvent;
            frm.ShowDialog();
        }
        private void DataBackEvent(int PersonID)
        {
            cbFilterBy.SelectedIndex = 0;
            txtFilterValue.Text = PersonID.ToString();
            ctrlPersonCard1.LoadPersonInfo(PersonID);
            if (OnPersonSelected != null && ctrlPersonCard1.SelectedPersonInfo != null)
                PersonSelected(ctrlPersonCard1.PersonID);
        }
        private void btnFind_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("بعض الحقول فارغة أو بها أخطاء، ضع الفأرة على النقاط الحمراء لكي تتعرف على الخطأ", 
                    "خطأ في الإدخال", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }    
            _FindNow();
        }
        private void ctrlPersonCardWithFilter_Load(object sender, EventArgs e)
        {
            cbFilterBy.SelectedIndex = 0;
            txtFilterValue.Focus();
        }
        public void FilterFocus()
        {
            txtFilterValue.Focus();
        }
    }
}