using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business_Layer;
namespace Presentation_Layer.Employees
{
    public partial class frmShowEmployeeInfo : Form
    {
        public frmShowEmployeeInfo(int EmployeeID)
        {
            InitializeComponent();
            ctrlEmployeeCard1.LoadEmployeeInfo(EmployeeID);
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}