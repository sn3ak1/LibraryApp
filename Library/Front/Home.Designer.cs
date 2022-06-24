﻿using System.ComponentModel;

namespace Library
{
    partial class Home
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(39, 157);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(512, 61);
            this.button1.TabIndex = 0;
            this.button1.Text = "Books";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(318, 54);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 25);
            this.button2.TabIndex = 1;
            this.button2.Text = "LOGIN";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(39, 56);
            this.textBox1.Name = "textBox1";
            this.textBox1.PlaceholderText = "Login";
            this.textBox1.Size = new System.Drawing.Size(100, 23);
            this.textBox1.TabIndex = 2;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(168, 56);
            this.textBox2.Name = "textBox2";
            this.textBox2.PasswordChar = '*';
            this.textBox2.PlaceholderText = "Password";
            this.textBox2.Size = new System.Drawing.Size(100, 23);
            this.textBox2.TabIndex = 3;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(451, 54);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(100, 25);
            this.button3.TabIndex = 4;
            this.button3.Text = "LOGOUT";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(39, 102);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(229, 23);
            this.button4.TabIndex = 5;
            this.button4.Text = "Rented books";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(318, 102);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(233, 23);
            this.button5.TabIndex = 6;
            this.button5.Text = "History";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(318, 12);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(233, 23);
            this.button6.TabIndex = 7;
            this.button6.Text = "REGISTER";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(148, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 15);
            this.label1.TabIndex = 8;
            this.label1.Text = "guest";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(39, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 15);
            this.label2.TabIndex = 9;
            this.label2.Text = "You are logged as:";
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(593, 245);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "Home";
            this.Text = "Home";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}