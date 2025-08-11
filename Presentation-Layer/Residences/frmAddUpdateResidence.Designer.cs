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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAddUpdateResidence));
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
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.ctrlEmployeeCardWithFilter1 = new Presentation_Layer.Employees.Controls.ctrlEmployeeCardWithFilter();
            this.lblResidenceNumber = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblResidenceID = new System.Windows.Forms.Label();
            this.txtNotes = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbResidenceImage)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Image = global::Presentation_Layer.Properties.Resources.Save32;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.Location = new System.Drawing.Point(12, 621);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(178, 41);
            this.btnSave.TabIndex = 23;
            this.btnSave.Text = "حفظ";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Image = global::Presentation_Layer.Properties.Resources.Close;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.Location = new System.Drawing.Point(12, 670);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(178, 41);
            this.btnClose.TabIndex = 24;
            this.btnClose.Text = "إغلاق";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblTitle.Location = new System.Drawing.Point(12, 7);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(929, 60);
            this.lblTitle.TabIndex = 25;
            this.lblTitle.Text = "إضافة إقامة جديدة";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(238, 354);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(154, 21);
            this.label4.TabIndex = 41;
            this.label4.Text = "الرقم التعريفي للإقامة:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(309, 397);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 21);
            this.label1.TabIndex = 41;
            this.label1.Text = "رقم الإقامة:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(307, 440);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 21);
            this.label2.TabIndex = 41;
            this.label2.Text = "مدة الإقامة:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(264, 483);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(128, 21);
            this.label3.TabIndex = 41;
            this.label3.Text = "تاريخ إنشاء الإقامة:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(264, 526);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(128, 21);
            this.label5.TabIndex = 41;
            this.label5.Text = "تاريخ إنتهاء الإقامة:";
            // 
            // llAddEditResidencePicture
            // 
            this.llAddEditResidencePicture.AutoSize = true;
            this.llAddEditResidencePicture.Location = new System.Drawing.Point(12, 69);
            this.llAddEditResidencePicture.Name = "llAddEditResidencePicture";
            this.llAddEditResidencePicture.Size = new System.Drawing.Size(182, 21);
            this.llAddEditResidencePicture.TabIndex = 44;
            this.llAddEditResidencePicture.TabStop = true;
            this.llAddEditResidencePicture.Text = "إضافة\\تعديل صورة الإقامة";
            // 
            // pbResidenceImage
            // 
            this.pbResidenceImage.Image = ((System.Drawing.Image)(resources.GetObject("pbResidenceImage.Image")));
            this.pbResidenceImage.Location = new System.Drawing.Point(12, 93);
            this.pbResidenceImage.Name = "pbResidenceImage";
            this.pbResidenceImage.Size = new System.Drawing.Size(393, 242);
            this.pbResidenceImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbResidenceImage.TabIndex = 45;
            this.pbResidenceImage.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(868, 656);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(73, 21);
            this.label7.TabIndex = 46;
            this.label7.Text = "ملاحظات:";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(26, 522);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 29);
            this.dateTimePicker1.TabIndex = 47;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(26, 479);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(200, 29);
            this.dateTimePicker2.TabIndex = 47;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "ثلاثة أشهر",
            "ستة أشهر",
            "تسعة أشهر",
            "سنة",
            "سنة وثلاثة أشهر",
            "سنة وستة أشهر",
            "سنة وتسعة أشهر",
            "سنتان"});
            this.comboBox1.Location = new System.Drawing.Point(26, 436);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(200, 29);
            this.comboBox1.TabIndex = 48;
            // 
            // ctrlEmployeeCardWithFilter1
            // 
            this.ctrlEmployeeCardWithFilter1.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ctrlEmployeeCardWithFilter1.BackColor = System.Drawing.Color.White;
            this.ctrlEmployeeCardWithFilter1.FilterEnabled = true;
            this.ctrlEmployeeCardWithFilter1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrlEmployeeCardWithFilter1.Location = new System.Drawing.Point(407, 78);
            this.ctrlEmployeeCardWithFilter1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ctrlEmployeeCardWithFilter1.Name = "ctrlEmployeeCardWithFilter1";
            this.ctrlEmployeeCardWithFilter1.ShowAddEmployee = true;
            this.ctrlEmployeeCardWithFilter1.Size = new System.Drawing.Size(543, 538);
            this.ctrlEmployeeCardWithFilter1.TabIndex = 49;
            // 
            // lblResidenceNumber
            // 
            this.lblResidenceNumber.AutoSize = true;
            this.lblResidenceNumber.Location = new System.Drawing.Point(100, 397);
            this.lblResidenceNumber.Name = "lblResidenceNumber";
            this.lblResidenceNumber.Size = new System.Drawing.Size(52, 21);
            this.lblResidenceNumber.TabIndex = 42;
            this.lblResidenceNumber.Text = "[؟؟؟؟]";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(306, 569);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(86, 21);
            this.label6.TabIndex = 41;
            this.label6.Text = "حالة الإقامة:";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(100, 569);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(52, 21);
            this.lblStatus.TabIndex = 42;
            this.lblStatus.Text = "[؟؟؟؟]";
            // 
            // lblResidenceID
            // 
            this.lblResidenceID.AutoSize = true;
            this.lblResidenceID.Location = new System.Drawing.Point(100, 354);
            this.lblResidenceID.Name = "lblResidenceID";
            this.lblResidenceID.Size = new System.Drawing.Size(52, 21);
            this.lblResidenceID.TabIndex = 42;
            this.lblResidenceID.Text = "[؟؟؟؟]";
            // 
            // txtNotes
            // 
            this.txtNotes.Location = new System.Drawing.Point(214, 621);
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(648, 90);
            this.txtNotes.TabIndex = 43;
            this.txtNotes.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtNotes.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNotes_KeyPress);
            // 
            // frmAddUpdateResidence
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(953, 722);
            this.Controls.Add(this.ctrlEmployeeCardWithFilter1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.pbResidenceImage);
            this.Controls.Add(this.llAddEditResidencePicture);
            this.Controls.Add(this.txtNotes);
            this.Controls.Add(this.lblResidenceID);
            this.Controls.Add(this.lblResidenceNumber);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClose);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmAddUpdateResidence";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "لوحة إضافة وتعديل بيانات الإقامات";
            ((System.ComponentModel.ISupportInitialize)(this.pbResidenceImage)).EndInit();
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
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.ComboBox comboBox1;
        private Employees.Controls.ctrlEmployeeCardWithFilter ctrlEmployeeCardWithFilter1;
        private System.Windows.Forms.Label lblResidenceNumber;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblResidenceID;
        private System.Windows.Forms.TextBox txtNotes;
    }
}