namespace Presentation_Layer.Employees
{
    partial class frmListEmployees
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmListEmployees));
            this.btnClose = new System.Windows.Forms.Button();
            this.btnAddEmployee = new System.Windows.Forms.Button();
            this.lblRecordsCount = new System.Windows.Forms.Label();
            this.lblRecords = new System.Windows.Forms.Label();
            this.txtFilterValue = new System.Windows.Forms.TextBox();
            this.lblManagePeople = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.cbFilterBy = new System.Windows.Forms.ComboBox();
            this.dgvEmployees = new System.Windows.Forms.DataGridView();
            this.cmsEmployees = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.showResidenceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.createResidenceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblFilterBy = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployees)).BeginInit();
            this.cmsEmployees.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::Presentation_Layer.Properties.Resources.Close;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnClose.Location = new System.Drawing.Point(14, 677);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(133, 45);
            this.btnClose.TabIndex = 32;
            this.btnClose.Text = "إغلاق";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnAddEmployee
            // 
            this.btnAddEmployee.Image = global::Presentation_Layer.Properties.Resources.AddEmployee;
            this.btnAddEmployee.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnAddEmployee.Location = new System.Drawing.Point(13, 259);
            this.btnAddEmployee.Name = "btnAddEmployee";
            this.btnAddEmployee.Size = new System.Drawing.Size(107, 54);
            this.btnAddEmployee.TabIndex = 31;
            this.btnAddEmployee.UseVisualStyleBackColor = true;
            this.btnAddEmployee.Click += new System.EventHandler(this.btnAddEmployee_Click);
            // 
            // lblRecordsCount
            // 
            this.lblRecordsCount.AutoSize = true;
            this.lblRecordsCount.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecordsCount.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblRecordsCount.Location = new System.Drawing.Point(737, 689);
            this.lblRecordsCount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRecordsCount.Name = "lblRecordsCount";
            this.lblRecordsCount.Size = new System.Drawing.Size(26, 21);
            this.lblRecordsCount.TabIndex = 30;
            this.lblRecordsCount.Text = "؟؟";
            // 
            // lblRecords
            // 
            this.lblRecords.AutoSize = true;
            this.lblRecords.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecords.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblRecords.Location = new System.Drawing.Point(769, 689);
            this.lblRecords.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRecords.Name = "lblRecords";
            this.lblRecords.Size = new System.Drawing.Size(106, 21);
            this.lblRecords.TabIndex = 29;
            this.lblRecords.Text = "عدد الموظفين:";
            // 
            // txtFilterValue
            // 
            this.txtFilterValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFilterValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtFilterValue.Location = new System.Drawing.Point(173, 275);
            this.txtFilterValue.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtFilterValue.Name = "txtFilterValue";
            this.txtFilterValue.Size = new System.Drawing.Size(356, 26);
            this.txtFilterValue.TabIndex = 28;
            this.txtFilterValue.Visible = false;
            this.txtFilterValue.TextChanged += new System.EventHandler(this.txtFilterValue_TextChanged);
            this.txtFilterValue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFilterValue_KeyPress);
            // 
            // lblManagePeople
            // 
            this.lblManagePeople.AutoSize = true;
            this.lblManagePeople.Font = new System.Drawing.Font("Segoe UI Semibold", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblManagePeople.ForeColor = System.Drawing.Color.DarkRed;
            this.lblManagePeople.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblManagePeople.Location = new System.Drawing.Point(364, 201);
            this.lblManagePeople.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblManagePeople.Name = "lblManagePeople";
            this.lblManagePeople.Size = new System.Drawing.Size(161, 47);
            this.lblManagePeople.TabIndex = 27;
            this.lblManagePeople.Text = "الموظفين";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Presentation_Layer.Properties.Resources.Employees;
            this.pictureBox1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pictureBox1.Location = new System.Drawing.Point(259, 12);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(364, 184);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 26;
            this.pictureBox1.TabStop = false;
            // 
            // cbFilterBy
            // 
            this.cbFilterBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilterBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.cbFilterBy.FormattingEnabled = true;
            this.cbFilterBy.Items.AddRange(new object[] {
            "لاشيء",
            "الرقم التعريفي",
            "الاسم",
            "اسم الكفيل",
            "الوظيفة"});
            this.cbFilterBy.Location = new System.Drawing.Point(537, 273);
            this.cbFilterBy.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbFilterBy.Name = "cbFilterBy";
            this.cbFilterBy.Size = new System.Drawing.Size(254, 28);
            this.cbFilterBy.TabIndex = 25;
            this.cbFilterBy.SelectedIndexChanged += new System.EventHandler(this.cbFilterBy_SelectedIndexChanged);
            // 
            // dgvEmployees
            // 
            this.dgvEmployees.AllowUserToAddRows = false;
            this.dgvEmployees.AllowUserToDeleteRows = false;
            this.dgvEmployees.AllowUserToResizeRows = false;
            this.dgvEmployees.BackgroundColor = System.Drawing.Color.White;
            this.dgvEmployees.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEmployees.ContextMenuStrip = this.cmsEmployees;
            this.dgvEmployees.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvEmployees.Location = new System.Drawing.Point(14, 317);
            this.dgvEmployees.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.dgvEmployees.MultiSelect = false;
            this.dgvEmployees.Name = "dgvEmployees";
            this.dgvEmployees.ReadOnly = true;
            this.dgvEmployees.RowTemplate.Height = 25;
            this.dgvEmployees.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEmployees.Size = new System.Drawing.Size(854, 349);
            this.dgvEmployees.TabIndex = 24;
            this.dgvEmployees.TabStop = false;
            this.dgvEmployees.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvEmployees_CellMouseDown);
            this.dgvEmployees.DoubleClick += new System.EventHandler(this.dgvEmployees_DoubleClick);
            // 
            // cmsEmployees
            // 
            this.cmsEmployees.BackColor = System.Drawing.Color.White;
            this.cmsEmployees.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmsEmployees.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.cmsEmployees.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showDetailsToolStripMenuItem,
            this.toolStripSeparator1,
            this.editToolStripMenuItem,
            this.toolStripSeparator2,
            this.deleteToolStripMenuItem,
            this.toolStripMenuItem1,
            this.showResidenceToolStripMenuItem,
            this.toolStripMenuItem2,
            this.createResidenceToolStripMenuItem});
            this.cmsEmployees.Name = "cmsPeople";
            this.cmsEmployees.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmsEmployees.Size = new System.Drawing.Size(189, 218);
            this.cmsEmployees.Opening += new System.ComponentModel.CancelEventHandler(this.cmsEmployees_Opening);
            // 
            // showDetailsToolStripMenuItem
            // 
            this.showDetailsToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("showDetailsToolStripMenuItem.Image")));
            this.showDetailsToolStripMenuItem.Name = "showDetailsToolStripMenuItem";
            this.showDetailsToolStripMenuItem.Size = new System.Drawing.Size(188, 38);
            this.showDetailsToolStripMenuItem.Text = "رؤية البيانات";
            this.showDetailsToolStripMenuItem.Click += new System.EventHandler(this.showDetailsToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(185, 6);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("editToolStripMenuItem.Image")));
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(188, 38);
            this.editToolStripMenuItem.Text = "تعديل البيانات";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(185, 6);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("deleteToolStripMenuItem.Image")));
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(188, 38);
            this.deleteToolStripMenuItem.Text = "مسح";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(185, 6);
            // 
            // showResidenceToolStripMenuItem
            // 
            this.showResidenceToolStripMenuItem.Image = global::Presentation_Layer.Properties.Resources.Residences;
            this.showResidenceToolStripMenuItem.Name = "showResidenceToolStripMenuItem";
            this.showResidenceToolStripMenuItem.Size = new System.Drawing.Size(188, 38);
            this.showResidenceToolStripMenuItem.Text = "رؤية بيانات الإقامة";
            this.showResidenceToolStripMenuItem.Click += new System.EventHandler(this.showResidenceToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(185, 6);
            // 
            // createResidenceToolStripMenuItem
            // 
            this.createResidenceToolStripMenuItem.Image = global::Presentation_Layer.Properties.Resources.CreateNewResidence;
            this.createResidenceToolStripMenuItem.Name = "createResidenceToolStripMenuItem";
            this.createResidenceToolStripMenuItem.Size = new System.Drawing.Size(188, 38);
            this.createResidenceToolStripMenuItem.Text = "إنشاء إقامة";
            this.createResidenceToolStripMenuItem.Click += new System.EventHandler(this.createResidenceToolStripMenuItem_Click);
            // 
            // lblFilterBy
            // 
            this.lblFilterBy.AutoSize = true;
            this.lblFilterBy.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.lblFilterBy.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblFilterBy.Location = new System.Drawing.Point(800, 277);
            this.lblFilterBy.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFilterBy.Name = "lblFilterBy";
            this.lblFilterBy.Size = new System.Drawing.Size(71, 21);
            this.lblFilterBy.TabIndex = 33;
            this.lblFilterBy.Text = "الفلترة بـ :";
            // 
            // frmListEmployees
            // 
            this.AcceptButton = this.btnAddEmployee;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(884, 734);
            this.Controls.Add(this.lblFilterBy);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnAddEmployee);
            this.Controls.Add(this.lblRecordsCount);
            this.Controls.Add(this.lblRecords);
            this.Controls.Add(this.txtFilterValue);
            this.Controls.Add(this.lblManagePeople);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.cbFilterBy);
            this.Controls.Add(this.dgvEmployees);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmListEmployees";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "لوحة التحكم في الموظفين";
            this.Load += new System.EventHandler(this.frmListDrivers_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployees)).EndInit();
            this.cmsEmployees.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnAddEmployee;
        private System.Windows.Forms.Label lblRecordsCount;
        private System.Windows.Forms.Label lblRecords;
        private System.Windows.Forms.TextBox txtFilterValue;
        private System.Windows.Forms.Label lblManagePeople;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ComboBox cbFilterBy;
        private System.Windows.Forms.DataGridView dgvEmployees;
        private System.Windows.Forms.Label lblFilterBy;
        private System.Windows.Forms.ContextMenuStrip cmsEmployees;
        private System.Windows.Forms.ToolStripMenuItem showDetailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem showResidenceToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem createResidenceToolStripMenuItem;
    }
}