using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MailClient
{
    public partial class WriteMail : Form
    {
        public WriteMail()
        {
            InitializeComponent();
            label4_From.Text = Settings.login;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                MailSender MailSender;
                MailSender = new MailSender();
                MailSender.SendMail(Settings.login, textBox2_To.Text, textBox3_Subject.Text, TextBox1_Body.Text);
            }
            catch (Exception er)
            {
                MessageBox.Show("Error: " + er.Message);
            }
            this.Close();
        }
    }
}
