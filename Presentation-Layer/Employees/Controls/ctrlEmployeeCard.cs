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
    public partial class ctrlEmployeeCard : UserControl
    {
        private int _EmployeeID = -1;
        private clsEmployee _Employee;
        public int EmployeeID
        {
            get { return _EmployeeID; }
        }
        public clsEmployee SelectedEmployeeInfo
        {
            get { return _Employee; }
        }
        public ctrlEmployeeCard()
        {
            InitializeComponent();
        }
        private void _FillEmployeeInfo()
        {
            _EmployeeID = _Employee.EmployeeID;
            ctrlPersonCard1.LoadPersonInfo(_Employee.PersonID);
            llEditEmployeeInfo.Visible = true;
            lblEmployeeID.Text = _Employee.EmployeeID.ToString();
            lblJobName.Text = _Employee.Job;
            lblSponsorName.Text = _Employee.SponsorPersonInfo.FullName;
        }
        public void ResetEmployeeInfo()
        {
            ctrlPersonCard1.ResetPersonInfo();
            llEditEmployeeInfo.Visible = false;
            _EmployeeID = -1;
            _Employee = null;
            lblEmployeeID.Text = "[؟؟؟؟]";
            lblJobName.Text = "[؟؟؟؟]";
            lblSponsorName.Text = "[؟؟؟؟]";
        }
        public void LoadEmployeeInfo(int EmployeeID)
        {
            _Employee = clsEmployee.FindByEmployeeID(EmployeeID);
            if (_Employee == null)
            {
                ResetEmployeeInfo();
                MessageBox.Show("لا يوجد بيانات للموظف بالرقم التعريفي " + EmployeeID.ToString(),
                    "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _FillEmployeeInfo();
        }
        public void LoadEmployeeInfoByPersonID(int PersonID)
        {
            _Employee = clsEmployee.FindByPersonID(PersonID);
            if (_Employee == null)
            {
                ResetEmployeeInfo();
                MessageBox.Show("لا يوجدبيانات لشخص بالرقم التعريفي " + PersonID.ToString(),
                    "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _FillEmployeeInfo();
        }
        private void llEditEmployeeInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmAddUpdateEmployee frm = new frmAddUpdateEmployee(_EmployeeID);
            frm.ShowDialog();
            LoadEmployeeInfo(EmployeeID);
        }
    }
}