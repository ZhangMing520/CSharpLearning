using System;

namespace BankSystem
{
    public class ATM
    {
        Bank bank;

        public ATM(Bank bank)
        {
            this.bank = bank;
        }

        /// <summary>
        /// 交易
        /// </summary>
        public void Transaction()
        {
            Show("please input your card");
            string id = GetInput();

            Show("please input your password");
            string pwd = GetInput();

            Account account = bank.FindAccount(id, pwd);
            if (account == null)
            {
                Show("card invalid or password not correct");
                return;
            }

            Show("1: display; 2: save; 3: withdraw");
            string op = GetInput();
            switch (op)
            {
                case "1":
                    Show($"balance: {account.Money}");
                    break;
                case "2":
                    Show("save money");
                    double money = double.Parse(GetInput());
                    if (account.SaveMoney(money))
                    {
                        Show("ok");
                    }
                    else
                    {
                        Show("error");
                    }
                    Show($"balance: {account.Money}");
                    break;
                case "3":
                    Show("withdraw money");
                    double wmoney = double.Parse(GetInput());
                    if (account.WithdrawMoney(wmoney))
                    {
                        Show("ok");
                    }
                    else
                    {
                        Show("error");
                    }
                    Show($"balance: {account.Money}");
                    break;
                default:
                    Show("error");
                    break;
            }
        }

        /// <summary>
        /// 输出到控制台，换行
        /// </summary>
        /// <param name="msg"></param>
        public void Show(string msg)
        {
            Console.WriteLine(msg);
        }

        /// <summary>
        /// 获取控制台整行输入
        /// </summary>
        /// <returns></returns>
        public string GetInput()
        {
            return Console.ReadLine();
        }
    }
}
