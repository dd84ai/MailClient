﻿using System;
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
    public partial class ReadMail_TrueForm : Form
    {
        public ReadMail_TrueForm(string text)
        {
            InitializeComponent();
            richTextBox1.Text = text;
        }
    }
}
