﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;
namespace MailClient
{
    public partial class ReadMail : Form
    {
        public ReadMail()
        {
            InitializeComponent();

            DirectoryInfo d = new DirectoryInfo(@"received");//Assuming Test is your Folder
            FileInfo[] Files = d.GetFiles("*.txt"); //Getting Text files

            listBox1.Items.AddRange(Files.Select(x => x.Name).Select(x => x.Replace(".txt","")).ToArray());
        }
        public static String Decode(string input)
        {
            try
            {
                string base64Encoded = input.Replace("=?UTF-8?B?", "").Replace("?=","").Replace("_", "");
                byte[] data = System.Convert.FromBase64String(base64Encoded);
                string base64Decoded = System.Text.UTF8Encoding.UTF8.GetString(data);
                return base64Decoded;

            }
            catch (Exception)
            {
                return "Error in decoding";
            }
        }
        public static String DecodeQ(string input)
        {
            try
            {
                string base64Encoded = input.Replace("=?UTF-8?B?", "").Replace("?=", "").Replace("_", "").Replace("=", "-");
                UTF8Encoding Encoding = new UTF8Encoding();
                byte[] data = Encoding.GetBytes(base64Encoded);
                string base64Decoded = Encoding.GetString(data.ToArray());

                return base64Decoded;

            }
            catch (Exception)
            {
                return "Error in decoding";
            }
        }
        private void button1_SelectLetter_Click(object sender, EventArgs e)
        {
            try
            {
                string[] lines = System.IO.File.ReadAllLines(@"received\" + listBox1.SelectedItem.ToString() + ".txt");
                string text = String.Join("\n", lines);
                // richTextBox1.Text = text;

                //Delivered-To
                for (int i = 0; i < lines.Count(); i++)
                {
                    if (lines[i].Contains("Delivered") && lines[i][0] == 'D')
                    {
                        //No worries
                        label4_To.Text = lines[i].Replace("Delivered-To: ","");
                        break;
                    }
                }
                for (int i = 0; i < lines.Count(); i++)
                {
                    if (lines[i].Contains("From") && lines[i][0] == 'F')
                    {
                        string pattern = @"<.*@*.>$";
                        string input = lines[i].Replace("From: ", "");
                        Match m = Regex.Match(input, pattern,
            RegexOptions.IgnoreCase);
                        bool Found = false;
                        while (m.Success)
                        {
                            Found = true;
                            label4_From.Text = m.Value;
                            m = m.NextMatch();
                        }
                        if (!Found)
                            label4_From.Text = input;

                        break;
                    }
                }
                for (int i = 0; i < lines.Count(); i++)
                {
                    if (lines[i].Contains("Subject") && lines[i][0] == 'S')
                    {
                        string temp = lines[i].Replace("Subject: ", "");
                        if (temp.Contains("?UTF-8?B?"))
                        {
                            label4_Subject.Text = Decode(temp);//.Replace("?UTF-8?B?", ""));
                            if (!lines[i + 1].Contains("To:") && lines[i + 1].Contains("?UTF-8?B?"))
                                label4_Subject.Text += Decode(lines[i + 1]);
                        }
                        else
                        {
                            if (temp.Contains("=?utf-8?Q?="))
                            {
                                label4_Subject.Text = DecodeQ(temp.Replace("=?utf-8?Q?=", ""));
                            }
                            else
                            {
                                label4_Subject.Text = temp;
                            }
                        }
                        break;
                    }
                }


                //BODY
                //string[] lines = System.IO.File.ReadAllLines(@"received\0092.txt");
                richTextBox1.Text = "";

                for (int i = 0; i < lines.Count(); i++)
                {
                    if (lines[i].Contains("Content-Transfer-Encoding: base64") && lines[i - 1].Contains("text"))
                    {
                        string builder = "";
                        for (int j = i + 1; j < lines.Count(); j++)
                        {
                            if (!lines[j].Contains("-") && !lines[j].Contains("."))
                                builder += lines[j];
                            else
                            {
                                string base64Encoded2 = builder;
                                string base64Decoded2;
                                byte[] data2 = System.Convert.FromBase64String(base64Encoded2);
                                base64Decoded2 = System.Text.UTF8Encoding.UTF8.GetString(data2);
                                //Console.WriteLine(base64Decoded2);
                                richTextBox1.Text += base64Decoded2;
                                break;
                            }
                        }
                        
                    }
                    if (lines[i].Contains("Content-Transfer-Encoding: quoted-printable") || ((lines[i].Contains("Content-Type: text/") && (!lines[i+1].Contains("Encoding") && (!lines[i - 1].Contains("Encoding"))))))
                    {
                        string builder = "";
                        for (int j = i + 1; j < lines.Count(); j++)
                        {
                            if (!lines[j].Contains("Content-Type:") && !lines[j].Contains("--"))//lines[j] != "." && 
                                builder += lines[j] + "\n";
                            else
                            {
                                break;
                            }
                        }
                        richTextBox1.Text += builder;
                    }

                }

            }
            catch (Exception e3)
            {
                MessageBox.Show("Error: " + e3.Message);
            }
        }

        private void button1_TrueForm_Click(object sender, EventArgs e)
        {
            try
            {
                string[] lines = System.IO.File.ReadAllLines(@"received\" + listBox1.SelectedItem.ToString() + ".txt");
                string text = String.Join("\n", lines);
                var temp = new ReadMail_TrueForm(text);
                temp.ShowDialog();
            }
            catch (Exception er34)
            {
                MessageBox.Show("Error: " + er34.Message);
            }
        }
        void UpdateUserBox()
        {
            listBox1.Items.Clear();
            DirectoryInfo d = new DirectoryInfo(@"received");//Assuming Test is your Folder
            FileInfo[] Files = d.GetFiles("*.txt"); //Getting Text files

            listBox1.Items.AddRange(Files.Select(x => x.Name).Select(x => x.Replace(".txt", "")).ToArray());

        }
        private void button1_Del_Click(object sender, EventArgs e)
        {
            string Adress = Directory.GetCurrentDirectory() + "\\received\\" + listBox1.SelectedItem.ToString().Replace("\\", "") + ".txt";

                try
                {
                    File.Delete(Adress);
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message);
                }

            UpdateUserBox();
        }
    }
}
