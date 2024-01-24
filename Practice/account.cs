using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bonus_Lab
{
    public class Account
    {    
        public double balance = 0 ;
        public List<string> transactions = new List<string>();
        public List<string> Date = new List<string>();
        public List<string> Amounts = new List<string>();
        public static string transactionDate;
        public bool lastTransactionState = true;
        public Account()
        {
            transactionDate = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");

            this.Balance = balance;
        }
        
        public double Balance { get { return balance; } set { balance = value; } }


        public void transactionHistory(int action, double value)
        {
            Amounts.Add("$" + value);
            Date.Add(transactionDate);
            if (action == 1)
            {
                transactions.Add("DEPOSIT");
            }

            else if (action == 2)
            {
                transactions.Add("WITHDRAW");
            }

            else if (action == 3)
            {
                transactions.Add("DEPOSIT: INTREST");
            }

            else if (action == 4)
            {
                transactions.Add("PENALTY");
            }

            else if (action == 5)
            {
                transactions.Add("TRANSFER: TRANSFER_IN");
            }

            else if (action == 6)
            {
                transactions.Add("TRANSFER: TRANSFER_OUT");
            }
        }

        public virtual void deposit(double amount)
        {
            this.Balance += amount;
            this.Balance = Math.Round(this.Balance, 2);
            //transactionHistory(1, amount);
        }

        public virtual void withdraw(double amount)
        {

            if (Balance >= amount)
            {
                this.Balance -= amount;
                this.Balance = Math.Round(this.Balance, 2);
                //transactionHistory(2, amount);
            }

            //else
            //{
               // throw new ArgumentException("Insufficient funds.");
           // }
            
        }                  
        public virtual void activityEnquiry()
        {
            string header = string.Format("{0,-20}\t{1,-20}\t{2}\n", "Amount", "Date", "Activity");
            string underline = string.Format("{0,-20}\t{1,-20}\t{2}\n", "______", "____", "________");

            Console.WriteLine(header + underline);

            for (int i = 0; i < Amounts.Count; i++)
            {
                string line = string.Format("{0,-20}\t{1,-20}\t{2}\n", Amounts[i], Date[i], transactions[i]);
                Console.WriteLine(line);
            }
        }
        public static void transfer(int userSelected, double transferAmount, SavingAccount Saving, CheckingAccount Checking)
        {
            if (userSelected == 1)
            {
                Checking.withdraw(transferAmount);
                Saving.deposit(transferAmount);
                Checking.transactionHistory(6, transferAmount);
                Saving.transactionHistory(5, transferAmount);

                Console.WriteLine("\n\tTransfer completed");
            }
            else if (userSelected == 2)
            {
                Saving.withdraw(transferAmount);
                Checking.deposit(transferAmount);
                Saving.transactionHistory(6, transferAmount);
                Saving.transactionHistory(4, SavingAccount.penaltyAmount);
                Checking.transactionHistory(5, transferAmount);

                Console.WriteLine("\n\tTransfer completed");
            }
            else
            {
                throw new ArgumentException("Insufficient funds.");
            }
        }
        public void balenceEnquiry(CheckingAccount Checking, SavingAccount Saving)
        {
            Console.WriteLine("\nCurrent balance:");
            Console.WriteLine("Account                Balance");
            Console.WriteLine("-------                -------");
            Console.WriteLine($"Checking                {Checking.balance}");
            Console.WriteLine($"Saving                  {Saving.balance}\n");
        }

        public void DisplayTransactionHistory(double amount)
            {
                Console.WriteLine($"{"Date",12} {"Amount",12} {"Activity",12}");
                foreach (var transaction in transactions)
                {
                    Console.WriteLine($"{DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss"),12:d} {"Amount",12}");
                }
            }
        public void AddTransaction(string transactionType, double amount)
        {
            string transaction = string.Format("{0}\t{1}\t{2}", DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss"), transactionType, amount.ToString("C"));
            transactions.Add(transaction);
        }
        public virtual void DisplayAccountInfo()
        {
            Console.WriteLine("Account balance: {0:C}", Balance);
            Console.WriteLine("Transaction history:");
            Console.WriteLine("Date\t\t\tTransaction Type\tAmount");
            foreach (string transaction in transactions)
            {
                Console.WriteLine(transaction);
            }
        }

    }

}
//{transactionType,12} {amount.ToString("C"),12:C}