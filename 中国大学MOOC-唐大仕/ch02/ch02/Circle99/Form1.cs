using System;
using System.Drawing;
using System.Windows.Forms;

namespace Circle99
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Random random = new Random();

        Color getRandomColor()
        {
            return Color.FromArgb(random.Next(0, 256), random.Next(0, 256), random.Next(0, 256));
        }

        /// <summary>
        /// 画圆
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            Graphics g = this.CreateGraphics();
            int x0 = this.Width / 2;
            int y0 = this.Height / 2;

            for (int r = 0; r < this.Height / 2; r++)
            {
                // 矩形的左上角坐标，以及矩形的宽度和高度
                g.DrawEllipse(new Pen(getRandomColor(), 1),
                    x0 - r, y0 - r, r * 2, r * 2);
            }
            g.Dispose();
        }
    }
}
