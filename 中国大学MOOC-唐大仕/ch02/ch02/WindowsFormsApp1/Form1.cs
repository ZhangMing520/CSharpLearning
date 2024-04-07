using System;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int deltX = 10;
        int deltY = 8;

        /// <summary>
        /// Windows屏保，最后 exe 需要修改为 xxx.scr，并且放在 C:\Windows\System32 目录下
        /// 1. 设置窗口无边框 FormBorderStyle = None
        /// 2. label 黑底白字，一号字体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            this.label1.Left += deltX;
            this.label1.Top += deltY;
            if (this.label1.Top < 0 || this.label1.Top + this.label1.Height > this.Height)
            {
                // 向上移动到顶部 或者 向下移动到底部
                deltY = -deltY;
            }
            if (this.label1.Left < 0 || this.label1.Left + this.label1.Width > this.Width)
            {
                // 向左移动到最左边，向右移动到最右边
                deltX = -deltX;
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            // 退出程序
            Application.Exit();
        }

    }
}
