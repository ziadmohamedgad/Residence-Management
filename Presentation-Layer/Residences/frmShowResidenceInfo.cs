using Business_Layer;
using Presentation_Layer.Global_Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Presentation_Layer.Residences
{
    public partial class frmShowResidenceInfo : Form
    {
        private int _ResidenceID = -1;
        private clsResidence _Residence;
        public frmShowResidenceInfo(int ResidenceID)
        {
            InitializeComponent();
            this._ResidenceID = ResidenceID;
            _Residence = clsResidence.FindByResidenceID(ResidenceID);
            if (_Residence == null)
            {
                MessageBox.Show("لا يوجد إقامة بالرقم التعريفي " +  ResidenceID,
                    "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }
            else
                _FillData();
        }
        private void _LoadImage()
        {
            string ImageNameWithExt = _Residence.ImageName;
            string Path = clsUtility.GetDestinationImagesFolderDynamically();
            string FullImagePath = Path + "\\" + ImageNameWithExt;
            if (File.Exists(FullImagePath))
                pbResidence.ImageLocation = FullImagePath;
            else
                MessageBox.Show("لم نستطع أن نصل لصورة الإقامة في المسار " +  FullImagePath, "فشل الحصول على الصورة",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void _FillData()
        {
            lblResidenceID.Text = _Residence.ResidenceID.ToString();
            lblEmployeeFullName.Text = _Residence.EmployeeInfo.PersonInfo.FullName;
            lblJob.Text = _Residence.EmployeeInfo.Job;
            lblResidenceNumber.Text = _Residence.ResidenceNumber;
            lblIssueDate.Text = _Residence.IssueDate.ToString("yyyy - MM - d");
            lblExpirationDate.Text = _Residence.ExpirationDate.ToString("yyyy - MM - d");
            lblStatus.Text = _Residence.IsActive ? "نشطة" : "غير نشطة";
            lblNotes.Text = _Residence.Notes;
            if (_Residence.ImageName != "")
                _LoadImage();      
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void lleditResidenceInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmAddUpdateResidence frm = new frmAddUpdateResidence(this._ResidenceID);
            frm.ShowDialog();
            _Residence = clsResidence.FindByResidenceID(_ResidenceID);
            if (_Residence == null)
            {
                MessageBox.Show("لا يوجد إقامة بالرقم التعريفي " + _ResidenceID,
                    "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }
            else
                _FillData();
        }
    }
}