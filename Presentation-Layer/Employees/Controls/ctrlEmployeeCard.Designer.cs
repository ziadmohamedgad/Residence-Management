namespace Presentation_Layer.Employees.Controls
{
    partial class ctrlEmployeeCard
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblSponsorName = new System.Windows.Forms.Label();
            this.lblJobName = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.llEditEmployeeInfo = new System.Windows.Forms.LinkLabel();
            this.lblEmployeeID = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ctrlPersonCard1 = new Presentation_Layer.People.Controls.ctrlPersonCard();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblSponsorName
            // 
            this.lblSponsorName.AutoSize = true;
            this.lblSponsorName.Location = new System.Drawing.Point(250, 139);
            this.lblSponsorName.Name = "lblSponsorName";
            this.lblSponsorName.Size = new System.Drawing.Size(52, 21);
            this.lblSponsorName.TabIndex = 35;
            this.lblSponsorName.Text = "[؟؟؟؟]";
            // 
            // lblJobName
            // 
            this.lblJobName.AutoSize = true;
            this.lblJobName.Location = new System.Drawing.Point(250, 94);
            this.lblJobName.Name = "lblJobName";
            this.lblJobName.Size = new System.Drawing.Size(52, 21);
            this.lblJobName.TabIndex = 36;
            this.lblJobName.Text = "[؟؟؟؟]";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(442, 139);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 21);
            this.label4.TabIndex = 33;
            this.label4.Text = "اسم الكفيل:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(462, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 21);
            this.label2.TabIndex = 34;
            this.label2.Text = "الوظيفة:";
            // 
            // llEditEmployeeInfo
            // 
            this.llEditEmployeeInfo.AutoSize = true;
            this.llEditEmployeeInfo.Location = new System.Drawing.Point(10, 28);
            this.llEditEmployeeInfo.Name = "llEditEmployeeInfo";
            this.llEditEmployeeInfo.Size = new System.Drawing.Size(149, 21);
            this.llEditEmployeeInfo.TabIndex = 37;
            this.llEditEmployeeInfo.TabStop = true;
            this.llEditEmployeeInfo.Text = "تعديل بيانات الموظف";
            this.llEditEmployeeInfo.Visible = false;
            this.llEditEmployeeInfo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llEditEmployeeInfo_LinkClicked);
            // 
            // lblEmployeeID
            // 
            this.lblEmployeeID.AutoSize = true;
            this.lblEmployeeID.Location = new System.Drawing.Point(250, 49);
            this.lblEmployeeID.Name = "lblEmployeeID";
            this.lblEmployeeID.Size = new System.Drawing.Size(52, 21);
            this.lblEmployeeID.TabIndex = 39;
            this.lblEmployeeID.Text = "[؟؟؟؟]";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(360, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(167, 21);
            this.label3.TabIndex = 38;
            this.label3.Text = "الرقم التعريفي للموظف:";
            // 
            // ctrlPersonCard1
            // 
            this.ctrlPersonCard1.BackColor = System.Drawing.Color.White;
            this.ctrlPersonCard1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.ctrlPersonCard1.Location = new System.Drawing.Point(4, 5);
            this.ctrlPersonCard1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ctrlPersonCard1.Name = "ctrlPersonCard1";
            this.ctrlPersonCard1.Size = new System.Drawing.Size(533, 221);
            this.ctrlPersonCard1.TabIndex = 32;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.llEditEmployeeInfo);
            this.groupBox1.Controls.Add(this.lblEmployeeID);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.lblJobName);
            this.groupBox1.Controls.Add(this.lblSponsorName);
            this.groupBox1.Location = new System.Drawing.Point(4, 234);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(530, 181);
            this.groupBox1.TabIndex = 40;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "معلومات الموظف";
            // 
            // ctrlEmployeeCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ctrlPersonCard1);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "ctrlEmployeeCard";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(543, 424);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblSponsorName;
        private System.Windows.Forms.Label lblJobName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private People.Controls.ctrlPersonCard ctrlPersonCard1;
        private System.Windows.Forms.LinkLabel llEditEmployeeInfo;
        private System.Windows.Forms.Label lblEmployeeID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}
