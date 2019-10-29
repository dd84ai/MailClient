using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace MailClient
{
    public partial class FormLogin : Form
    {

        public FormLogin()
        {
            InitializeComponent();
            textBox1_Login.Text = Settings.login;
            textBox1_Pass.Text = Settings.pass;
        }
        ~FormLogin()
        {
            
        }
        public event EventHandler PerformForm1Click;
        private void FormLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            EventHandler handler = this.PerformForm1Click;
            if (handler != null)
                handler(this, EventArgs.Empty);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (StreamWriter writer = new StreamWriter("Logpass.txt"))
            {
                writer.WriteLine(textBox1_Login.Text);
                writer.WriteLine(textBox1_Pass.Text);
            }
            Settings.ReadFiles();
            this.Close();

        }
    }
}
