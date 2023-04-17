using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Welch_Bank
{
    public class Transactions
    {
        public Transactions(decimal amount, DateTime date, string note, string accountNumber, string accountOwner)
        {

            Amount = amount;
            Date = date;
            Notes = note;
            AccountNumber = accountNumber;
            AccountOwner = accountOwner;
            
        }
        public Transactions(decimal amount, DateTime date, string note)
        {

            Amount = amount;
            Date = date;
            Notes = note;
         }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public string Notes { get; set; }
        public string AccountNumber { get; set; }
        public string AccountOwner { get; set; }
        public string AccountBalance { get; set; }

        
        
        
    }
}
