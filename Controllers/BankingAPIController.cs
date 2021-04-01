using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankingAPI.Business;
using BankingAPI.Helpers;
using BankingAPI.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BankingAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BankingAPIController : ControllerBase
    {
        public AccountManager _accountService;
        public TransactionManager _transactionService;
        
        
        public BankingAPIController(AccountManager accountService, TransactionManager transactionService)
        {
            _accountService = accountService;
            _transactionService = transactionService;

        }

        [HttpGet("GetAccounts")]
        // GET: /<controller>/
        public IEnumerable<Account> GetAccounts()
        {

           return  _accountService.GetAccounts();
           

        }


        [HttpPost]
        [Route("PostAccount")]
        public ActionResult<Account> PostAccount([FromBody]Account account)
        {
            string[] Code = new string[] { "TRY", "EUR", "USD" };
            var rand = new Random();
            var apireturn = new ApiReturn<Account>() { isError = false, referenceNumber = rand.Next(200), errorName = "" };
            if (_accountService.Find(account.accountNumber)!=null)
            {
                apireturn.errorName = "Account has alredy add";
                apireturn.isError = true;
                return BadRequest(apireturn); 
            }


            if (Code.Contains(account.currencyCode)==false)
            {
                apireturn.errorName = "Unsupported Currency Code";
                apireturn.isError = true;
                return BadRequest(apireturn);
            }

            _accountService.Create(account);

            

            return RedirectToAction("GetAccounts");
        }

        [HttpGet("GetTransactions")]
        // GET: /<controller>/
        public IEnumerable<Transaction> GetTransactions()
        {

            return _transactionService.GetTransactions();


        }

      

        [HttpPost]
        [Route("PostTransaction")]
        public ActionResult<Transaction> PostTransaction([FromBody] Transaction transaction)
        {
            var rand = new Random();
            var apireturn = new ApiReturn<Transaction>() { isError=false, referenceNumber=rand.Next(200), errorName=""};
            var senderAccount = _accountService.Find(transaction.senderAccountNumber);
            var receiveAccount = _accountService.Find(transaction.receiverAccountNumber);
            if (senderAccount!=null && receiveAccount!=null && senderAccount.currencyCode == receiveAccount.currencyCode&&senderAccount.balance>=transaction.amount)
            {
             _transactionService.Create(transaction);
                receiveAccount.balance += transaction.amount;
                senderAccount.balance = senderAccount.balance - transaction.amount;

              return Ok(apireturn);

            }
            if (senderAccount==null||receiveAccount==null)
            {
                apireturn.isError = true;
                apireturn.errorName = "Account Not Found";

                return BadRequest(apireturn);
            }
            if (senderAccount.balance<transaction.amount)
            {
                apireturn.isError = true;
                apireturn.errorName = "Balance Error";

                return BadRequest(apireturn);
            }

            else
            {
                apireturn.isError = true;
                return BadRequest(apireturn);
            }



           
        }




    }
}
