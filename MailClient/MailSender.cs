using System;
using System.Net;
using System.Net.Mail;
using System.Diagnostics;
namespace MailClient
{
    public class MailSender
    {
        public MailSender()
        {
            
        }
        //"Name <from@gmail.com>"
        //
        public void SendMail(string From, string To, string Subject, string Body)
        {
           

            using (var mm = new MailMessage(From, To))
            {
                mm.Subject = Subject;
                mm.Body = Body;
                mm.IsBodyHtml = false;
                using (var sc = new SmtpClient("smtp.gmail.com", 587))//587//465))
                {
                    sc.EnableSsl = true;
                    sc.Timeout = 20000;
                    sc.DeliveryMethod = SmtpDeliveryMethod.Network;
                    sc.UseDefaultCredentials = false;
                    
                    sc.Credentials = new NetworkCredential(Settings.login, Settings.pass);
                    sc.Send(mm);
                }
            }
        }
    }
}
