using System;
namespace BankingAPI.Models
{
    public class Transaction
    {
        public int senderAccountNumber { get; set; }
        public int receiverAccountNumber { get; set; }
        public decimal amount { get; set; }
    }
}
