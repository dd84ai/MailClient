using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using ActiveUp.Net.Mail;
using Pop3;
using System.Text.RegularExpressions;
using System.IO;

namespace MailClient
{
    class MailReader
    {
        public static void ReadEverything()
        {
            Console.WriteLine("POP3 Mail Client Demo");
            Console.WriteLine("=====================");
            Console.WriteLine();
            try
            {
                //prepare pop client
                // TODO: Replace username and password with your own credentials.
                Pop3.Pop3MailClient DemoClient = new Pop3.Pop3MailClient("pop.gmail.com", 995, true, Settings.login, Settings.pass);
                DemoClient.IsAutoReconnect = true;

                //remove the following line if no tracing is needed
                DemoClient.Trace += new Pop3.TraceHandler(Console.WriteLine);
                DemoClient.ReadTimeout = 60000; //give pop server 60 seconds to answer

                //establish connection
                DemoClient.Connect();

                //get mailbox statistics
                int NumberOfMails, MailboxSize;
                DemoClient.GetMailboxStats(out NumberOfMails, out MailboxSize);

                //get a list of mails
                List<int> EmailIds;
                DemoClient.GetEmailIdList(out EmailIds);

                //get a list of unique mail ids
                List<Pop3.EmailUid> EmailUids;
                DemoClient.GetUniqueEmailIdList(out EmailUids);

                //get email size
                DemoClient.GetEmailSize(1);

                //get email
                string Email;
                // DemoClient.GetRawEmail(90, out Email);
                // Console.WriteLine(Email);
                //var Lines = Email.Split('\n');

                try
                {
                    System.IO.Directory.CreateDirectory("received");
                }
                catch (Exception)
                {
                }

                DirectoryInfo d = new DirectoryInfo(@"received");//Assuming Test is your Folder
                FileInfo[] Files = d.GetFiles("*.txt"); //Getting Text files

                Console.WriteLine("Already email quantity: " + Files.Count().ToString());

                

                foreach (var Id in EmailIds)
                {
                    DemoClient.GetRawEmail(Id, out Email);

                    using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(@"received\" + (Files.Count()+Id).ToString("D4") + ".txt"))
                    {
                        file.WriteLine(Email);
                        file.Close();
                    }

                    DemoClient.NOOP();

                }

                // System.Convert.FromBase64String

                //delete email
                //DemoClient.DeleteEmail(1);

                //get a list of mails
                List<int> EmailIds2;
                DemoClient.GetEmailIdList(out EmailIds2);

                //undelete all emails
                //DemoClient.UndeleteAllEmails();

                //ping server
                DemoClient.NOOP();

                //test some error conditions
                DemoClient.GetRawEmail(1000000, out Email);
                DemoClient.DeleteEmail(1000000);


                //close connection
                DemoClient.Disconnect();

            }
            catch (Exception ex)
            {
                Console.WriteLine();
                Console.WriteLine("Run Time Error Occured:");
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }

            Console.WriteLine();
            //Console.WriteLine("======== Press Enter to end program");
            // Console.ReadLine();
        }
    }
}
