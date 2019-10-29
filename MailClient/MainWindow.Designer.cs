
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
    partial class MainWindow
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.button2_RefreshEmail = new System.Windows.Forms.Button();
            this.button_login = new System.Windows.Forms.Button();
            this.label_LoginStatus = new System.Windows.Forms.Label();
            this.frm2 = new MailClient.FormLogin();
            this.label1_MainQuantity = new System.Windows.Forms.Label();
            this.label1_NewMail = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(668, 413);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(120, 25);
            this.button1.TabIndex = 0;
            this.button1.Text = "Send Test Mail";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2_RefreshEmail
            // 
            this.button2_RefreshEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button2_RefreshEmail.Location = new System.Drawing.Point(12, 74);
            this.button2_RefreshEmail.Name = "button2_RefreshEmail";
            this.button2_RefreshEmail.Size = new System.Drawing.Size(151, 33);
            this.button2_RefreshEmail.TabIndex = 1;
            this.button2_RefreshEmail.Text = "Refresh mailbox";
            this.button2_RefreshEmail.UseVisualStyleBackColor = true;
            this.button2_RefreshEmail.Click += new System.EventHandler(this.button2_Click);
            // 
            // button_login
            // 
            this.button_login.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_login.Location = new System.Drawing.Point(12, 12);
            this.button_login.Name = "button_login";
            this.button_login.Size = new System.Drawing.Size(151, 36);
            this.button_login.TabIndex = 2;
            this.button_login.Text = "Login";
            this.button_login.UseVisualStyleBackColor = true;
            this.button_login.Click += new System.EventHandler(this.button_login_Click);
            // 
            // label_LoginStatus
            // 
            this.label_LoginStatus.AutoSize = true;
            this.label_LoginStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_LoginStatus.Location = new System.Drawing.Point(183, 20);
            this.label_LoginStatus.Name = "label_LoginStatus";
            this.label_LoginStatus.Size = new System.Drawing.Size(60, 20);
            this.label_LoginStatus.TabIndex = 3;
            this.label_LoginStatus.Text = "Status:";
            // 
            // frm2
            // 
            this.frm2.ClientSize = new System.Drawing.Size(284, 262);
            this.frm2.Location = new System.Drawing.Point(200, 200);
            this.frm2.Name = "frm2";
            this.frm2.Text = "FormLogin";
            this.frm2.Visible = false;
            this.frm2.PerformForm1Click += new System.EventHandler(this.frm2_PerformForm1Click);
            // 
            // label1_MainQuantity
            // 
            this.label1_MainQuantity.AutoSize = true;
            this.label1_MainQuantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1_MainQuantity.Location = new System.Drawing.Point(183, 80);
            this.label1_MainQuantity.Name = "label1_MainQuantity";
            this.label1_MainQuantity.Size = new System.Drawing.Size(53, 20);
            this.label1_MainQuantity.TabIndex = 4;
            this.label1_MainQuantity.Text = "Mails: ";
            // 
            // label1_NewMail
            // 
            this.label1_NewMail.AutoSize = true;
            this.label1_NewMail.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1_NewMail.Location = new System.Drawing.Point(183, 138);
            this.label1_NewMail.Name = "label1_NewMail";
            this.label1_NewMail.Size = new System.Drawing.Size(140, 20);
            this.label1_NewMail.TabIndex = 5;
            this.label1_NewMail.Text = "New loaded mails: ";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1_NewMail);
            this.Controls.Add(this.label1_MainQuantity);
            this.Controls.Add(this.label_LoginStatus);
            this.Controls.Add(this.button_login);
            this.Controls.Add(this.button2_RefreshEmail);
            this.Controls.Add(this.button1);
            this.Name = "MainWindow";
            this.Text = "MainWindow";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        FormLogin frm2;
        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2_RefreshEmail;
        private System.Windows.Forms.Button button_login;
        private System.Windows.Forms.Label label_LoginStatus;

        private void frm2_PerformForm1Click(object sender, EventArgs e)
        {
            label_LoginStatus.Text = Settings.ReadFiles();

            if (label_LoginStatus.Text.ToLower().Contains("error"))
            {
                string res = label_LoginStatus.Text;
                label_LoginStatus.Text = "Error: Incorrect login or pass";
                MessageBox.Show(res);
            }

            frm2.Visible = false;
        }

        private Label label1_MainQuantity;
        private Label label1_NewMail;
    }
}

