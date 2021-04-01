using System;
namespace BankingAPI.Models
{
    public class Account
    {
        public int accountNumber { get; set; }
        public string currencyCode { get; set; }
        public decimal balance { get; set; }

    }
}
