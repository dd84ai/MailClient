using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace MailClient
{
    class Filework
    {
        public static string login, pass;

        public static void ReadFiles()
        {
            string[] lines = System.IO.File.ReadAllLines(@"Logpass.txt");
            try
            {
                login = lines[0];
                pass = lines[1];
            }
            catch (Exception)
            {
                MessageBox.Show("Error: Couldn't read login and password from Logpass.txt");
            }
        }
    }
}
