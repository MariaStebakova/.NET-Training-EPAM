using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankAccountLibrary.Account;
using BankAccountLibrary.Account.Account_Types;
using BankAccountLibrary.Repository;

namespace BankAccountLibrary.Service
{
    public class BankAccountService: IBankService
    {
        private IRepository repository;

        public IRepository Repository
        {
            get => repository;
            set
            {
                repository = value ?? throw new ArgumentException($"{nameof(Repository)} can't be equal to null!");
            }
        }

        public BankAccountService(IRepository repository)
        {
            Repository = repository;
        }

        public void OpenAccount(AccountOwner owner)
        {
            BankAccount account = new BaseBankAccount(owner);

            owner.AddAccount(account);
            Repository.Save(account);
        }

        public void CloseAccount(string accountNumber)
        {
            BankAccount account = Repository.GetByNumber(accountNumber);
        }

        public void Deposit(string accountNumber, decimal amount)
        {
            BankAccount account = Repository.GetByNumber(accountNumber);
            account.Deposit(amount);
        }

        public void Withdraw(string accountNumber, decimal amount)
        {
            BankAccount account = Repository.GetByNumber(accountNumber);
            account.Withdraw(amount);
        }
    }
}
