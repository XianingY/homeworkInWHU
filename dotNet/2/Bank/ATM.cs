using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    public class BigMoneyArgs : EventArgs
    {
        public string AccountNumber { get; set; }
        public decimal Amount { get; set; }

        public BigMoneyArgs(string accountNumber, decimal amount)
        {
            AccountNumber = accountNumber;
            Amount = amount;
        }
    }

    public class ATM
    {
        public event EventHandler<BigMoneyArgs> BigMoneyFetched;

        public void Withdraw(Account account, decimal amount)
        {
            account.Withdraw(amount);
            if (amount > 10000)
            {
                OnBigMoneyFetched(new BigMoneyArgs(account.AccountNumber, amount));
            }
        }

        protected virtual void OnBigMoneyFetched(BigMoneyArgs e)
        {
            BigMoneyFetched?.Invoke(this, e);
        }
    }
}
