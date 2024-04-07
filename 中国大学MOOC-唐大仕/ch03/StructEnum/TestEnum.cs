using System;

namespace StructEnum
{
    /// <summary>
    /// 枚举
    /// </summary>
    class TestEnum
    {
        static void Main(string[] args)
        {
            LightColor color = new LightColor();
            // Red
            Console.WriteLine(color.ToString());
            TrafficLight.WhatInfo(color);

            // 字符串转枚举
            LightColor color2 = (LightColor)Enum.Parse(typeof(LightColor), LightColor.Yellow.ToString());
            Console.WriteLine(color2.ToString());
            Console.ReadKey();
        }
    }

    enum LightColor
    {
        Red, Yellow, Green
    }

    class TrafficLight
    {
        public static void WhatInfo(LightColor color)
        {
            switch (color)
            {
                case LightColor.Red:
                    Console.WriteLine("Stop!");
                    break;
                case LightColor.Yellow:
                    Console.WriteLine("Warning!");
                    break;
                case LightColor.Green:
                    Console.WriteLine("Go!");
                    break;
                default:
                    break;
            }
        }
    }
}


