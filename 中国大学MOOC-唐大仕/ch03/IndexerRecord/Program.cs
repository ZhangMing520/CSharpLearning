using System;

namespace IndexerRecord
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IndexerRecord record = new IndexerRecord();
            // 分别设置了 Author Publisher Title
            record[0] = "马克-吐温";
            record[1] = "Crox出版公司";
            record[2] = "汤姆-索亚历险记";

            Console.WriteLine(record["Title"]);
            Console.WriteLine(record["Author"]);
            Console.WriteLine(record["Publisher"]);
            Console.ReadKey();
        }
    }

    /// <summary>
    /// 属性和索引
    /// keys是键，data中保存值
    /// </summary>
    class IndexerRecord
    {
        private string[] data = new string[6];
        private string[] keys =
        {
            "Author", "Publisher", "Title", "Subject", "ISBN", "Comments"
        };

        /// <summary>
        /// 如果索引参数是int类型，直接访问data中数据
        /// </summary>
        /// <param name="idx"></param>
        /// <returns></returns>
        public string this[int idx]
        {
            get
            {
                if (idx >= 0 && idx < data.Length)
                    return data[idx];
                else
                    return null;
            }
            set
            {
                if (idx >= 0 && idx < data.Length) data[idx] = value;
            }

        }

        /// <summary>
        /// 如果索引参数是string类型，先获取key所在keys中索引，再根据int索引获取data中数据
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public string this[string key]
        {
            get
            {
                return this[FindKey(key)];
            }
            set
            {
                this[FindKey(key)] = value;
            }
        }

        /// <summary>
        /// 查找key在keys中的索引
        /// </summary>
        /// <param name="key"></param>
        /// <returns>未找到，返回-1</returns>
        private int FindKey(string key)
        {
            for (int i = 0; i < keys.Length; i++)
            {
                if (keys[i] == key) return i;
            }
            return -1;
        }

    }
}
