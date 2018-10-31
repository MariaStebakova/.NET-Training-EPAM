using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankAccountLibrary.Account;

namespace BankAccountLibrary.Service
{
    public interface IBankService
    {
        void OpenAccount(AccountOwner owner);

        void CloseAccount(string accountNumber);

        void Deposit(string accountNumber, decimal amount);

        void Withdraw(string accountNumber, decimal amount);
    }
}
