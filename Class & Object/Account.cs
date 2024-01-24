using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4._1
{
    internal class Account
    {
        public int AccountNumber { get; set; }
        public string OwnerName { get; set; }
        public double Balance { get; set; }
        public double MonthlyDepositAmount { get; set; }
        public static double MonthlyFee { get; } = 4.0;
        public static double MonthlyInterestRate { get; } = 0.0025;
        public static double MinimumInitialBalance { get; } = 1000;
        public static double MinimumMonthlyDeposit { get; } = 50;

        public Account(string ownerName, double initialDeposit)
        {
            this.AccountNumber = new Random().Next(90000, 100000);
            this.OwnerName = ownerName;
            this.Balance = Math.Round(initialDeposit, 2);
        }

        public void Deposit(double amount)
        {
            this.Balance += amount;
            this.Balance = Math.Round(this.Balance, 2); 
        }

        public void Withdraw(double amount)
        {
            this.Balance -= amount;
            this.Balance = Math.Round(this.Balance, 2);
        }
    }
}
