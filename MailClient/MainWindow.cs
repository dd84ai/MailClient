using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.IO;
using System.Runtime.InteropServices;
namespace MailClient
{
    public partial class MainWindow : Form
    {

        int MailQuan = 0;
        int MailQuantity()
        {
            try
            {
                DirectoryInfo d = new DirectoryInfo(@"received");//Assuming Test is your Folder
                FileInfo[] Files = d.GetFiles("*.txt"); //Getting Text files


                MailQuan = Files.Count();
                return (MailQuan);
            }
            catch (Exception)
            {
                return -1;
            }
        }

        
        private static void showMatch(string text, string expr)
        {
            Console.WriteLine("The Expression: " + expr);
            MatchCollection mc = Regex.Matches(text, expr);

            foreach (Match m in mc)
            {
                if (m.Length > 10)
                    Console.WriteLine("Found:" + m);
            }
        }
        public MainWindow()
        {
            try
            {
                InitializeComponent();

                var handle = GetConsoleWindow();
                ShowWindow(handle, SW_HIDE);

                label_LoginStatus.Text = Settings.ReadFiles();
                if (label_LoginStatus.Text.ToLower().Contains("error"))
                    label_LoginStatus.Text = "Status: Error";

                label1_MainQuantity.Text = "Mails: " + MailQuantity().ToString();
                
                string base64Encoded = "PGRpdiBkaXI9ImF1dG8iPtCd0YMg0YEg0LDQstCw0YDQuNGC0LjQtdC5INGB0L7Qs9C70LDRgdC10L08L2Rpdj48YnI+PGRpdiBjbGFzcz0iZ21haWxfcXVvdGUiPjxkaXYgZGlyPSJsdHIiIGNsYXNzPSJnbWFpbF9hdHRyIj7QodGALCAxMiDRh9C10YDQsi4gMjAxOSwgMjA6MzUg0LrQvtGA0LjRgdGC0YPQstCw0YcgZGFya3dpbmQgZHVjayAmbHQ7PGEgaHJlZj0ibWFpbHRvOmRhcmt3aW5kYXRzcGFjZXRlY2hAZ21haWwuY29tIj5kYXJrd2luZGF0c3BhY2V0ZWNoQGdtYWlsLmNvbTwvYT4mZ3Q7INC/0LjRiNC1Ojxicj48L2Rpdj48YmxvY2txdW90ZSBjbGFzcz0iZ21haWxfcXVvdGUiIHN0eWxlPSJtYXJnaW46MCAwIDAgLjhleDtib3JkZXItbGVmdDoxcHggI2NjYyBzb2xpZDtwYWRkaW5nLWxlZnQ6MWV4Ij48ZGl2IGRpcj0ibHRyIj7QryDQsNC60YLQuNCy0L3QviDQvdCwINC00YDQsNCz0L7QvdGC0LXRhdC1INC/0L7QtdGF0LDQuyDRgNCw0LfQstC40LLQsNGC0YzRgdGPKSDQkdC+0YLQsNC90YzQutGDINC/0L7Rh9GC0Lgg0LLQutCw0YfQsNC7LCDQvdCw0YfQsNC7INGH0LXRgNC10Lcg0JDQlTIg0L3QsNC70LDQttC40LLQsNGC0Ywg0LDQstGC0L7QvNCw0YLQuNC30LDRhtC40Y4g0YLQtdGF0L3Qvi48L2Rpdj48YnI+PGRpdiBjbGFzcz0iZ21haWxfcXVvdGUiPjxkaXYgZGlyPSJsdHIiIGNsYXNzPSJnbWFpbF9hdHRyIj7Rh9GCLCAxMyDQuNGO0L0uIDIwMTkg0LMuINCyIDAwOjE5LCBkYXJrd2luZCBkdWNrICZsdDs8YSBocmVmPSJtYWlsdG86ZGFya3dpbmRhdHNwYWNldGVjaEBnbWFpbC5jb20iIHRhcmdldD0iX2JsYW5rIiByZWw9Im5vcmVmZXJyZXIiPmRhcmt3aW5kYXRzcGFjZXRlY2hAZ21haWwuY29tPC9hPiZndDs6PGJyPjwvZGl2PjxibG9ja3F1b3RlIGNsYXNzPSJnbWFpbF9xdW90ZSIgc3R5bGU9Im1hcmdpbjowcHggMHB4IDBweCAwLjhleDtib3JkZXItbGVmdDoxcHggc29saWQgcmdiKDIwNCwyMDQsMjA0KTtwYWRkaW5nLWxlZnQ6MWV4Ij48ZGl2IGRpcj0ibHRyIj7QmiDRh9C10YDRgtGDINCQ0LLQsNGA0LDRgdGC0LjRjjwvZGl2Pjxicj48ZGl2IGNsYXNzPSJnbWFpbF9xdW90ZSI+PGRpdiBkaXI9Imx0ciIgY2xhc3M9ImdtYWlsX2F0dHIiPtGB0YAsIDEyINC40Y7QvS4gMjAxOSDQsy4g0LIgMjE6MjQsIFZvdmEgMjAwNSAmbHQ7PGEgaHJlZj0ibWFpbHRvOnZvdnZ2YTIwMDVAZ21haWwuY29tIiB0YXJnZXQ9Il9ibGFuayIgcmVsPSJub3JlZmVycmVyIj52b3Z2dmEyMDA1QGdtYWlsLmNvbTwvYT4mZ3Q7Ojxicj48L2Rpdj48YmxvY2txdW90ZSBjbGFzcz0iZ21haWxfcXVvdGUiIHN0eWxlPSJtYXJnaW46MHB4IDBweCAwcHggMC44ZXg7Ym9yZGVyLWxlZnQ6MXB4IHNvbGlkIHJnYigyMDQsMjA0LDIwNCk7cGFkZGluZy1sZWZ0OjFleCI+PGRpdiBkaXI9ImF1dG8iPtCQINC90LAg0YHQutCw0Lkg0YLQvtC20LUg0LHQtdC3INGD0YHQu9C+0LbQvdC10L3QuNC5INC90L4g0YLQsNC8INC10YHRgtGMINC+0LTQuNC9INC80L7QtCDQvtGH0LXQvdGMINGB0LvQvtC20L3Ri9C5INC90L4g0L7QvSDQvdC10LzQuNC90Y/QtdGCINCy0YHQtSDQtNGA0YPQs9C+0LU8L2Rpdj48YnI+PGRpdiBjbGFzcz0iZ21haWxfcXVvdGUiPjxkaXYgZGlyPSJsdHIiIGNsYXNzPSJnbWFpbF9hdHRyIj7QodGALCAxMiDRh9C10YDQsi4gMjAxOSwgMTY6NDYg0LrQvtGA0LjRgdGC0YPQstCw0YcgZGFya3dpbmQgZHVjayAmbHQ7PGEgaHJlZj0ibWFpbHRvOmRhcmt3aW5kYXRzcGFjZXRlY2hAZ21haWwuY29tIiB0YXJnZXQ9Il9ibGFuayIgcmVsPSJub3JlZmVycmVyIj5kYXJrd2luZGF0c3BhY2V0ZWNoQGdtYWlsLmNvbTwvYT4mZ3Q7INC/0LjRiNC1Ojxicj48L2Rpdj48YmxvY2txdW90ZSBjbGFzcz0iZ21haWxfcXVvdGUiIHN0eWxlPSJtYXJnaW46MHB4IDBweCAwcHggMC44ZXg7Ym9yZGVyLWxlZnQ6MXB4IHNvbGlkIHJnYigyMDQsMjA0LDIwNCk7cGFkZGluZy1sZWZ0OjFleCI+PGRpdiBkaXI9Imx0ciI+PGRpdj7QvdCwINGB0LrQsNC1INC90LXRgtGDLjxicj7QvdCwINC00YDQsNCz0L7QvdGC0LXRhdC1INC60YHRgtCw0YLRjCDQstGB0Y8g0LzQsNCz0LjRjyDQsdC10Lcg0YPRgdC70L7QttC90LXQvdC40LkpPGJyPtCi0YPRgiDRgtC+0LvRjNC60L4g0YLQtdGF0L3QviDQvdC10LzQvdC+0LPQviDRg9GB0LvQvtC20L3QuNC70LguPGJyPtCi0LDQuiDRh9GC0L4g0L/QviDQvNC+0LXQvNGDINGC0YPRgiDQstC/0L7Qu9C90LUg0LvQtdCz0LrQvik8L2Rpdj48YnI+PGRpdiBjbGFzcz0iZ21haWxfcXVvdGUiPjxkaXYgZGlyPSJsdHIiIGNsYXNzPSJnbWFpbF9hdHRyIj7RgdGALCAxMiDQuNGO0L0uIDIwMTkg0LMuINCyIDE4OjI2LCBWb3ZhIDIwMDUgJmx0OzxhIGhyZWY9Im1haWx0bzp2b3Z2dmEyMDA1QGdtYWlsLmNvbSIgcmVsPSJub3JlZmVycmVyIG5vcmVmZXJyZXIiIHRhcmdldD0iX2JsYW5rIj52b3Z2dmEyMDA1QGdtYWlsLmNvbTwvYT4mZ3Q7Ojxicj48L2Rpdj48YmxvY2txdW90ZSBjbGFzcz0iZ21haWxfcXVvdGUiIHN0eWxlPSJtYXJnaW46MHB4IDBweCAwcHggMC44ZXg7Ym9yZGVyLWxlZnQ6MXB4IHNvbGlkIHJnYigyMDQsMjA0LDIwNCk7cGFkZGluZy1sZWZ0OjFleCI+PGRpdiBkaXI9ImF1dG8iPtCQINGDINGC0LXQsdGPINC10YHRgtGMINC60LjRgiDQvdCwINGB0LrQsNC5INC4INGC0Ysg0LHRg9C00LXRiCDQuNCz0YDQsNGC0Ywg0L3QsCDRgdC/0LXQudGB0YLQtdGHPzwvZGl2Pg0KPC9ibG9ja3F1b3RlPjwvZGl2PjwvZGl2Pg0KPC9ibG9ja3F1b3RlPjwvZGl2Pg0KPC9ibG9ja3F1b3RlPjwvZGl2Pg0KPC9ibG9ja3F1b3RlPjwvZGl2Pg0KPC9ibG9ja3F1b3RlPjwvZGl2Pg0K";
                string base64Decoded;
                byte[] data = System.Convert.FromBase64String(base64Encoded);
                base64Decoded = System.Text.UTF8Encoding.UTF8.GetString(data);
                Console.WriteLine(base64Decoded);


                string[] lines = System.IO.File.ReadAllLines(@"received\0092.txt");

                for (int i = 0; i < lines.Count(); i++)
                {
                    if (lines[i].Contains("Content-Transfer-Encoding: base64") && lines[i - 1].Contains("text"))
                    {
                        string builder = "";
                        for (int j = i + 1; j < lines.Count(); j++)
                        {
                            if (!lines[j].Contains("-"))
                                builder += lines[j];
                            else
                            {
                                string base64Encoded2 = builder;
                                string base64Decoded2;
                                byte[] data2 = System.Convert.FromBase64String(base64Encoded2);
                                base64Decoded2 = System.Text.UTF8Encoding.UTF8.GetString(data2);
                                Console.WriteLine(base64Decoded2);
                                break;
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Error: Couldn't init Form1" + e.Message);
            }
        }

        

        private void button2_Click(object sender, EventArgs e)
        {
            label1_NewMail.Text = "New: " + "Loading...";
            this.Refresh();
            //Refresh mail
            int RememberMailQuantity = MailQuan;
            MailReader.ReadEverything();

            label1_MainQuantity.Text = "Mails: " + MailQuantity().ToString();

            if (MailQuan > RememberMailQuantity)
                label1_NewMail.Text = "New: " + (MailQuan - RememberMailQuantity).ToString();
            else
                label1_NewMail.Text = "New: " + 0;
        }


        
        

        private void button_login_Click(object sender, EventArgs e)
        {
            frm2 = new FormLogin();
            frm2.ShowDialog();
        }

        private void button2_CreateMail_Click(object sender, EventArgs e)
        {
            var Temp = new WriteMail();
            Temp.ShowDialog();
        }

        [DllImport("kernel32.dll")]
        static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        const int SW_HIDE = 0;
        const int SW_SHOW = 5;
        bool hidden = true;
        private void button1_Console_Click(object sender, EventArgs e)
        {
            var handle = GetConsoleWindow();
            if (hidden)
            {
                hidden = false;
                // Show
                ShowWindow(handle, SW_SHOW);
            }
            else
            {
                hidden = true;
                // Hide
                ShowWindow(handle, SW_HIDE);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Read
            var Temp = new ReadMail();
            Temp.ShowDialog();
        }
    }
}
