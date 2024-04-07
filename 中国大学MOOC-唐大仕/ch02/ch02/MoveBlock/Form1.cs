using System;
using System.Windows.Forms;

namespace MoveBlock
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        // 按钮的行、列数目
        const int N = 4;
        // 按钮的数组
        Button[,] buttons = new Button[N, N];

        /// <summary>
        /// 窗口加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            GenerateAllButtons();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 打乱顺序
            Shuffle();
        }

        /// <summary>
        /// 生成所有的按钮
        /// </summary>
        void GenerateAllButtons()
        {
            int x0 = 100, y0 = 10, w = 45, d = 50;
            // 行
            for (int r = 0; r < N; r++)
            {
                // 列
                for (int c = 0; c < N; c++)
                {
                    int num = r * N + c;
                    Button btn = new Button();
                    btn.Text = $"{num + 1}";
                    btn.Top = y0 + r * d;
                    btn.Left = x0 + c * d;
                    btn.Width = btn.Height = w;
                    btn.Visible = true;
                    // 这个数据用来表示它所在的行列位置
                    btn.Tag = r * N + c;

                    btn.Click += new EventHandler(btn_Click);

                    // 放到数组中
                    buttons[r, c] = btn;
                    this.Controls.Add(btn);
                }
            }
            // 最后一个不可见
            buttons[N - 1, N - 1].Visible = false;
        }

        /// <summary>
        /// 打乱排序
        /// </summary>
        void Shuffle()
        {
            Random random = new Random();
            for (int i = 0; i < 100; i++)
            {
                int a = random.Next(N), b = random.Next(N);
                int c = random.Next(N), d = random.Next(N);
                Swap(buttons[a, b], buttons[c, d]);
            }
        }

        /// <summary>
        /// 交换按钮，不能交换Tag；
        /// 比如12和空白交换，空白的Text变为12、可见、Tag不变，还是r=3,c=3；12的Text变为空白、不可见、Tag不变，还是r=2,c=3
        /// </summary>
        /// <param name="btna"></param>
        /// <param name="btnb"></param>
        void Swap(Button btna, Button btnb)
        {
            (btna.Text, btnb.Text) = (btnb.Text, btna.Text);

            (btna.Visible, btnb.Visible) = (btnb.Visible, btna.Visible);
        }

        /// <summary>
        /// 生成的按钮的点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void btn_Click(object sender, EventArgs e)
        {
            // 当前点击的按钮
            Button btn = sender as Button;
            // 空白按钮
            Button blank = FindHiddenButton();

            // 判断是否与空白块相邻，如果是，则交换
            if (IsNeighbor(btn, blank))
            {
                Swap(btn, blank);
                blank.Focus();
            }

            // 判断是否完成
            if (ResultIsOk())
            {
                MessageBox.Show("OK");
            }
        }

        /// <summary>
        /// 查找隐藏的按钮
        /// </summary>
        /// <returns></returns>
        Button FindHiddenButton()
        {
            for (int r = 0; r < N; r++)
            {
                // 列
                for (int c = 0; c < N; c++)
                {
                    if (!buttons[r, c].Visible)
                    {
                        return buttons[r, c];
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// 判断按钮是否相邻
        /// </summary>
        /// <param name="btna"></param>
        /// <param name="btnb"></param>
        /// <returns></returns>
        bool IsNeighbor(Button btna, Button btnb)
        {
            int a = (int)btna.Tag;
            int b = (int)btnb.Tag;
            int r1 = a / N, c1 = a % N;
            int r2 = b / N, c2 = b % N;

            // 左右相邻
            // 上下相邻
            return (r1 == r2 && (c1 == c2 - 1 || c1 == c2 + 1))
                || c1 == c2 && (r1 == r2 - 1 || r1 == r2 + 1);
        }

        /// <summary>
        /// 检查是否完成
        /// </summary>
        /// <returns></returns>
        bool ResultIsOk()
        {
            for (int r = 0; r < N; r++)
            {
                // 列
                for (int c = 0; c < N; c++)
                {
                    if (buttons[r, c].Text != (r * N + c + 1).ToString())
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
