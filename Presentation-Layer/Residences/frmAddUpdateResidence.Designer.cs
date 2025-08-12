namespace Presentation_Layer.Residences
{
    partial class frmAddUpdateResidence
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.llAddEditResidencePicture = new System.Windows.Forms.LinkLabel();
            this.pbResidenceImage = new System.Windows.Forms.PictureBox();
            this.label7 = new System.Windows.Forms.Label();
            this.dtpExpirationDate = new System.Windows.Forms.DateTimePicker();
            this.dtpIssueDate = new System.Windows.Forms.DateTimePicker();
            this.cbResidencePeriods = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lblResidenceID = new System.Windows.Forms.Label();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.llRemoveResidenceImage = new System.Windows.Forms.LinkLabel();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.txtResidenceNumber = new System.Windows.Forms.TextBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.cbStatus = new System.Windows.Forms.ComboBox();
            this.ctrlEmployeeCardWithFilter1 = new Presentation_Layer.Employees.Controls.ctrlEmployeeCardWithFilter();
            ((System.ComponentModel.ISupportInitialize)(this.pbResidenceImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Image = global::Presentation_Layer.Properties.Resources.Save32;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.Location = new System.Drawing.Point(15, 621);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(191, 41);
            this.btnSave.TabIndex = 23;
            this.btnSave.Text = "حفظ";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Image = global::Presentation_Layer.Properties.Resources.Close;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.Location = new System.Drawing.Point(15, 670);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(191, 41);
            this.btnClose.TabIndex = 24;
            this.btnClose.Text = "إغلاق";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblTitle.Location = new System.Drawing.Point(12, 7);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(932, 60);
            this.lblTitle.TabIndex = 25;
            this.lblTitle.Text = "إضافة/تعديل إقامة جديدة";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(257, 354);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(154, 21);
            this.label4.TabIndex = 41;
            this.label4.Text = "الرقم التعريفي للإقامة:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(328, 397);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 21);
            this.label1.TabIndex = 41;
            this.label1.Text = "رقم الإقامة:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(326, 440);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 21);
            this.label2.TabIndex = 41;
            this.label2.Text = "مدة الإقامة:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(283, 483);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(128, 21);
            this.label3.TabIndex = 41;
            this.label3.Text = "تاريخ إنشاء الإقامة:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(283, 526);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(128, 21);
            this.label5.TabIndex = 41;
            this.label5.Text = "تاريخ إنتهاء الإقامة:";
            // 
            // llAddEditResidencePicture
            // 
            this.llAddEditResidencePicture.AutoSize = true;
            this.llAddEditResidencePicture.Location = new System.Drawing.Point(276, 69);
            this.llAddEditResidencePicture.Name = "llAddEditResidencePicture";
            this.llAddEditResidencePicture.Size = new System.Drawing.Size(182, 21);
            this.llAddEditResidencePicture.TabIndex = 44;
            this.llAddEditResidencePicture.TabStop = true;
            this.llAddEditResidencePicture.Text = "إضافة\\تعديل صورة الإقامة";
            this.llAddEditResidencePicture.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llAddEditResidencePicture_LinkClicked);
            // 
            // pbResidenceImage
            // 
            this.pbResidenceImage.Image = global::Presentation_Layer.Properties.Resources.ResidenceCard;
            this.pbResidenceImage.Location = new System.Drawing.Point(12, 93);
            this.pbResidenceImage.Name = "pbResidenceImage";
            this.pbResidenceImage.Size = new System.Drawing.Size(395, 242);
            this.pbResidenceImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbResidenceImage.TabIndex = 45;
            this.pbResidenceImage.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(875, 656);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(73, 21);
            this.label7.TabIndex = 46;
            this.label7.Text = "ملاحظات:";
            // 
            // dtpExpirationDate
            // 
            this.dtpExpirationDate.CustomFormat = "yyyy - MM - d";
            this.dtpExpirationDate.Enabled = false;
            this.dtpExpirationDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpExpirationDate.Location = new System.Drawing.Point(16, 522);
            this.dtpExpirationDate.Name = "dtpExpirationDate";
            this.dtpExpirationDate.Size = new System.Drawing.Size(178, 29);
            this.dtpExpirationDate.TabIndex = 47;
            this.dtpExpirationDate.TabStop = false;
            // 
            // dtpIssueDate
            // 
            this.dtpIssueDate.CustomFormat = "yyyy - MM - d";
            this.dtpIssueDate.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.dtpIssueDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpIssueDate.Location = new System.Drawing.Point(16, 479);
            this.dtpIssueDate.Name = "dtpIssueDate";
            this.dtpIssueDate.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dtpIssueDate.Size = new System.Drawing.Size(178, 29);
            this.dtpIssueDate.TabIndex = 47;
            this.dtpIssueDate.ValueChanged += new System.EventHandler(this.dtpIssueDate_ValueChanged);
            // 
            // cbResidencePeriods
            // 
            this.cbResidencePeriods.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbResidencePeriods.FormattingEnabled = true;
            this.cbResidencePeriods.Items.AddRange(new object[] {
            "ثلاثة أشهر",
            "ستة أشهر",
            "تسعة أشهر",
            "سنة",
            "سنة وثلاثة أشهر",
            "سنة وستة أشهر",
            "سنة وتسعة أشهر",
            "سنتان"});
            this.cbResidencePeriods.Location = new System.Drawing.Point(16, 436);
            this.cbResidencePeriods.Name = "cbResidencePeriods";
            this.cbResidencePeriods.Size = new System.Drawing.Size(178, 29);
            this.cbResidencePeriods.TabIndex = 48;
            this.cbResidencePeriods.SelectedIndexChanged += new System.EventHandler(this.cbResidencePeriods_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(325, 569);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(86, 21);
            this.label6.TabIndex = 41;
            this.label6.Text = "حالة الإقامة:";
            // 
            // lblResidenceID
            // 
            this.lblResidenceID.AutoSize = true;
            this.lblResidenceID.Location = new System.Drawing.Point(79, 354);
            this.lblResidenceID.Name = "lblResidenceID";
            this.lblResidenceID.Size = new System.Drawing.Size(52, 21);
            this.lblResidenceID.TabIndex = 42;
            this.lblResidenceID.Text = "[؟؟؟؟]";
            // 
            // txtNotes
            // 
            this.txtNotes.Location = new System.Drawing.Point(222, 621);
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(647, 90);
            this.txtNotes.TabIndex = 43;
            this.txtNotes.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNotes_KeyPress);
            // 
            // llRemoveResidenceImage
            // 
            this.llRemoveResidenceImage.AutoSize = true;
            this.llRemoveResidenceImage.Location = new System.Drawing.Point(8, 69);
            this.llRemoveResidenceImage.Name = "llRemoveResidenceImage";
            this.llRemoveResidenceImage.Size = new System.Drawing.Size(131, 21);
            this.llRemoveResidenceImage.TabIndex = 44;
            this.llRemoveResidenceImage.TabStop = true;
            this.llRemoveResidenceImage.Text = "حذف صورة الإقامة";
            this.llRemoveResidenceImage.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llRemoveResidenceImage_LinkClicked);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // txtResidenceNumber
            // 
            this.txtResidenceNumber.Location = new System.Drawing.Point(14, 393);
            this.txtResidenceNumber.Name = "txtResidenceNumber";
            this.txtResidenceNumber.Size = new System.Drawing.Size(178, 29);
            this.txtResidenceNumber.TabIndex = 50;
            this.txtResidenceNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtResidenceNumber_KeyPress);
            this.txtResidenceNumber.Validating += new System.ComponentModel.CancelEventHandler(this.txtResidenceNumber_Validating);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // cbStatus
            // 
            this.cbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbStatus.FormattingEnabled = true;
            this.cbStatus.Items.AddRange(new object[] {
            "نشطة",
            "غير نشطة",
            "منتهية"});
            this.cbStatus.Location = new System.Drawing.Point(16, 565);
            this.cbStatus.Name = "cbStatus";
            this.cbStatus.Size = new System.Drawing.Size(178, 29);
            this.cbStatus.TabIndex = 48;
            this.cbStatus.SelectedIndexChanged += new System.EventHandler(this.cbStatus_SelectedIndexChanged);
            // 
            // ctrlEmployeeCardWithFilter1
            // 
            this.ctrlEmployeeCardWithFilter1.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ctrlEmployeeCardWithFilter1.BackColor = System.Drawing.Color.White;
            this.ctrlEmployeeCardWithFilter1.FilterEnabled = true;
            this.ctrlEmployeeCardWithFilter1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrlEmployeeCardWithFilter1.Location = new System.Drawing.Point(412, 78);
            this.ctrlEmployeeCardWithFilter1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ctrlEmployeeCardWithFilter1.Name = "ctrlEmployeeCardWithFilter1";
            this.ctrlEmployeeCardWithFilter1.ShowAddEmployee = true;
            this.ctrlEmployeeCardWithFilter1.Size = new System.Drawing.Size(543, 538);
            this.ctrlEmployeeCardWithFilter1.TabIndex = 49;
            // 
            // frmAddUpdateResidence
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(960, 722);
            this.Controls.Add(this.txtResidenceNumber);
            this.Controls.Add(this.llAddEditResidencePicture);
            this.Controls.Add(this.cbStatus);
            this.Controls.Add(this.cbResidencePeriods);
            this.Controls.Add(this.dtpIssueDate);
            this.Controls.Add(this.dtpExpirationDate);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.pbResidenceImage);
            this.Controls.Add(this.llRemoveResidenceImage);
            this.Controls.Add(this.txtNotes);
            this.Controls.Add(this.lblResidenceID);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.ctrlEmployeeCardWithFilter1);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmAddUpdateResidence";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "لوحة إضافة وتعديل بيانات الإقامات";
            this.Activated += new System.EventHandler(this.frmAddUpdateResidence_Activated);
            this.Load += new System.EventHandler(this.frmAddUpdateResidence_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbResidenceImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.LinkLabel llAddEditResidencePicture;
        private System.Windows.Forms.PictureBox pbResidenceImage;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dtpExpirationDate;
        private System.Windows.Forms.DateTimePicker dtpIssueDate;
        private System.Windows.Forms.ComboBox cbResidencePeriods;
        private Employees.Controls.ctrlEmployeeCardWithFilter ctrlEmployeeCardWithFilter1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblResidenceID;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.LinkLabel llRemoveResidenceImage;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox txtResidenceNumber;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.ComboBox cbStatus;
    }
}