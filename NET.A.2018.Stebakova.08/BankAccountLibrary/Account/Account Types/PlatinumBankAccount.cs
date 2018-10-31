using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountLibrary.Account.Account_Types
{
    public class PlatinumBankAccount: BankAccount
    {
        private const decimal DefaultBenefit = 0.5m;

        public PlatinumBankAccount(AccountOwner owner) : base(owner)
        {

        }

        public PlatinumBankAccount(AccountOwner owner, decimal balance, int benefitPoints) : base(owner, balance, benefitPoints)
        {

        }

        protected override int CalculateBenefitPoint(decimal amount)
        {
            return (int)Math.Round(DefaultBenefit * (amount + Balance));
        }
    }
}
