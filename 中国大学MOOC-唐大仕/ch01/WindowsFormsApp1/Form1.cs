using System;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("你好！");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Text = "这是一个应用程序";
            this.BackColor = Color.FromArgb(255, 255, 0);
            // this.label1.SetBounds(100, 100, 200, 50);

            this.label1.Left += 100;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            label1.Text = $"{e.X}, {e.Y}";
        }
    }
}
