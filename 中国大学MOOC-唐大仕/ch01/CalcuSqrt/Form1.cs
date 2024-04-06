using System;
using System.Windows.Forms;

namespace CalcuSqrt
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double num = double.Parse(textBox1.Text);
            label1.Text = $"{num}的平方根是{Math.Sqrt(num)}";
        }
    }
}
