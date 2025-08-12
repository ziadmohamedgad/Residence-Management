using Business_Layer;
using Presentation_Layer.Employees;
using Presentation_Layer.People;
using Presentation_Layer.Residences;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Presentation_Layer
{
    public partial class frmMainScreen : Form
    {
        public frmMainScreen()
        {
            InitializeComponent();
        }
        private void peopleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListPeople frm = new frmListPeople();
            frm.ShowDialog();
        }
        private void employeesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListEmployees frm = new frmListEmployees();
            frm.ShowDialog();
        }
        private void residencesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListResidences frm = new frmListResidences();
            frm.ShowDialog();
        }
        public static void SendResidencesExpiryAlert(int Days)
        {
            DataTable dt = clsResidence.GetResidencesExpiringSoon(Days);
            if (dt.Rows.Count == 0)
                return;
            string body = "الإقامات التالية ستنتهي خلال 15 يوم:\n\n";
            foreach (DataRow row in dt.Rows)
            {
                body += $"{row["EmployeeFullName"]} - {row["ResidenceNumber"]} - {Convert.ToDateTime(row["ExpirationDate"]):yyyy-MM-dd}\n";
            }
            clsEmailService.SendEmail(
                fromEmail: "your_email@gmail.com",
                password: "your_app_password",
                toEmail: "recipient_email@example.com",
                subject: "تنبيه: إقامات ستنتهي قريبًا",
                body: body
            );
        }
    }
}