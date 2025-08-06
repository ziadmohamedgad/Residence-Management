namespace Presentation_Layer
{
    partial class frmMainScreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMainScreen));
            this.msMainTabs = new System.Windows.Forms.MenuStrip();
            this.peopleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.employeesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.residencesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.msMainTabs.SuspendLayout();
            this.SuspendLayout();
            // 
            // msMainTabs
            // 
            this.msMainTabs.AutoSize = false;
            this.msMainTabs.BackColor = System.Drawing.Color.Transparent;
            this.msMainTabs.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.msMainTabs.ImageScalingSize = new System.Drawing.Size(40, 40);
            this.msMainTabs.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.peopleToolStripMenuItem,
            this.employeesToolStripMenuItem,
            this.residencesToolStripMenuItem});
            this.msMainTabs.Location = new System.Drawing.Point(0, 0);
            this.msMainTabs.Name = "msMainTabs";
            this.msMainTabs.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.msMainTabs.Size = new System.Drawing.Size(1134, 40);
            this.msMainTabs.TabIndex = 0;
            this.msMainTabs.Text = "menuStrip1";
            // 
            // peopleToolStripMenuItem
            // 
            this.peopleToolStripMenuItem.Image = global::Presentation_Layer.Properties.Resources.People;
            this.peopleToolStripMenuItem.Name = "peopleToolStripMenuItem";
            this.peopleToolStripMenuItem.Size = new System.Drawing.Size(158, 36);
            this.peopleToolStripMenuItem.Text = "الأشخاص";
            this.peopleToolStripMenuItem.Click += new System.EventHandler(this.peopleToolStripMenuItem_Click);
            // 
            // employeesToolStripMenuItem
            // 
            this.employeesToolStripMenuItem.Image = global::Presentation_Layer.Properties.Resources.Employees;
            this.employeesToolStripMenuItem.Name = "employeesToolStripMenuItem";
            this.employeesToolStripMenuItem.Size = new System.Drawing.Size(162, 36);
            this.employeesToolStripMenuItem.Text = "الموظفين";
            this.employeesToolStripMenuItem.Click += new System.EventHandler(this.employeesToolStripMenuItem_Click);
            // 
            // residencesToolStripMenuItem
            // 
            this.residencesToolStripMenuItem.Image = global::Presentation_Layer.Properties.Resources.Residences;
            this.residencesToolStripMenuItem.Name = "residencesToolStripMenuItem";
            this.residencesToolStripMenuItem.Size = new System.Drawing.Size(146, 36);
            this.residencesToolStripMenuItem.Text = "الإقامات";
            this.residencesToolStripMenuItem.Click += new System.EventHandler(this.residencesToolStripMenuItem_Click);
            // 
            // frmMainScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackgroundImage = global::Presentation_Layer.Properties.Resources.Background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1134, 681);
            this.Controls.Add(this.msMainTabs);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.msMainTabs;
            this.Name = "frmMainScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "اللوحة الرئيسية";
            this.msMainTabs.ResumeLayout(false);
            this.msMainTabs.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MenuStrip msMainTabs;
        private System.Windows.Forms.ToolStripMenuItem peopleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem employeesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem residencesToolStripMenuItem;
    }
}

