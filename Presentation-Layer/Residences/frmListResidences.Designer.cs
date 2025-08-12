namespace Presentation_Layer.Residences
{
    partial class frmListResidences
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmListResidences));
            this.lblFilterBy = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnAddResidence = new System.Windows.Forms.Button();
            this.lblRecordsCount = new System.Windows.Forms.Label();
            this.lblRecords = new System.Windows.Forms.Label();
            this.txtFilterValue = new System.Windows.Forms.TextBox();
            this.lblManagePeople = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.cbFilterBy = new System.Windows.Forms.ComboBox();
            this.dgvResidences = new System.Windows.Forms.DataGridView();
            this.cmsResidences = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cbPeriods = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResidences)).BeginInit();
            this.cmsResidences.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblFilterBy
            // 
            this.lblFilterBy.AutoSize = true;
            this.lblFilterBy.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.lblFilterBy.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblFilterBy.Location = new System.Drawing.Point(838, 279);
            this.lblFilterBy.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFilterBy.Name = "lblFilterBy";
            this.lblFilterBy.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblFilterBy.Size = new System.Drawing.Size(71, 21);
            this.lblFilterBy.TabIndex = 43;
            this.lblFilterBy.Text = "الفلترة بـ :";
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::Presentation_Layer.Properties.Resources.Close;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.TopRight;
            this.btnClose.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnClose.Location = new System.Drawing.Point(12, 677);
            this.btnClose.Name = "btnClose";
            this.btnClose.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnClose.Size = new System.Drawing.Size(133, 45);
            this.btnClose.TabIndex = 42;
            this.btnClose.Text = "إغلاق";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnAddResidence
            // 
            this.btnAddResidence.Image = global::Presentation_Layer.Properties.Resources.addResidencebutton;
            this.btnAddResidence.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnAddResidence.Location = new System.Drawing.Point(12, 260);
            this.btnAddResidence.Name = "btnAddResidence";
            this.btnAddResidence.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnAddResidence.Size = new System.Drawing.Size(107, 54);
            this.btnAddResidence.TabIndex = 41;
            this.btnAddResidence.UseVisualStyleBackColor = true;
            this.btnAddResidence.Click += new System.EventHandler(this.btnAddEmployee_Click);
            // 
            // lblRecordsCount
            // 
            this.lblRecordsCount.AutoSize = true;
            this.lblRecordsCount.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecordsCount.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblRecordsCount.Location = new System.Drawing.Point(767, 689);
            this.lblRecordsCount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRecordsCount.Name = "lblRecordsCount";
            this.lblRecordsCount.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblRecordsCount.Size = new System.Drawing.Size(26, 21);
            this.lblRecordsCount.TabIndex = 40;
            this.lblRecordsCount.Text = "؟؟";
            // 
            // lblRecords
            // 
            this.lblRecords.AutoSize = true;
            this.lblRecords.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecords.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblRecords.Location = new System.Drawing.Point(813, 689);
            this.lblRecords.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRecords.Name = "lblRecords";
            this.lblRecords.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblRecords.Size = new System.Drawing.Size(96, 21);
            this.lblRecords.TabIndex = 39;
            this.lblRecords.Text = "عدد الإقامات:";
            // 
            // txtFilterValue
            // 
            this.txtFilterValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFilterValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtFilterValue.Location = new System.Drawing.Point(299, 276);
            this.txtFilterValue.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtFilterValue.Name = "txtFilterValue";
            this.txtFilterValue.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtFilterValue.Size = new System.Drawing.Size(272, 26);
            this.txtFilterValue.TabIndex = 38;
            this.txtFilterValue.TextChanged += new System.EventHandler(this.txtFilterValue_TextChanged);
            this.txtFilterValue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFilterValue_KeyPress);
            // 
            // lblManagePeople
            // 
            this.lblManagePeople.AutoSize = true;
            this.lblManagePeople.Font = new System.Drawing.Font("Segoe UI Semibold", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblManagePeople.ForeColor = System.Drawing.Color.DarkRed;
            this.lblManagePeople.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblManagePeople.Location = new System.Drawing.Point(378, 204);
            this.lblManagePeople.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblManagePeople.Name = "lblManagePeople";
            this.lblManagePeople.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblManagePeople.Size = new System.Drawing.Size(138, 47);
            this.lblManagePeople.TabIndex = 37;
            this.lblManagePeople.Text = "الإقامات";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Presentation_Layer.Properties.Resources.Residences;
            this.pictureBox1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pictureBox1.Location = new System.Drawing.Point(273, 12);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(364, 184);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 36;
            this.pictureBox1.TabStop = false;
            // 
            // cbFilterBy
            // 
            this.cbFilterBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilterBy.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbFilterBy.FormattingEnabled = true;
            this.cbFilterBy.Items.AddRange(new object[] {
            "لاشيء",
            "الرقم التعريفي",
            "اسم الموظف",
            "رقم الإقامة",
            "الوظيفة",
            "المدة"});
            this.cbFilterBy.Location = new System.Drawing.Point(579, 275);
            this.cbFilterBy.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbFilterBy.Name = "cbFilterBy";
            this.cbFilterBy.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cbFilterBy.Size = new System.Drawing.Size(254, 29);
            this.cbFilterBy.TabIndex = 35;
            this.cbFilterBy.SelectedIndexChanged += new System.EventHandler(this.cbFilterBy_SelectedIndexChanged);
            // 
            // dgvResidences
            // 
            this.dgvResidences.AllowUserToAddRows = false;
            this.dgvResidences.AllowUserToDeleteRows = false;
            this.dgvResidences.AllowUserToResizeRows = false;
            this.dgvResidences.BackgroundColor = System.Drawing.Color.White;
            this.dgvResidences.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResidences.ContextMenuStrip = this.cmsResidences;
            this.dgvResidences.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvResidences.Location = new System.Drawing.Point(12, 317);
            this.dgvResidences.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.dgvResidences.MultiSelect = false;
            this.dgvResidences.Name = "dgvResidences";
            this.dgvResidences.ReadOnly = true;
            this.dgvResidences.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dgvResidences.RowTemplate.Height = 25;
            this.dgvResidences.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvResidences.Size = new System.Drawing.Size(895, 349);
            this.dgvResidences.TabIndex = 34;
            this.dgvResidences.TabStop = false;
            this.dgvResidences.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvResidences_CellMouseDown);
            this.dgvResidences.DoubleClick += new System.EventHandler(this.dgvResidences_DoubleClick);
            // 
            // cmsResidences
            // 
            this.cmsResidences.BackColor = System.Drawing.Color.White;
            this.cmsResidences.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmsResidences.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.cmsResidences.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showDetailsToolStripMenuItem,
            this.toolStripSeparator1,
            this.editToolStripMenuItem,
            this.toolStripSeparator2,
            this.deleteToolStripMenuItem});
            this.cmsResidences.Name = "cmsPeople";
            this.cmsResidences.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmsResidences.Size = new System.Drawing.Size(197, 152);
            // 
            // showDetailsToolStripMenuItem
            // 
            this.showDetailsToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("showDetailsToolStripMenuItem.Image")));
            this.showDetailsToolStripMenuItem.Name = "showDetailsToolStripMenuItem";
            this.showDetailsToolStripMenuItem.Size = new System.Drawing.Size(196, 38);
            this.showDetailsToolStripMenuItem.Text = "رؤية البيانات";
            this.showDetailsToolStripMenuItem.Click += new System.EventHandler(this.showDetailsToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(193, 6);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("editToolStripMenuItem.Image")));
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(196, 38);
            this.editToolStripMenuItem.Text = "تعديل البيانات";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(193, 6);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("deleteToolStripMenuItem.Image")));
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(196, 38);
            this.deleteToolStripMenuItem.Text = "مسح";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // cbPeriods
            // 
            this.cbPeriods.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPeriods.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.cbPeriods.FormattingEnabled = true;
            this.cbPeriods.Items.AddRange(new object[] {
            "ثلاثة أشهر فيما أقل",
            "ستة أشهر فيما أقل"});
            this.cbPeriods.Location = new System.Drawing.Point(366, 275);
            this.cbPeriods.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbPeriods.Name = "cbPeriods";
            this.cbPeriods.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cbPeriods.Size = new System.Drawing.Size(205, 28);
            this.cbPeriods.TabIndex = 35;
            this.cbPeriods.Visible = false;
            this.cbPeriods.SelectedIndexChanged += new System.EventHandler(this.cbPeriods_SelectedIndexChanged);
            // 
            // frmListResidences
            // 
            this.AcceptButton = this.btnAddResidence;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(922, 734);
            this.Controls.Add(this.lblFilterBy);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnAddResidence);
            this.Controls.Add(this.lblRecordsCount);
            this.Controls.Add(this.lblRecords);
            this.Controls.Add(this.lblManagePeople);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.cbPeriods);
            this.Controls.Add(this.cbFilterBy);
            this.Controls.Add(this.dgvResidences);
            this.Controls.Add(this.txtFilterValue);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmListResidences";
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "لوحة التحكم في الإقامات";
            this.Load += new System.EventHandler(this.frmListResidences_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResidences)).EndInit();
            this.cmsResidences.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblFilterBy;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnAddResidence;
        private System.Windows.Forms.Label lblRecordsCount;
        private System.Windows.Forms.Label lblRecords;
        private System.Windows.Forms.TextBox txtFilterValue;
        private System.Windows.Forms.Label lblManagePeople;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ComboBox cbFilterBy;
        private System.Windows.Forms.DataGridView dgvResidences;
        private System.Windows.Forms.ContextMenuStrip cmsResidences;
        private System.Windows.Forms.ToolStripMenuItem showDetailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ComboBox cbPeriods;
    }
}