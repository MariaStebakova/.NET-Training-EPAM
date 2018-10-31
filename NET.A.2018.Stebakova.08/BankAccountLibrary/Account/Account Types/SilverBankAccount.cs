using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountLibrary.Account.Account_Types
{
    public class SilverBankAccount: BankAccount
    {
        private const decimal DefaultBenefit = 0.05m;

        public SilverBankAccount(AccountOwner owner) : base(owner)
        {

        }

        public SilverBankAccount(AccountOwner owner, decimal balance, int benefitPoints) : base(owner, balance, benefitPoints)
        {

        }

        protected override int CalculateBenefitPoint(decimal amount)
        {
            return (int)Math.Round(DefaultBenefit * (amount + Balance));
        }
    }
}
