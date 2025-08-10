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
namespace Presentation_Layer.People
{
    public partial class frmAddUpdatePerson : Form
    {
        public delegate void DataBackEventHandler(int PersonID);
        public event DataBackEventHandler DataBack;
        public enum enMode { AddNew = 0, Update = 1 }
        private enMode _Mode;
        private int _PersonID = -1;
        private clsPerson _Person;
        public frmAddUpdatePerson()
        {
            InitializeComponent();
            _Mode = enMode.AddNew;
        }
        public frmAddUpdatePerson(int PersonID)
        {
            InitializeComponent();
            this._PersonID = PersonID;
            _Mode = enMode.Update;
        }
        private void _ResetDefaultValues()
        {
            if (_Mode == enMode.AddNew)
            {
                lblTitle.Text = "إضافة شخص جديد";
                lblPersonID.Text = "غير معروف";
                this.Text = "لوحة إضافة بيانات الشخص";
                _Person = new clsPerson();
            }
            else
            {
                lblTitle.Text = "تعديل بيانات الشخص";
                this.Text = "لوحة تعديل بيانات الشخص";
            }
            txtFirstName.Text = "";
            txtSecondName.Text = "";
            txtThirdName.Text = "";
            txtLastName.Text = "";
            txtPhone.Text = "";
        }
        private void _LoadData()
        {
            _Person = clsPerson.Find(_PersonID);
            if (_Person == null)
            {
                MessageBox.Show("لا يوجد شخص بالرقم التعريفي " + _PersonID,
                    "لم نجد الشخص", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
                return;
            }
            lblPersonID.Text = _Person.PersonID.ToString();
            txtFirstName.Text = _Person.FirstName;
            txtSecondName.Text = _Person.SecondName;
            txtThirdName.Text = _Person.ThirdName;
            txtLastName.Text = _Person.LastName;
            txtPhone.Text = _Person.Phone;
        }
        private void _ValidateEmptyTextBox(object sender, CancelEventArgs e)
        {
            TextBox Temp = (TextBox)sender;
            if (string.IsNullOrEmpty(Temp.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(Temp, "هذا الحقل لا يمكن أن يكون فارغا!");
            }
            else
                errorProvider1.SetError(Temp, null);
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("بعض الحقول ليست صحيحة، قم بوضع الفأرة على النقاط الحمراء لكي تتعرف على الخطأ",
                    "خطأ في التحقق", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _Person.FirstName = txtFirstName.Text.Trim();
            _Person.SecondName = txtSecondName.Text.Trim();
            _Person.ThirdName = txtThirdName.Text.Trim();
            _Person.LastName = txtLastName.Text.Trim();
            _Person.Phone = txtPhone.Text.Trim();
            if (_Person.Save())
            {
                lblTitle.Text = "تعديل بيانات الشخص";
                this.Text = "لوحة تعديل بيانات الشخص";
                lblPersonID.Text = _Person.PersonID.ToString();
                _Mode = enMode.Update;
                MessageBox.Show("تم حفظ البيانات بنجاح.", "تم الحفظ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DataBack?.Invoke(_Person.PersonID);
                this.Close();
                return;
            }
            else
                MessageBox.Show("خطأ في حفظ البيانات", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void frmAddUpdatePerson_Load(object sender, EventArgs e)
        {
            _ResetDefaultValues();
            if (_Mode == enMode.Update)
                _LoadData();
        }
    }
}