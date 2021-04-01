using System;
using System.Collections.Generic;
using System.Linq;
using BankingAPI.Models;

namespace BankingAPI.Business
{
    public class AccountManager
    {
        private List<Account> _accounts = new List<Account>()
        {
         new Account() { accountNumber=123, balance=100, currencyCode="TRY" },
         new Account() { accountNumber = 113, balance = 100, currencyCode = "TRY" },
         new Account() { accountNumber = 103, balance = 100, currencyCode = "TRY" },
         new Account() { accountNumber = 133, balance = 100, currencyCode = "TRY" }


        };


        public Account Create(Account account)
        {
            _accounts.Add(account);
            return account;
        }

        public List<Account> GetAccounts()
        {


            return _accounts;
        }

        public Account Find(int accNumber)
        {
            if (accNumber!=null)
            {
                var account = _accounts.Find(i => i.accountNumber == accNumber);
                if (account != null)
                {
                    return account;
                }
            }
            return null;
        }


    }
}
