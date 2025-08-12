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
                DataTable dt = clsResidence.GetResidencesExpiringSoon(15);
                if (dt.Rows.Count == 0)
                    return;      
                string body = "الإقامات التالية ستنتهي خلال 15 يوم:\n\n";
                foreach (DataRow row in dt.Rows)
                {
                    body += $"{row["EmployeeFullName"]} - {row["ResidenceNumber"]} - {Convert.ToDateTime(row["ExpirationDate"]):yyyy-MM-dd}\n";
                }
                clsEmailService.SendEmail(
                    fromEmail: "your_email@gmail.com",////////////
                    password: "your_app_password", //////////////
                    toEmail: "recipient_email@example.com",//////////////
                    subject: "تنبيه: إقامات ستنتهي قريبًا",
                    body: body
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