using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankAccountLibrary.Account;

namespace BankAccountLibrary.Repository
{
    public interface IRepository
    {
        void Save(BankAccount account);

        BankAccount GetByNumber(string accountNumber);
    }
}
