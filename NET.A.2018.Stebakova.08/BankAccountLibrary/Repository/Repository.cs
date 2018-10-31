using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankAccountLibrary.Account;

namespace BankAccountLibrary.Repository
{
    public class Repository: IRepository
    {
        private static List<BankAccount> _accounts;

        public Repository()
        {
            _accounts = new List<BankAccount>();
        }

        public BankAccount GetByNumber(string accountNumber)
        {
            if (string.IsNullOrEmpty(accountNumber))
            {
                throw new ArgumentException($"{nameof(accountNumber)} can't be equal to null or empty!");
            }

            return _accounts.FirstOrDefault(x => x.AccountNumber == accountNumber);
        }

        public void Save(BankAccount account)
        {
            if (account == null)
            {
                throw new ArgumentNullException($"{nameof(account)} can't be equal to null!");
            }

            if (_accounts.Contains(account))
            {
                throw new ArgumentException($"{nameof(account)} is already in the repository!");
            }

            _accounts.Add(account);
        }
    }
}
