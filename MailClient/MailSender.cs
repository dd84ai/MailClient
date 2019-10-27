using System;
using System.Net;
using System.Net.Mail;

namespace MailClient
{
    public class MailSender
    {
        public MailSender()
        {
            
        }

        public void SendMail()
        {
            // System.Net.Mail.
            using (var mm = new MailMessage("Name <from@gmail.com>", "dd84ai@gmail.com"))
            {
                mm.Subject = "Mail Subject";
                mm.Body = "Mail Body";
                mm.IsBodyHtml = false;
                using (var sc = new SmtpClient("smtp.gmail.com", 587))//587//465))
                {
                    sc.EnableSsl = true;
                    sc.Timeout = 20000;
                    sc.DeliveryMethod = SmtpDeliveryMethod.Network;
                    sc.UseDefaultCredentials = false;
                    sc.Credentials = new NetworkCredential(Filework.login, Filework.pass);
                    sc.Send(mm);
                }
            }
        }
    }
}
