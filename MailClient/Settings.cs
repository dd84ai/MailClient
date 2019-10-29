using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace MailClient
{
    class Settings
    {
        public static string login, pass;

        static bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        public static string ReadFiles()
        {
            try
            {
                string[] lines = System.IO.File.ReadAllLines(@"Logpass.txt");

                if (!IsValidEmail(lines[0]))
                    throw new Exception("Invalid email");

                login = lines[0];
                pass = lines[1];
                return "login has been loaded";
            }
            catch (Exception e)
            {
                return "Error: " + e.Message;
            }
        }
    }
}
