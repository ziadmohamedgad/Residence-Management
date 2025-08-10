using Business_Layer;
using Presentation_Layer.People;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Presentation_Layer.Employees
{
    public partial class frmAddUpdateEmployee : Form
    {
        public enum enMode { AddNew = 0, Update = 1, EmployeePerson = 2}
        public enMode Mode;
        private int _EmployeeID = -1;
        private clsEmployee _Employee;
        public int PersonID;
        public frmAddUpdateEmployee()
        {
            InitializeComponent();
            Mode = enMode.AddNew;
        }
        public frmAddUpdateEmployee(int EmployeeID)
        {
            InitializeComponent();
            _EmployeeID = EmployeeID;
            Mode = enMode.Update;
        }
        private void _ResetDefaultValues()
        {
            if (Mode == enMode.AddNew)
            {
                lblTitle.Text = "إضافة موظف جديد";
                lblEmployeeID.Text = "غير معروف";
                this.Text = "لوحة إضافة بيانات الموظف";
                ctrlPersonCardWithFilter1.FilterEnabled = true;
                llChangeSponsor.Text = "اختيار الكفيل";
                _Employee = new clsEmployee();
            }
            else if (Mode == enMode.EmployeePerson)
            {
                lblTitle.Text = "إضافة موظف جديد";
                lblEmployeeID.Text = "غير معروف";
                this.Text = "لوحة إضافة بيانات الموظف";
                llChangeSponsor.Text = "اختيار الكفيل";
                if (clsPerson.Find(PersonID) == null)
                {
                    MessageBox.Show("الرقم التعريفي " + PersonID + " غير مربوط بشخص بالفعل، تأكد من المعلومات مرة أخرى وأعد المحاولة", "خطأ",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    return;
                }
                _Employee = clsEmployee.FindByPersonID(PersonID);
                if (clsEmployee.FindByPersonID(PersonID) != null)
                {
                    MessageBox.Show("هذا الشخص موظف بالفعل بالرقم التعريفي " + _Employee.EmployeeID, "موجود بالفعل",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.Close();
                    return;
                }
                _Employee = new clsEmployee();
                _Employee.PersonID = PersonID;
                ctrlPersonCardWithFilter1.LoadPersonInfo(_Employee.PersonID);
                ctrlPersonCardWithFilter1.FilterEnabled = false;
            }
            else // update mode
            {
                lblTitle.Text = "تعديل بيانات الموظف";
                this.Text = "لوحة تعديل بيانات الموظف";
                llChangeSponsor.Text = "تغيير الكفيل";
                ctrlPersonCardWithFilter1.FilterEnabled = false;
            }
            txtJob.Text = "";
        }
        private void _LoadData()
        {
            _Employee = clsEmployee.FindByEmployeeID(_EmployeeID);    
            if (_Employee == null)
            {
                MessageBox.Show("لا يوجد موظف بالرقم التعريفي " + _EmployeeID,
                    "لم نجد الموظف", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
                return;
            }
            ctrlPersonCardWithFilter1.LoadPersonInfo(_Employee.PersonID);
            ctrlPersonCardWithFilter1.FilterEnabled = false;
            lblEmployeeID.Text = _Employee.EmployeeID.ToString();
            txtJob.Text = _Employee.Job;
            lblSponsorName.Text = _Employee.SponsorPersonInfo.FullName;
        }
        private void frmAddUpdateEmployee_Load(object sender, EventArgs e)
        {
            _ResetDefaultValues();
            if (Mode == enMode.Update)
                _LoadData();
        }
        private void txtJob_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtJob.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtJob, "حقل الوظيفة لا يمكن أن يكون فارغًا!");
            }
            else
                errorProvider1.SetError(txtJob, null);
        }
        private void llChangeSponsor_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmChooseSponsor frm = new frmChooseSponsor();
            frm.DataBack += _DataBack;
            frm.ShowDialog();
        }
        private void _DataBack(int SponsorPersonID)
        {
            llChangeSponsor.Text = "تغيير الكفيل";
            _Employee.SponsorPersonID = SponsorPersonID;
            _Employee.SponsorPersonInfo = clsPerson.Find(SponsorPersonID);
            lblSponsorName.Text = _Employee.SponsorPersonInfo.FullName;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ctrlPersonCardWithFilter1.PersonID == -1)
            {
                MessageBox.Show("لم تقم باختيار أو إنشاء شخص",
                    "خطأ في اكتمال البيانات", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!this.ValidateChildren())
            {
                MessageBox.Show("بعض الحقول ليست صحيحة، قم بوضع الفأرة على النقاط الحمراء لكي تتعرف على الخطأ",
                    "خطأ في التحقق", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (_Employee.SponsorPersonID == -1 && Mode == enMode.AddNew)
            {
                MessageBox.Show("عليك اختيار كفيل أولًا قبل عملية الإكمال",
                    "خطأ في اكتمال البيانات", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (_Employee.PersonID == _Employee.SponsorPersonID)
            {
                MessageBox.Show("عليك تغيير الكفيل، لأن الشخص لا يمكن أن يكفل نفسه", "خطأ في تكامل البيانات",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (Mode == enMode.AddNew || Mode == enMode.EmployeePerson)
            {
                _Employee.PersonID = ctrlPersonCardWithFilter1.PersonID;
                _Employee.PersonInfo = clsPerson.Find(_Employee.PersonID);
            }
            _Employee.Job = txtJob.Text;
            if (clsEmployee.FindByPersonID(_Employee.PersonID) != null && Mode == enMode.AddNew)
            {
                MessageBox.Show("يجب تغيير الشخص لأنه بالفعل موظف بالرقم التعريفي " + _Employee.PersonID, "موظف بالفعل",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                ctrlPersonCardWithFilter1.FilterEnabled = true;
                return;
            }
            if (_Employee.Save())
            {
                lblTitle.Text = "تعديل بيانات الموظف";
                this.Text = "لوحة تعديل بيانات الشخص";
                llChangeSponsor.Text = "تغيير الكفيل";
                ctrlPersonCardWithFilter1.FilterEnabled = false;
                lblEmployeeID.Text = _Employee.EmployeeID.ToString();
                Mode = enMode.Update;
                MessageBox.Show("تم حفظ البيانات بنجاح.", "تم الحفظ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("خطأ في حفظ البيانات", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void frmAddUpdateEmployee_Activated(object sender, EventArgs e)
        {
            switch(Mode)
            {
                case enMode.AddNew:
                    {
                        ctrlPersonCardWithFilter1.FilterFocus();
                        break;
                    }
                case enMode.EmployeePerson:
                case enMode.Update:
                    {
                        txtJob.Focus();
                        break;
                    }
            }
        }
    }
}