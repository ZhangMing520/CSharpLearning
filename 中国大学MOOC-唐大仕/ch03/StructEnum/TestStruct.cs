using System;

namespace StructEnum
{
    class TestStruct
    {
        static void Main2(string[] args)
        {
            Point[] points = new Point[100];
            for (int i = 0; i < points.Length; i++)
            {
                points[i] = new Point(i, i * i);
                Console.WriteLine(points[i].R());
            }
            Console.ReadKey();
        }
    }

    /// <summary>
    /// 结构是值类型
    ///     1. 不能包含无参构造方法
    ///     2. 每个字段在定义时候，不能给初始值
    ///     3. 构造方法中，必须对每个字段进行赋值
    /// </summary>

    struct Point
    {
        public double x, y;

        public Point(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public double R() { return Math.Sqrt(x * x + y * y); }
    }

}


