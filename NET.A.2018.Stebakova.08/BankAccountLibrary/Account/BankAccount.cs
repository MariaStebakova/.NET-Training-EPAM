using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountLibrary.Account
{
    public abstract class BankAccount
    {
        private string accountNumber;
        private AccountOwner owner;

        public decimal Balance { get; private set; }
        public int BenefitPoints { get; private set; }

        public string AccountNumber
        {
            get { return accountNumber; }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException($"{nameof(AccountNumber)} can't be equal to null or empty");
                }
                accountNumber = value;
            }
        }

        public AccountOwner Owner
        {
            get => owner;
            private set => owner = value ?? throw new ArgumentException($"{nameof(Owner)} can't be equal to null");
        }

        public BankAccount(AccountOwner owner)
        {
            Owner = owner;
            AccountNumber = GenerateNumber();
        }

        public BankAccount(AccountOwner owner, decimal balance)
        {
            Owner = owner;
            AccountNumber = GenerateNumber();
            Balance = balance;
        }

        public BankAccount(AccountOwner owner, decimal balance, int benefitPoints)
        {
            Owner = owner;
            AccountNumber = GenerateNumber();
            Balance = balance;
            BenefitPoints = benefitPoints;
        }

        public void Deposit(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException($"{nameof(amount)} can not be less or equal to zero.");
            }

            Balance += amount;
            BenefitPoints += CalculateBenefitPoint(amount);
        }

        internal void Withdraw(decimal amount)
        {
            if (!CheckBalance(Balance, amount))
            {
                throw new ArgumentException($"{nameof(amount)} can't be less than current balance");
            }

            if (amount <= 0)
            {
                throw new ArgumentException($"{nameof(amount)} can not be less or equal to zero.");
            }

            if (amount > Balance)
            {
                throw new ArgumentException($"{nameof(amount)} can't be bigger than balance!");
            }

            Balance -= amount;
            BenefitPoints -= CalculateBenefitPoint(amount) / 2;
        }

        private bool CheckBalance(decimal balance, decimal amount) => balance >= amount;

        protected abstract int CalculateBenefitPoint(decimal amount);

        private string GenerateNumber()
        {
            Random random = new Random();
            return random.Next(10000000).ToString();
        }
    }
}
