﻿using System;
using System.Drawing;
using System.Windows.Forms;

namespace UseTimer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Random random = new Random();
            // this.Text = DateTime.Now.ToString();
            // this.BackColor = Color.FromArgb(random.Next(255), random.Next(255), random.Next(255));
            // this.label1.Left += 10;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Random random = new Random();
            this.Text = DateTime.Now.ToString();
            this.BackColor = Color.FromArgb(random.Next(255), random.Next(255), random.Next(255));
            this.label1.Left += 10;
        }
    }
}
