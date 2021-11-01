
namespace OrderParserChallenge
{
    partial class Form1
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
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.button1 = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.parseData = new System.Windows.Forms.Button();
            this.account1 = new System.Windows.Forms.Button();
            this.account2 = new System.Windows.Forms.Button();
            this.Account3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 35);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(105, 33);
            this.button1.TabIndex = 0;
            this.button1.Text = "Select File";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(123, 12);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(665, 426);
            this.richTextBox1.TabIndex = 1;
            this.richTextBox1.Text = "";
            // 
            // parseData
            // 
            this.parseData.Location = new System.Drawing.Point(12, 98);
            this.parseData.Name = "parseData";
            this.parseData.Size = new System.Drawing.Size(105, 37);
            this.parseData.TabIndex = 3;
            this.parseData.Text = "Parse Data";
            this.parseData.UseVisualStyleBackColor = true;
            this.parseData.Click += new System.EventHandler(this.parseData_Click);
            // 
            // account1
            // 
            this.account1.Location = new System.Drawing.Point(12, 159);
            this.account1.Name = "account1";
            this.account1.Size = new System.Drawing.Size(105, 35);
            this.account1.TabIndex = 4;
            this.account1.Text = "Display Account 1";
            this.account1.UseVisualStyleBackColor = true;
            this.account1.Click += new System.EventHandler(this.account1_Click);
            // 
            // account2
            // 
            this.account2.Location = new System.Drawing.Point(12, 210);
            this.account2.Name = "account2";
            this.account2.Size = new System.Drawing.Size(105, 38);
            this.account2.TabIndex = 5;
            this.account2.Text = "Display Account 2";
            this.account2.UseVisualStyleBackColor = true;
            this.account2.Click += new System.EventHandler(this.account2_Click);
            // 
            // Account3
            // 
            this.Account3.Location = new System.Drawing.Point(12, 265);
            this.Account3.Name = "Account3";
            this.Account3.Size = new System.Drawing.Size(105, 35);
            this.Account3.TabIndex = 6;
            this.Account3.Text = "Display Account 3";
            this.Account3.UseVisualStyleBackColor = true;
            this.Account3.Click += new System.EventHandler(this.Account3_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Account3);
            this.Controls.Add(this.account2);
            this.Controls.Add(this.account1);
            this.Controls.Add(this.parseData);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Order_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button parseData;
        private System.Windows.Forms.Button account1;
        private System.Windows.Forms.Button account2;
        private System.Windows.Forms.Button Account3;
    }
}

