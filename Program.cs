using System;
using Welch_Bank;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography.X509Certificates;
using System.Security.Policy;
using Microsoft.Win32;

namespace Welch_Bank
{
        internal class Program 
    {
        static void Main(string[] args)
        {

            while (true)
            {
                Utility.CenterText("Welcome to Welch_Bank");
                Console.WriteLine("What will you like to do:");
                Console.WriteLine(@"
                       1 => Create Account
                       2 => Make Deposit
                       3 => Make Withdrawal
                       4 => Make Transfer
                       5 => Single User Bank Account Info
                       6 => Bank Account Statement
                     7=> exit
                       ");
                
                var Selection = Utility.ValidInput("Your Options: ", 7);
                if (Selection == 7)
                {
                    break;
                }
                switch (Selection)
                {
                    case 1:
                        while (true)
                        {
                            Console.Clear();
                            Utility.CenterText("Welcome to Welch_Bank");
                            Console.WriteLine();
                            Utility.CenterText("Create Account Session");
                            Console.WriteLine();
                            Console.WriteLine();
                            Console.WriteLine();
                            Console.WriteLine("How many account do you want to create");
                            
                            var howmany= Utility.GetValidInputInt("Your Options:\t");

                            while(howmany > 0)
                            {
                                Console.WriteLine();
                                Console.WriteLine();
                                Console.Write("Please enter the account owners first name? ");
                                var accountnfame = Console.ReadLine();
                                Console.Write("Please enter the account owners last name? ");
                                var accountlname = Console.ReadLine();
                                Console.WriteLine("Please enter the account type? 1. Saving 2. Current");
                               
                                var accountType = Utility.ValidInput("Your Options: ",2);
                                Console.Write("Please enter the account email?  ");
                                var email = Console.ReadLine();
                                Console.Write("Please enter the account owner phone number?  ");
                                var phone_num = Console.ReadLine();

                                var initialDeposit = Utility.GetValidInput("Please enter the initial account deposit?  ");
                                Console.Write("Please enter the account description? ");
                                var Note = Console.ReadLine();
                                try
                                {
                                    BankAccount.CreateAccount(accountType == 1? bankAccountType.Saving : bankAccountType.Current, initialDeposit,accountnfame,accountlname,email,phone_num,Note);
                                }
                                catch (Exception ex)
                                {

                                    Console.WriteLine(ex.Message);
                                    Console.WriteLine();
                                }
                               howmany--;
                            }
                            Console.WriteLine("Do you want to create more account ? 1. Yes 2. No ");
                           
                            var creatOption = Utility.ValidInput("Your Options: ",2);
                            if (creatOption != 1)
                            {

                                break;
                            }
                            else
                            {
                                Console.Clear();
                            }
                        }
                       
                        break;
                    case 2:
                        while (true)
                        {
                            Console.Clear();
                            Utility.CenterText("Welcome to Welch_Bank");
                            Console.WriteLine();
                            Utility.CenterText("Deposit to Account Session");
                            Console.WriteLine();
                            Console.WriteLine();
                            Console.WriteLine();
                            Console.WriteLine("Bank Account available for deposit");
                            Console.WriteLine();
                            BankAccount.printAllBankDbWIthFullnameAnddAcctNo();
                            Console.WriteLine();
                            Console.WriteLine();
                            Console.Write("Please enter the account owner full name:\t");
                            var accountfname = Console.ReadLine();
                            Console.Write(" Please enter the account number you want to deposit to:\t");
                            var accountNO = Console.ReadLine();

                            var Deposit = Utility.GetValidInput("Please enter the amount you want to deposit to the account:\t");
                            Console.Write("Please enter the deposit description? ");
                            var Note = Console.ReadLine();
                            try
                            {
                                BankAccount.MakeDepositToAccount(accountfname, accountNO, Deposit, Note);
                            }
                            catch (Exception ex)
                            {

                                Console.WriteLine(ex.Message);
                            }
                            Console.WriteLine("Do you want to deposit more on your account ? 1. Yes 2. No ");
                            Console.Write("Your Options: ");
                            var depotOption = Utility.ValidInput("Your Options: ", 2);
                            if (depotOption != 1)
                            {

                                break;
                            }
                            else
                            {
                                Console.Clear();
                            }
                            
                        }
                        break;
                    case 3:
                        while (true)
                        {
                            Console.Clear();
                            Utility.CenterText("Welcome to Welch_Bank");
                            Console.WriteLine();
                            Utility.CenterText("Withdraw from Account Session");
                            Console.WriteLine();
                            Console.WriteLine();
                            Console.WriteLine();
                            Console.WriteLine("Bank Account available for Withdrawer");
                            Console.WriteLine();
                            BankAccount.printAllBankDbWIthFullnameAnddAcctNo();
                            Console.WriteLine();
                            Console.WriteLine();
                            Console.Write("Please enter the account owner full name:\t");
                            var accountfname = Console.ReadLine();
                            Console.Write(" Please enter the account number you want to withdraw from:\t");
                            var accountNO = Console.ReadLine();
                      
                            var Deposit = Utility.GetValidInput("Please enter the amount you want to withdraw from the account?\t");
                            Console.Write("Please enter the withdraw description? ");
                            var Note = Console.ReadLine();
                            try
                            {
                                BankAccount.WithdrawFromAccount(accountfname, accountNO, Deposit, Note);
                            }
                            catch (Exception ex)
                            {

                                Console.WriteLine(ex.Message);
                            }
                            Console.WriteLine("Do you want to withdraw more on your account ? 1. Yes 2. No ");
                            Console.Write("Your Options: ");
                            var depotOption = Utility.ValidInput("Your Options: ", 2);
                            if (depotOption != 1)
                            {

                                break;
                            }
                            else
                            {
                                Console.Clear();
                            }

                        }
                        break;
                    case 4:
                        while (true)
                        {
                            Console.Clear();
                            Utility.CenterText("Welcome to Welch_Bank");
                            Console.WriteLine();
                            Utility.CenterText("Transfer between Account Session");
                            Console.WriteLine();
                            Console.WriteLine();
                            Console.WriteLine();
                            Console.WriteLine("Bank Account available for Transfer between");
                            Console.WriteLine();
                            BankAccount.printAllBankDbWIthFullnameAnddAcctNo();
                            Console.WriteLine();
                            Console.WriteLine();
                            Console.Write("Please enter the sender account owner full name:\t");
                            var accountfname = Console.ReadLine();
                            Console.Write(" Please enter the sender account number you want to transfer from:\t");
                            var accountNO = Console.ReadLine();
                            Console.Write("Please enter the beneficiary account owner full name:\t");
                            var Ben_accountfname = Console.ReadLine();
                            Console.Write(" Please enter the beneficiary account number you want to transfer to:\t");
                            var Ben_accountNO = Console.ReadLine();
                            var amount = Utility.GetValidInput("Please enter the amount you want to transfer from the sender account?\t");
                            Console.Write("Please enter the transfer description? ");
                            var Note = Console.ReadLine();
                            try
                            {
                                BankAccount.MakeTransfer(amount,accountNO,accountfname,Ben_accountNO,Ben_accountfname,Note);
                            }
                            catch (Exception ex)
                            {

                                Console.WriteLine(ex.Message);
                            }
                            Console.WriteLine("Do you want to perfrom another Transfer between account ? 1. Yes 2. No ");
                            Console.Write("Your Options: ");
                            var depotOption = Utility.ValidInput("Your Options: ", 2);
                            if (depotOption != 1)
                            {

                                break;
                            }
                            else
                            {
                                Console.Clear();
                            }

                        }
                        break;
                    case 5:
                        while (true)
                        {
                            Console.Clear();
                            Utility.CenterText("Welcome to Welch_Bank");
                            Console.WriteLine();
                            Utility.CenterText("Retrieve Account Info Session");
                            Console.WriteLine();
                            Console.WriteLine();
                            Console.WriteLine();
                            Console.WriteLine("Bank Account available for retrieval");
                            Console.WriteLine();
                            BankAccount.printAllBankDbWIthFullnameAnddAcctNo();
                            Console.WriteLine();
                            Console.WriteLine();
                            Console.Write("Please enter the account owner full name you want to retrieve its information:\t");
                            var accountfname = Console.ReadLine();
                            Console.Write(" Please enter the account number you want to retrieve its information:\t");
                            var accountNO = Console.ReadLine();
                            Console.WriteLine();
                            BankAccount.PrintSingleBank(accountfname, accountNO);
                            Console.WriteLine();
                            Console.WriteLine("Do you want to view another account information ? 1. Yes 2. No ");
                            Console.Write("Your Options: ");
                            var depotOption = Utility.ValidInput("Your Options: ", 2);
                            if (depotOption != 1)
                            {

                                break;
                            }
                            else
                            {
                                Console.Clear();
                            }

                        }
                        break;
                    case 6:
                        while (true)
                        {
                            Console.Clear();
                            Utility.CenterText("Welcome to Welch_Bank");
                            Console.WriteLine();
                            Utility.CenterText("View All Account in Bank Session");
                            Console.WriteLine();
                            Console.WriteLine();
                            Console.WriteLine();
                            BankAccount.PrintAllBank();
                            Console.WriteLine();
                            Console.WriteLine();
                            
                            Console.WriteLine("Do you want to view all bank account again? 1. Yes 2. No ");
                            Console.Write("Your Options: ");
                            var depotOption = Utility.ValidInput("Your Options: ", 2);
                            if (depotOption != 1)
                            {

                                break;
                            }
                            else
                            {
                                Console.Clear();
                            }

                        }
                        break;
                    default:
                        break;
                }
                Console.WriteLine("Do you want to end your program ? 1. Yes 2. No ");
                var option = Utility.ValidInput("Your Options: ", 2);
                if(option == 1) {
                    
                    break;
                }
                else
                {
                    Console.Clear();
                }
            }
            
            



        }
    }
}
