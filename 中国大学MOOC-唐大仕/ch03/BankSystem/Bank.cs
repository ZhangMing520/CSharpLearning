using System.Collections.Generic;

namespace BankSystem
{
    public class Bank
    {
        List<Account> accounts = new List<Account>();

        /// <summary>
        /// 开户：账户、密码、钱
        /// </summary>
        /// <param name="id"></param>
        /// <param name="pwd"></param>
        /// <param name="money"></param>
        /// <returns></returns>
        public Account OpenAccount(string id, string pwd, double money)
        {
            Account account = new Account(id, pwd, money);
            accounts.Add(account);
            return account;
        }

        /// <summary>
        /// 销户
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        public bool CloseAccount(Account account)
        {
            if (accounts.IndexOf(account) == -1) return false;
            accounts.Remove(account);
            return true;
        }

        /// <summary>
        /// 查找账户
        /// </summary>
        /// <param name="id"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public Account FindAccount(string id, string pwd)
        {
            foreach (Account account in accounts)
            {
                if (account.IsMatch(id, pwd))
                {
                    return account;
                }
            }
            return null;
        }
    }
}
