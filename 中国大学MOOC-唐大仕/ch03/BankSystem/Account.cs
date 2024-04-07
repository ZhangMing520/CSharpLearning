namespace BankSystem
{
    /// <summary>
    /// 账户
    /// </summary>
    public class Account
    {
        double money;
        string id;
        string pwd;

        public Account(string id, string pwd, double money)
        {
            this.id = id;
            this.pwd = pwd;
            this.money = money;
        }

        public double Money { get => money; set => money = value; }
        public string Id { get => id; set => id = value; }
        public string Pwd { get => pwd; set => pwd = value; }

        /// <summary>
        /// 存钱
        /// </summary>
        /// <param name="money"></param>
        /// <returns></returns>
        public bool SaveMoney(double money)
        {
            if (money < 0)
            {
                return false;
            }
            else
            {
                this.money += money;
                return true;
            }
        }

        /// <summary>
        /// 取钱
        /// </summary>
        /// <param name="money"></param>
        /// <returns></returns>
        public bool WithdrawMoney(double money)
        {
            if (this.money > money)
            {
                this.money -= money;
                return true;
            }
            return false;
        }

        /// <summary>
        /// 是否账号和密码匹配
        /// </summary>
        /// <param name="id"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public bool IsMatch(string id, string pwd)
        {
            return this.id == id && this.pwd == pwd;
        }

    }
}
