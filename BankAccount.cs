using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using ConsoleTables;

namespace Welch_Bank
{
    public enum bankAccountType
    {
        Saving, Current
    }
    public class BankAccount
    {
        public decimal minimumAmountInSavingsAccount = 1000;
        #region Fields
        private string _accountNumber;
        private string Note;
        #endregion
        /// <summary>
        /// composite of the enum 
        /// </summary>
        public bankAccountType AccountTypes;
        public Customer customers;

        #region Properties
        public string AccountNumber { get; set; }
        public string AccountName { get; set; }

        public decimal Balance
        {
            get
            {
                decimal _balance = 0;
                foreach (var item in allTransactions)
                {
                    _balance += item.Amount;
                }
                return _balance;
            }
        }
        #endregion



        public BankAccount(bankAccountType accountType, decimal initialBalance, string firstname, string lastname, string email, string phone, string note)
        {
            AccountTypes = accountType;
            customers = new Customer(firstname, lastname, email, phone);
            AccountNumber = accountNumberSeed.ToString();
            Note = note;
            accountNumberSeed++;
            Console.WriteLine($"Account {AccountNumber} was created for {AccountName}");
            MakeDepositInitial(initialBalance, note);


        }

        List<Transactions> allTransactions = new List<Transactions>();
        public static List<BankAccount> accountsDb = new List<BankAccount>();

        private static int accountNumberSeed = 0324567891;


        #region
        public static void CreateAccount(bankAccountType accountType, decimal initialBalance, string firstname, string lastname, string email, string phone, string note)
        {
            foreach (var account in accountsDb)
            {
                if (account.customers.FirstName == firstname && account.customers.LastName == lastname && account.AccountTypes == accountType)
                {
                    throw new Exception("You cannot create multiple account of the same account type for a single user");
                }
            }

            BankAccount newAcct = new BankAccount(accountType, initialBalance, firstname, lastname, email, phone, note);
            accountsDb.Add(newAcct);

            Console.WriteLine("Your account have been created");


        }

        public void MakeDepositInitial(decimal amount, string note)
        {

            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of deposit must be positive");
            }
            var deposit = new Transactions(amount, DateTime.Now, note);
            allTransactions.Add(deposit);
            Console.WriteLine($"Account {_accountNumber} owned by {customers._fullname} was credited with ${amount}");


        }
        public void MakeDeposit(string Ben_accountOwner_fullname, string Ben_accountNumber, decimal amount, string note)
        {

            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount to be deposited must be positive");
            }
            var deposit = new Transactions(amount, DateTime.Now, note, Ben_accountNumber, Ben_accountOwner_fullname);
            allTransactions.Add(deposit);
            Console.WriteLine($"Account {Ben_accountNumber} owned by {Ben_accountOwner_fullname} was credited with ${amount} for transfer");


        }
        public static string printAllBankDbWIthFullnameAnddAcctNo()
        {
            foreach (var account in accountsDb)
            {
                return ($"{account.customers._fullname} {account.AccountNumber} {account.Balance}");

            }
            return "not foud";
        }
        public static void MakeDepositToAccount(string Ben_accountOwner_fullname, string Ben_accountNumber, decimal amount, string note)
        {

            Console.WriteLine();
            foreach (var account in accountsDb)
            {
                if (account.customers._fullname == Ben_accountOwner_fullname && account.AccountNumber == Ben_accountNumber)
                {
                    account.MakeDeposit(Ben_accountOwner_fullname, Ben_accountNumber, amount, note);
                    return;
                }


            }
            throw new NotImplementedException("User to make deposit not found");


        }


        public void MakeWithdrawal(string ben_accountOwner, string ben_accountNumber, decimal amount, string note)
        {

            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount to be  withdrawn must be positive");
            }

            if (AccountTypes == bankAccountType.Saving && Balance - amount < minimumAmountInSavingsAccount)
            {
                throw new InvalidOperationException("Not sufficient funds for this withdrawal");
            }
            if (AccountTypes == bankAccountType.Current && Balance - amount < 0)
            {
                throw new InvalidOperationException("Not sufficient funds for this withdrawal");
            }
            var withdrawal = new Transactions(-amount, DateTime.Now, note, ben_accountNumber, ben_accountOwner);
            allTransactions.Add(withdrawal);
            Console.WriteLine($"Account {_accountNumber} owned by {customers._fullname} was debited with ${amount}");

        }
        public static void WithdrawFromAccount(string Ben_accountOwner_fullname, string Ben_accountNumber, decimal amount, string note)
        {

            Console.WriteLine();
            foreach (var account in accountsDb)
            {
                if (account.customers._fullname == Ben_accountOwner_fullname && account.AccountNumber == Ben_accountNumber)
                {
                    account.MakeWithdrawal(Ben_accountOwner_fullname, Ben_accountNumber, amount, note);
                    return;
                }
            }
            throw new InvalidOperationException("User to withdraw from not available");
        }
        public static void MakeTransfer(decimal amount, string sen_accountNumber, string sen_accountOwnername, string ben_accountNumber, string ben_accountOwnername, string note)
        {
            WithdrawFromAccount(sen_accountOwnername, sen_accountNumber, amount, note);
            MakeDepositToAccount(ben_accountOwnername, ben_accountNumber, amount, note);


        }
        public static void PrintAllBank()
        {
            var myTable = new ConsoleTable("Full NAME", "ACCOUNT NUMBER", "ACCOUNT TYPE", "AMOUNT BAL", "NOTE");
            foreach (var account in accountsDb)
            {
                myTable.AddRow(account.customers._fullname, account.AccountNumber, account.AccountTypes, account.Balance, account.Note);

            }
            myTable.Write();
        }
        public static void PrintSingleBank(string accountOwnerFullname, string accountNumber)
        {
            var myTable = new ConsoleTable("Full NAME", "ACCOUNT NUMBER", "ACCOUNT TYPE", "AMOUNT BAL", "NOTE");
            foreach (var account in accountsDb)
            {
                if (account.customers._fullname.Equals(accountOwnerFullname) && account.AccountNumber.Equals(accountNumber))
                {
                    myTable.AddRow(account.customers._fullname, account.AccountNumber, account.AccountTypes, account.Balance, account.Note);
                }
            }
            myTable.Write();
        }
        public static BankAccount ReturnSingleBank(string accountOwnerFullname, string accountNumber)
        {
            foreach (var account in accountsDb)
            {
                if (account.customers._fullname.Equals(accountOwnerFullname) && account.AccountNumber.Equals(accountNumber))
                {
                    return account;
                }
            }
            throw new InvalidOperationException();

        }
    }
        #endregion
 }