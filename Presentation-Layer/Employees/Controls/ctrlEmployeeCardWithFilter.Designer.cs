namespace Presentation_Layer.Employees.Controls
{
    partial class ctrlEmployeeCardWithFilter
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
            this.components = new System.ComponentModel.Container();
            this.gbFilters = new System.Windows.Forms.GroupBox();
            this.btnAddNewEmployee = new System.Windows.Forms.Button();
            this.btnFind = new System.Windows.Forms.Button();
            this.txtFilterValue = new System.Windows.Forms.TextBox();
            this.cbFilterBy = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ctrlEmployeeCard1 = new Presentation_Layer.Employees.Controls.ctrlEmployeeCard();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.gbFilters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // gbFilters
            // 
            this.gbFilters.BackColor = System.Drawing.Color.White;
            this.gbFilters.Controls.Add(this.btnAddNewEmployee);
            this.gbFilters.Controls.Add(this.btnFind);
            this.gbFilters.Controls.Add(this.txtFilterValue);
            this.gbFilters.Controls.Add(this.cbFilterBy);
            this.gbFilters.Controls.Add(this.label1);
            this.gbFilters.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.gbFilters.Location = new System.Drawing.Point(10, 3);
            this.gbFilters.Name = "gbFilters";
            this.gbFilters.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.gbFilters.Size = new System.Drawing.Size(525, 107);
            this.gbFilters.TabIndex = 3;
            this.gbFilters.TabStop = false;
            this.gbFilters.Text = "فلترة";
            // 
            // btnAddNewEmployee
            // 
            this.btnAddNewEmployee.Image = global::Presentation_Layer.Properties.Resources.AddEmployee;
            this.btnAddNewEmployee.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnAddNewEmployee.Location = new System.Drawing.Point(13, 35);
            this.btnAddNewEmployee.Name = "btnAddNewEmployee";
            this.btnAddNewEmployee.Size = new System.Drawing.Size(54, 48);
            this.btnAddNewEmployee.TabIndex = 7;
            this.btnAddNewEmployee.UseVisualStyleBackColor = true;
            this.btnAddNewEmployee.Click += new System.EventHandler(this.btnAddNewEmployee_Click);
            // 
            // btnFind
            // 
            this.btnFind.Image = global::Presentation_Layer.Properties.Resources.Search;
            this.btnFind.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnFind.Location = new System.Drawing.Point(74, 35);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(54, 48);
            this.btnFind.TabIndex = 7;
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // txtFilterValue
            // 
            this.txtFilterValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFilterValue.Location = new System.Drawing.Point(137, 46);
            this.txtFilterValue.Name = "txtFilterValue";
            this.txtFilterValue.Size = new System.Drawing.Size(133, 29);
            this.txtFilterValue.TabIndex = 3;
            this.txtFilterValue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFilterValue_KeyPress);
            this.txtFilterValue.Validating += new System.ComponentModel.CancelEventHandler(this.txtFilterValue_Validating);
            // 
            // cbFilterBy
            // 
            this.cbFilterBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilterBy.FormattingEnabled = true;
            this.cbFilterBy.Items.AddRange(new object[] {
            "الرقم التعريفي"});
            this.cbFilterBy.Location = new System.Drawing.Point(278, 46);
            this.cbFilterBy.Name = "cbFilterBy";
            this.cbFilterBy.Size = new System.Drawing.Size(160, 29);
            this.cbFilterBy.TabIndex = 1;
            this.cbFilterBy.SelectedIndexChanged += new System.EventHandler(this.cbFilterBy_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(444, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "البحث بـ :";
            // 
            // ctrlEmployeeCard1
            // 
            this.ctrlEmployeeCard1.BackColor = System.Drawing.Color.White;
            this.ctrlEmployeeCard1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrlEmployeeCard1.Location = new System.Drawing.Point(2, 112);
            this.ctrlEmployeeCard1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ctrlEmployeeCard1.Name = "ctrlEmployeeCard1";
            this.ctrlEmployeeCard1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ctrlEmployeeCard1.Size = new System.Drawing.Size(543, 424);
            this.ctrlEmployeeCard1.TabIndex = 4;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // ctrlEmployeeCardWithFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.ctrlEmployeeCard1);
            this.Controls.Add(this.gbFilters);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "ctrlEmployeeCardWithFilter";
            this.Size = new System.Drawing.Size(543, 534);
            this.Load += new System.EventHandler(this.ctrlEmployeeCardWithFilter_Load);
            this.gbFilters.ResumeLayout(false);
            this.gbFilters.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbFilters;
        private System.Windows.Forms.Button btnAddNewEmployee;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.TextBox txtFilterValue;
        private System.Windows.Forms.ComboBox cbFilterBy;
        private System.Windows.Forms.Label label1;
        private ctrlEmployeeCard ctrlEmployeeCard1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}
