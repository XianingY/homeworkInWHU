using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    public class Bank
    {
        public string Name { get; set; }
        public Bank(string name)
        {
            Name = name;
        }
    }

    public class Account
    {
        public string AccountNumber { get; set; }
        public decimal Balance { get; protected set; }

        public Account(string accountNumber, decimal initialBalance)
        {
            AccountNumber = accountNumber;
            Balance = initialBalance;
        }

        public virtual void Deposit(decimal amount)
        {
            Balance += amount;
        }

        public virtual void Withdraw(decimal amount)
        {
            if (amount <= Balance)
            {
                Balance -= amount;
            }
            else
            {
                throw new InvalidOperationException("Insufficient funds.");
            }
        }
    }

    public class CreditAccount : Account
    {
        public decimal CreditLimit { get; set; }

        public CreditAccount(string accountNumber, decimal initialBalance, decimal creditLimit)
            : base(accountNumber, initialBalance)
        {
            CreditLimit = creditLimit;
        }

        public override void Withdraw(decimal amount)
        {
            if (amount <= Balance + CreditLimit)
            {
                Balance -= amount;
            }
            else
            {
                throw new InvalidOperationException("Credit limit exceeded.");
            }
        }
    }
}
