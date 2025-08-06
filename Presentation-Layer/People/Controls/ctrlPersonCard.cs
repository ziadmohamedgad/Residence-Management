using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business_Layer;
namespace Presentation_Layer.People.Controls
{
    public partial class ctrlPersonCard : UserControl
    {
        private int _PersonID = -1;
        private clsPerson _Person;
        public int PersonID
        {
            get { return _PersonID; }
        }
        public clsPerson SelectedPersonInfo
        {
            get { return _Person; }
        }
        public ctrlPersonCard()
        {
            InitializeComponent();
        }
        private void _FillPersonInfo()
        {
            llEditPersonInfo.Visible = true;
            _PersonID = _Person.PersonID;
            lblPersonID.Text = _Person.PersonID.ToString();
            lblFullName.Text = _Person.FullName;
            lblPhone.Text = _Person.Phone.ToString();
        }
        public void ResetPersonInfo()
        {
            llEditPersonInfo.Visible = false;
            _PersonID = -1;
            _Person = null;
            lblPersonID.Text = "[؟؟؟؟]";
            lblFullName.Text = "[؟؟؟؟]";
            lblPhone.Text = "[؟؟؟؟]";
        }
        public void LoadPersonInfo(int PersonID)
        {
            _Person = clsPerson.Find(PersonID);
            if (_Person == null)
            {
                ResetPersonInfo();
                MessageBox.Show("لا يوجد بيانات للشخص بالرقم التعريفي " + PersonID.ToString(), 
                    "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _FillPersonInfo();
        }
        private void llEditPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmAddUpdatePerson frm = new frmAddUpdatePerson(_PersonID);
            frm.ShowDialog();
            LoadPersonInfo(_PersonID);
        }
    }
}