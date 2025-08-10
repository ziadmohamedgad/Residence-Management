namespace Presentation_Layer.Employees
{
    partial class frmChooseSponsor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmChooseSponsor));
            this.btnEnsureChoice = new System.Windows.Forms.Button();
            this.ctrlPersonCardWithFilter1 = new Presentation_Layer.People.Controls.ctrlPersonCardWithFilter();
            this.SuspendLayout();
            // 
            // btnEnsureChoice
            // 
            this.btnEnsureChoice.Image = ((System.Drawing.Image)(resources.GetObject("btnEnsureChoice.Image")));
            this.btnEnsureChoice.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEnsureChoice.Location = new System.Drawing.Point(12, 307);
            this.btnEnsureChoice.Name = "btnEnsureChoice";
            this.btnEnsureChoice.Size = new System.Drawing.Size(251, 41);
            this.btnEnsureChoice.TabIndex = 22;
            this.btnEnsureChoice.Text = "تأكيد الاختيار";
            this.btnEnsureChoice.UseVisualStyleBackColor = true;
            this.btnEnsureChoice.Visible = false;
            this.btnEnsureChoice.Click += new System.EventHandler(this.btnEnsureChoice_Click);
            // 
            // ctrlPersonCardWithFilter1
            // 
            this.ctrlPersonCardWithFilter1.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ctrlPersonCardWithFilter1.BackColor = System.Drawing.Color.White;
            this.ctrlPersonCardWithFilter1.FilterEnabled = true;
            this.ctrlPersonCardWithFilter1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.ctrlPersonCardWithFilter1.Location = new System.Drawing.Point(13, 14);
            this.ctrlPersonCardWithFilter1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ctrlPersonCardWithFilter1.Name = "ctrlPersonCardWithFilter1";
            this.ctrlPersonCardWithFilter1.ShowAddPerson = true;
            this.ctrlPersonCardWithFilter1.Size = new System.Drawing.Size(793, 347);
            this.ctrlPersonCardWithFilter1.TabIndex = 0;
            this.ctrlPersonCardWithFilter1.OnPersonSelected += new System.Action<int>(this.ctrlPersonCardWithFilter1_OnPersonSelected);
            // 
            // frmChooseSponsor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(813, 367);
            this.Controls.Add(this.btnEnsureChoice);
            this.Controls.Add(this.ctrlPersonCardWithFilter1);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmChooseSponsor";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "لوحة اختيار الكفيل";
            this.Activated += new System.EventHandler(this.frmChooseSponsor_Activated);
            this.ResumeLayout(false);

        }

        #endregion

        private People.Controls.ctrlPersonCardWithFilter ctrlPersonCardWithFilter1;
        private System.Windows.Forms.Button btnEnsureChoice;
    }
}