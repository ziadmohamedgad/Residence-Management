using Business_Layer;
using Presentation_Layer.Global_Classes;
using Presentation_Layer.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Shared_Layer;
using System.Runtime.CompilerServices;
namespace Presentation_Layer.Residences
{
    public partial class frmAddUpdateResidence : Form
    {
        public delegate void DataBackEventHandler(int ResidenceID);
        public event DataBackEventHandler DataBack;
        public enum enMode { AddNew = 0, Update = 1, CreateEmployeeResidence = 2};
        public enMode Mode;
        private int _ResidenceID = -1;
        public int EmployeeID = -1;
        private clsResidence _Residence;
        public frmAddUpdateResidence(int ResidenceID)
        {
            InitializeComponent();
            _ResidenceID = ResidenceID;
            Mode = enMode.Update;
        }
        public frmAddUpdateResidence()
        {
            InitializeComponent();
            Mode = enMode.AddNew;
        }
        private void _ResetDefaultValues()
        {
            if (Mode == enMode.Update)
            {
                lblTitle.Text = "تعديل بيانات الإقامة";
                this.Text = "لوحة تعديل بيانات الإقامة";
                ctrlEmployeeCardWithFilter1.FilterEnabled = false;
                llAddEditResidencePicture.Text = pbResidenceImage.ImageLocation == null ? "إضافة صورة الإقامة" : "تغيير صورة الإقامة";
                llRemoveResidenceImage.Visible = pbResidenceImage.ImageLocation != null;
                return;
            }
            if (Mode == enMode.AddNew)
            {
                ctrlEmployeeCardWithFilter1.FilterEnabled = true;
                _Residence = new clsResidence();
            }
            if (Mode == enMode.CreateEmployeeResidence)
            {
                if (clsEmployee.FindByEmployeeID(EmployeeID) == null)
                {
                    MessageBox.Show("الرقم التعريفي " + EmployeeID + " غير مربوط بموظف بالفعل، تأكد من المعلومات مرة أخرى وأعد المحاولة", "خطأ",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    return;
                }
                _Residence = clsResidence.FindByEmployeeID(EmployeeID);
                if (_Residence == null)
                {
                    MessageBox.Show("هذا الموظف له إقامة بالفعل بالرقم التعريفي " + _Residence.ResidenceID , "موجود بالفعل",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.Close();
                    return;
                }
                _Residence = new clsResidence();
                _Residence.EmployeeID = EmployeeID;
                ctrlEmployeeCardWithFilter1.LoadEmployeeInfo(EmployeeID);
                ctrlEmployeeCardWithFilter1.FilterEnabled = false;
            }
            lblTitle.Text = "إضافة إقامة جديدة";
            this.Text = "لوحة إضافة بيانات الإقامة";
            llAddEditResidencePicture.Text = "إضافة صورة الإقامة";
            llRemoveResidenceImage.Visible = false;
            pbResidenceImage.Image = Resources.ResidenceCard;
            lblResidenceID.Text = "[؟؟؟؟]";
            lblResidenceNumber.Text = "[؟؟؟؟]";
            cbResidencePeriods.SelectedIndex = 0;
            dtpIssueDate.Value = DateTime.Now;
            dtpExpirationDate.Value = DateTime.Now.AddMonths(3); // the default value of the cbPeriods is 3 months
            lblStatus.Text = "[؟؟؟؟]";
            txtNotes.Text = "";
        }
        private void _LoadData()
        {
            _Residence = clsResidence.FindByResidenceID(_ResidenceID);
            if (_Residence == null)
            {
                MessageBox.Show("لا يوجد إقامة بالرقم التعريفي " + _ResidenceID, 
                    "لم نجد الإقامة", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
                return;
            }
            ctrlEmployeeCardWithFilter1.LoadEmployeeInfo(_Residence.EmployeeID);
            ctrlEmployeeCardWithFilter1.FilterEnabled = false;
            if (_Residence.ImageName == "")
            {
                pbResidenceImage.Image = Resources.ResidenceCard;
                llAddEditResidencePicture.Text = "إضافة صورة الإقامة";
                llRemoveResidenceImage.Visible = false;
            }
            else
            {
                pbResidenceImage.ImageLocation = clsUtility.GetDestinationImagesFolderDynamically() + '\\' + _Residence.ImageName;
                llAddEditResidencePicture.Text = "تغيير صورة الإقامة";
                llAddEditResidencePicture.Visible = true;
            }
            lblResidenceID.Text = _Residence.ResidenceID.ToString();
            lblResidenceNumber.Text = _Residence.ResidenceNumber;
            cbResidencePeriods.SelectedIndex = GetCbPeriodsSelectedIndex();
            dtpIssueDate.Value = _Residence.IssueDate;
            dtpExpirationDate.Value = _Residence.ExpirationDate;
            lblStatus.Text = dtpExpirationDate.Value < DateTime.Now ? "منتهية" : _Residence.IsActive ? "نشطة" : "غير نشطة";
            txtNotes.Text = _Residence.Notes;
        }
        private byte GetCbPeriodsSelectedIndex()
        {
            switch (_Residence.ResidencePeriod)
            {
                case clsResidence.enResidencePeriod.Three:
                    return 0;
                case clsResidence.enResidencePeriod.Six:
                    return 1;
                case clsResidence.enResidencePeriod.Nine:
                    return 2;
                case clsResidence.enResidencePeriod.Twelve:
                    return 3;
                case clsResidence.enResidencePeriod.Fifteen:
                    return 4;
                case clsResidence.enResidencePeriod.Eighteen:
                    return 5;
                case clsResidence.enResidencePeriod.TwentyOne:
                    return 6;
                case clsResidence.enResidencePeriod.TwentyFour:
                    return 7;
                default:
                    return 0;
            }
        }
        private void frmAddUpdateResidence_Load(object sender, EventArgs e)
        {
            _ResetDefaultValues();
            if (Mode == enMode.Update)
                _LoadData();
        }
        private void txtNotes_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Back)
            {
                e.Handled = false;
            }
            else if (txtNotes.Text.Length >= 500)
            {
                e.Handled = true;
                MessageBox.Show("لا يمكن تخزين ملاحظات طولها أكثر من 500 حرف", "خطأ",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void llRemoveResidenceImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pbResidenceImage.ImageLocation = null;
            pbResidenceImage.Image = Resources.ResidenceCard;
            llRemoveResidenceImage.Visible = false;
            llAddEditResidencePicture.Text = "إضافة صورة الإقامة";
        }
        private void llAddEditResidencePicture_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pbResidenceImage.ImageLocation = openFileDialog1.FileName;
                llAddEditResidencePicture.Text = "تغيير صورة الإقامة";
                llRemoveResidenceImage.Visible = true;
            }
        }
        private bool _HandleResidenceImage()
        {
            string _ResidenceImagePath = clsUtility.GetDestinationImagesFolderDynamically() + '\\' + _Residence.ImageName;
            if (_ResidenceImagePath != pbResidenceImage.ImageLocation) // this means there is a change  made (even deleting old one, or add new, or change the old one)
            {
                // maybe the current Picture Box is null, but there was an a differ with the _Residence.Image,
                // because there was an old stored image so we just need to delete the old image 

                if (_Residence.ImageName != "") // this means there was an old image, so we need to delete
                {
                    // we here need to delete the old image, because there is already a cange made
                    if (File.Exists(_ResidenceImagePath))
                    {
                        string SecuredImagePath = @"C:\Residences Management\Images\" + _Residence.ImageName;
                        try
                        {
                            File.Delete(_ResidenceImagePath);
                            File.Delete(SecuredImagePath);
                        }
                        catch(IOException iox)
                        {
                            MessageBox.Show("حدث خطأ أثناء مسح الصورة القديمة بالمسار التالي:" + _ResidenceImagePath, "خطأ",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                            clsEventLogger.SaveLog("Application", $"Error deleting the old phone: {iox.Message}",
                                System.Diagnostics.EventLogEntryType.Error);
                            return false;
                        }
                    }
                }
                // but what if the current Picture Box is not null, and there is a new image, anyway the old image deleted above if there was,
                // now we have to proceed to save the new image
                if (pbResidenceImage.ImageLocation != null)
                {
                    string SourceImageFile = pbResidenceImage.ImageLocation.ToString();
                    if (File.Exists(SourceImageFile)) //extra validating because maybe moved or deleted the new picture after uploading it
                    {
                        if (clsUtility.CopyImageToProjectImagesFolder(ref SourceImageFile))
                        {
                            pbResidenceImage.ImageLocation = SourceImageFile;
                            return true;
                        }
                        else
                        {
                            MessageBox.Show("حدث خطأ أثناء نسخ الصورة لملفات البرنامج", "خطأ في النسخ", 
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }
                    else
                    {
                        MessageBox.Show("الصورة التي قمت برفعها حُذفت أو نُقلت من مكانها قبل تأكيد حفظ البيانات، حاول أن تختار الصورة مرة أخرى",
                            "خطأ في الحصول على الصورة", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
            }
            return true;
        }
        private clsResidence.enResidencePeriod GetResidencePeriod()
        {
            switch(cbResidencePeriods.SelectedIndex)
            {
                case 0:
                    return clsResidence.enResidencePeriod.Three;
                case 1:
                    return clsResidence.enResidencePeriod.Six;
                case 2:
                    return clsResidence.enResidencePeriod.Nine;
                case 3:
                    return clsResidence.enResidencePeriod.Twelve;
                case 4:
                    return clsResidence.enResidencePeriod.Fifteen;
                case 5:
                    return clsResidence.enResidencePeriod.Eighteen;
                case 6:
                    return clsResidence.enResidencePeriod.TwentyOne;
                case 7:
                    return clsResidence.enResidencePeriod.TwentyFour;
                default:
                    return clsResidence.enResidencePeriod.Three;
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ctrlEmployeeCardWithFilter1.EmployeeID == -1)
            {
                MessageBox.Show("لم تقم باختيار أو إنشاء موظف","خطأ في اكتمال اليبانات", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ctrlEmployeeCardWithFilter1.FilterEnabled = true;
                return;
            }
            if (!_HandleResidenceImage())
            {
                MessageBox.Show("حدثت أخطاء أثناء عملية معالجة وحفظ صورة الإقامة", "خطأ",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (Mode == enMode.AddNew || Mode == enMode.CreateEmployeeResidence)
            {
                _Residence.EmployeeID = ctrlEmployeeCardWithFilter1.EmployeeID;
                _Residence.EmployeeInfo = clsEmployee.FindByEmployeeID(_Residence.EmployeeID);
            }
            if (clsResidence.FindByEmployeeID(_Residence.EmployeeID) != null)
            {
                if (Mode == enMode.AddNew || Mode == enMode.CreateEmployeeResidence)
                {
                    MessageBox.Show("هذا الموظف بالفعل لديه إقامة بالرقم التعريفي " + _Residence.ResidenceID,
                        "الإقامة موجودة بالفعل", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    ctrlEmployeeCardWithFilter1.FilterEnabled = true;
                    return;
                }
            }
            _Residence.ResidenceNumber = lblResidenceNumber.Text;
            _Residence.ResidencePeriod = GetResidencePeriod();
            _Residence.IssueDate = dtpIssueDate.Value;
            _Residence.ExpirationDate = dtpExpirationDate.Value;
            if (pbResidenceImage.ImageLocation != null)
                _Residence.ImageName = Path.GetFileName(pbResidenceImage.ImageLocation);
            else
                _Residence.ImageName = "";
                _Residence.IsActive = lblStatus.Text == "منتهية" || lblStatus.Text == "غير نشطة" ? false : true;
            _Residence.Notes = txtNotes.Text;
            _Residence.EmployeeID = ctrlEmployeeCardWithFilter1.EmployeeID;
            if (_Residence.Save())
            {
                lblTitle.Text = "تعديل بيانات الإقامة";
                this.Text = "لوحة تعديل بيانات الإقامة";
                ctrlEmployeeCardWithFilter1.FilterEnabled = false;
                llAddEditResidencePicture.Text = pbResidenceImage.ImageLocation == null ? "إضافة صورة الإقامة" : "تغيير صورة الإقامة";
                llRemoveResidenceImage.Visible = pbResidenceImage.ImageLocation != null;
                lblResidenceID.Text = _Residence.ResidenceID.ToString();
                Mode = enMode.Update;
                MessageBox.Show("تم حفظ البيانات بنجاح.", "تم الحفظ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DataBack?.Invoke(_Residence.ResidenceID);
            }
            else
                MessageBox.Show("خطأ في حفظ البيانات", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void frmAddUpdateResidence_Activated(object sender, EventArgs e)
        {
            if (Mode == enMode.AddNew || Mode == enMode.CreateEmployeeResidence)
                ctrlEmployeeCardWithFilter1.FilterFocus();
        }
        private void dtpIssueDate_ValueChanged(object sender, EventArgs e)
        {
            // here we will add the period to the data and calc the expiration data, then we well judge the activation status
        }
    }
}