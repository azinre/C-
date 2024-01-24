using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Bonus_Lab
{
    public class SavingAccount : Account
    {
        public static double interestRate = 0.03;
        public static double penaltyAmount = 10;
        public string AccountType { get; }
        public SavingAccount() 
        {

        }
        public SavingAccount(double initialBalance = 0) : base()
        {
           interestRate = 0.03;
            penaltyAmount = 10;
            this.Balance = initialBalance;
        }

        public override void deposit(double amount)
        {
            base.deposit(amount);            
            double interest = amount * interestRate;
            this.Balance += interest;
            //transactionHistory(3, amount);
           
        }

        public override void withdraw(double amount)
        {
            if (this.Balance >= amount + penaltyAmount)
            {
                base.withdraw(amount);
                this.Balance -=  penaltyAmount;
                //transactionHistory(4, amount);
                //AddTransaction("Withdraw", -amount - penaltyAmount);
                lastTransactionState = true;
            }
            else
            {
                Console.WriteLine($"\n\tInsufficient funds. account current balance: ${balance}");
                lastTransactionState = false;
            }
        }

        public override void activityEnquiry()
        {
            Console.WriteLine($"Saving Account:\n\n");
            base.activityEnquiry();
        }
        /*public void Transfer(double amount, Account toAccount)
        {
            if (this.Balance >= amount + penaltyAmount)
            {
                this.Balance -= amount + penaltyAmount;
                toAccount.Deposit(amount);
                AddTransaction("Transfer", -amount - penaltyAmount);
            }
            else
            {
                Console.WriteLine("Insufficient funds.");
            }
        }*/

    }

}
