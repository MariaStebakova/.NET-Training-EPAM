using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BankAccountLibrary.Account
{
    public class AccountOwner
    {
        private readonly long ownerId;
        private string name;
        private string surname;
        private string email;
        private BankAccount account;

        public string Name
        {
            get { return name; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException($"{nameof(Name)} can't be equal to null or empty!");
                }

                if (!Regex.IsMatch(value, @"[A-Z]+[a-zA-Z]*"))
                {
                    throw new ArgumentException($"{nameof(Name)} is not correct");
                }

                name = value;
            }
        }

        public string Surname
        {
            get { return surname; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException($"{nameof(Surname)} can't be equal to null or empty!");
                }

                if (!Regex.IsMatch(value, @"[A-Z]+[a-zA-Z]*"))
                {
                    throw new ArgumentException($"{nameof(Name)} is not correct");
                }

                surname = value;
            }
        }

        public string Email
        {
            get { return email; } 
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException($"{nameof(Email)} can't be equal to null or empty!");
                }

                if (!Regex.IsMatch(value, @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})$"))
                {
                    throw new ArgumentException($"{nameof(Email)} must correspond \"name@email.com\".");
                }

                email = value;
            }
        }

        public AccountOwner(string name, string surname, string email, long ownerId)
        {
            Name = name;
            Surname = surname;
            Email = email;
            this.ownerId = ownerId;
        }

        public void AddAccount(BankAccount account)
        {
            if (account == null)
            {
                throw new ArgumentNullException($"{nameof(account)} can't be equal to null!");
            }

            this.account = account;
        }
    }
}
