using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoScore
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        double result;

        /// <summary>
        /// 出题
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNew_Click(object sender, EventArgs e)
        {
            int a, b;
            string op = "";
            Random random = new Random();

            a = random.Next(9) + 1;
            b = random.Next(9) + 1;
            int c = random.Next(4);
            switch (c)
            {
                case 0:
                    op = "+"; result = a + b;
                    break;
                case 1:
                    op = "-"; result = a - b;
                    break;
                case 2:
                    op = "*"; result = a * b;
                    break;
                case 3:
                    op = "/"; result = a / b;
                    break;
            }
            lblA.Text = $"{a}";
            lblOp.Text = $"{op}";
            lblB.Text = $"{b}";
            txtAnswer.Text = "";
        }


        /// <summary>
        /// 判分
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnJudge_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtAnswer.Text))
            {
                double answer = double.Parse(txtAnswer.Text);
                string disp = $"{lblA.Text} {lblOp.Text} {lblB.Text} = {answer}";
                if (answer == result)
                {
                    disp += " √";
                }
                else
                {
                    disp += " ×";
                }
                lstDisp.Items.Add(disp);
            }

        }
    }
}
