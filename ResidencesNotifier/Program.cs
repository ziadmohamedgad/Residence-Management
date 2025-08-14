using Business_Layer;
using Data_Layer;
using Shared_Layer;
using System;
using System.Data;
using System.Diagnostics;
namespace ResidencesNotifier
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                DataTable dt = clsResidence.GetResidencesExpiringSoon(30);
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
        <h3>الإقامات التالية ستنتهي خلال " + 30 + @" يوم:</h3>
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
                    fromEmail: "mrdeghidy@gmail.com",
                    password: "wijxzqzyshxxnzgq",
                    toEmail: "qasralajdad@gmail.com",
                    subject: "تنبيه: إقامات ستنتهي قريبًا",
                    body: body,
                    isBodyHtml: true
                );
            }
            catch (Exception ex)
            {
                clsEventLogger.SaveLog("Application", $"{ex.Message}: failed through sending the automated email (Console Script)."
                    , EventLogEntryType.Error);
            }
        }
    }
}