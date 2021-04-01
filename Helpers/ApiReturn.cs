using System;
namespace BankingAPI.Helpers
{
    public class ApiReturn<T>
    {
        public int referenceNumber { get; set; }
        public string errorName { get; set; }
        public bool isError { get; set; }

    }
}
