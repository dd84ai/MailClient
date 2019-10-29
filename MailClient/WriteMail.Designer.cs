namespace MailClient
{
    partial class WriteMail
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBox2_To = new System.Windows.Forms.TextBox();
            this.textBox3_Subject = new System.Windows.Forms.TextBox();
            this.TextBox1_Body = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label4_From = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBox2_To
            // 
            this.textBox2_To.Location = new System.Drawing.Point(185, 38);
            this.textBox2_To.Name = "textBox2_To";
            this.textBox2_To.Size = new System.Drawing.Size(603, 20);
            this.textBox2_To.TabIndex = 1;
            // 
            // textBox3_Subject
            // 
            this.textBox3_Subject.Location = new System.Drawing.Point(185, 64);
            this.textBox3_Subject.Name = "textBox3_Subject";
            this.textBox3_Subject.Size = new System.Drawing.Size(603, 20);
            this.textBox3_Subject.TabIndex = 2;
            // 
            // TextBox1_Body
            // 
            this.TextBox1_Body.Location = new System.Drawing.Point(185, 90);
            this.TextBox1_Body.Name = "TextBox1_Body";
            this.TextBox1_Body.Size = new System.Drawing.Size(603, 348);
            this.TextBox1_Body.TabIndex = 3;
            this.TextBox1_Body.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(110, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "From:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(129, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "To:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(93, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "Subject:";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(12, 407);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(148, 31);
            this.button1.TabIndex = 7;
            this.button1.Text = "Send";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label4_From
            // 
            this.label4_From.AutoSize = true;
            this.label4_From.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4_From.Location = new System.Drawing.Point(181, 12);
            this.label4_From.Name = "label4_From";
            this.label4_From.Size = new System.Drawing.Size(125, 20);
            this.label4_From.TabIndex = 8;
            this.label4_From.Text = "who@gmail.com";
            // 
            // WriteMail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label4_From);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TextBox1_Body);
            this.Controls.Add(this.textBox3_Subject);
            this.Controls.Add(this.textBox2_To);
            this.Name = "WriteMail";
            this.Text = "WriteMail";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textBox2_To;
        private System.Windows.Forms.TextBox textBox3_Subject;
        private System.Windows.Forms.RichTextBox TextBox1_Body;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label4_From;
    }
}