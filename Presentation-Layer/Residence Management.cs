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
            // HTML Table
            string body = @"
    <html>
    <head>
        <meta charset='UTF-8'>
        <style>
            table {
                border-collapse: collapse;
                width: 100%;
                font-family: Arial, sans-serif;
            }
            th, td {
                border: 1px solid #ddd;
                padding: 8px;
                text-align: center;
            }
            th {
                background-color: #4CAF50;
                color: white;
            }
            tr:nth-child(even) {
                background-color: #f2f2f2;
            }
        </style>
    </head>
    <body>
        <h3>الإقامات التالية ستنتهي خلال " + Days + @" يوم:</h3>
        <table>
            <tr>
                <th>اسم الموظف</th>
                <th>رقم الإقامة</th>
                <th>تاريخ الانتهاء</th>
                <th>الأيام المتبقية</th>
            </tr>";

            foreach (DataRow row in dt.Rows)
            {
                DateTime expirationDate = Convert.ToDateTime(row["ExpirationDate"]);
                int daysLeft = (expirationDate - DateTime.Now).Days;
                body += "<tr>";
                body += $"<td>{row["EmployeeFullName"]}</td>";
                body += $"<td>{row["ResidenceNumber"]}</td>";
                body += $"<td>{expirationDate:yyyy-MM-dd}</td>";
                body += $"<td>{daysLeft}</td>";
                body += "</tr>";
            }
            body += @"
        </table>
    </body>
    </html>";
            clsEmailService.SendEmail(
                fromEmail: "sender@gmail.com",
                password: "pass",
                toEmail: "receiver@gmail.com",
                subject: "تنبيه: إقامات ستنتهي قريبًا",
                body: body,
                isBodyHtml: true
            );
        }
    }
}