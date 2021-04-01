using System;
using System.Collections.Generic;
using System.Linq;
using BankingAPI.Models;

namespace BankingAPI.Business
{
    public class TransactionManager
    {
        private List<Transaction> _transactions = new List<Transaction>()
        {
         new Transaction() {  receiverAccountNumber=123, senderAccountNumber=113, amount=10 },
         new Transaction() { receiverAccountNumber=123, senderAccountNumber=100, amount=10  },



        };

        public Transaction Create(Transaction transaction)
        {
            _transactions.Add(transaction);
            return transaction;
        }

        public List<Transaction> GetTransactions()
        {

            return _transactions;
        }

    }
}
