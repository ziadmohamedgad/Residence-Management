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

namespace Presentation_Layer.Employees.Controls
{
    public partial class ctrlEmployeeCardWithFilter : UserControl
    {
        public event Action<int> OnEmployeeSelected;
        private int _EmployeeID = -1;
        private clsEmployee _Employee;
        public int EmployeeID
        {
            get
            {
                return _EmployeeID;
            }
        }
        public clsEmployee SelectedEmployee
        {
            get
            {
                return _Employee;
            }
        }
        private bool _ShowAddEmployee = true;
        public bool ShowAddEmployee
        {
            get
            {
                return _ShowAddEmployee;
            }
            set
            {
                _ShowAddEmployee = value;
                btnAddNewEmployee.Visible = _ShowAddEmployee;
            }
        }
        private bool _FilterEnabled = true;
        public bool FilterEnabled
        {
            get
            {
                return _FilterEnabled;
            }
            set
            {
                _FilterEnabled = value;
                gbFilters.Enabled = _FilterEnabled;
            }
        }
        public ctrlEmployeeCardWithFilter()
        {
            InitializeComponent();
        }
        protected virtual void EmployeeSelected(int EmployeeID)
        {
            Action<int> Handler = OnEmployeeSelected;
            if (Handler != null)
            {
                Handler.Invoke(EmployeeID);
            }
        }
        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilterValue.Text = "";
            txtFilterValue.Focus();
        }
        private void btnFind_Click(object sender, EventArgs e)
        {
            ctrlEmployeeCard1.LoadEmployeeInfo(int.Parse(txtFilterValue.Text.Trim()));
            this._EmployeeID = ctrlEmployeeCard1.EmployeeID;
            if (OnEmployeeSelected != null && FilterEnabled && ctrlEmployeeCard1.SelectedEmployeeInfo != null)
            {
                EmployeeSelected(_EmployeeID);
            }
        }
        private void btnAddNewEmployee_Click(object sender, EventArgs e)
        {
            frmAddUpdateEmployee frm = new frmAddUpdateEmployee();
            frm.DataBack += _DataBackEvent;
            frm.ShowDialog();
        }
        private void _DataBackEvent(int EmployeeID)
        {
            cbFilterBy.SelectedIndex = 0;
            txtFilterValue.Text = EmployeeID.ToString();
            ctrlEmployeeCard1.LoadEmployeeInfo(EmployeeID);
            this._EmployeeID = ctrlEmployeeCard1.EmployeeID;
            if (OnEmployeeSelected != null && ctrlEmployeeCard1.SelectedEmployeeInfo != null)
            {
                EmployeeSelected(_EmployeeID);
            }
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
        public void FilterFocus()
        {
            txtFilterValue.Focus();
        }
        private void ctrlEmployeeCardWithFilter_Load(object sender, EventArgs e)
        {
            cbFilterBy.SelectedIndex = 0;
            txtFilterValue.Focus();
        }
    }
}
