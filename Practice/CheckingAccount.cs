using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Bonus_Lab
{
    public class CheckingAccount : Account
    {
        public static readonly double dailyWithdrawLimit = 300;
        public string AccountType { get; }
        public List<double> listofWithdraw = new List<double>();

        public CheckingAccount() : base()
        {

        }

        public override void deposit(double amount)
        {
            base.deposit(amount);
        }

        public override void withdraw(double amount)
        {
            if (Balance >= amount )
            {
                base.withdraw(amount);
                lastTransactionState = true;
            }

            /*else if (amount > dailyWithdrawLimit)
            {
                Console.WriteLine("Withdraw amount exceeds the daily limit.");
                lastTransactionState = true;
            }*/

            else 
            {
                Console.WriteLine("Withdraw amount exceeds the balance.");
                lastTransactionState = false;
            }
        }

        /*public override void Transfer(Account toAccount, double amount)
        {
            if (this.Balance < amount )
            {
                Console.WriteLine("Transfer amount exceeds the balance.");
                return;
            }

            if (toAccount is CheckingAccount)
            {
                base.Transfer(toAccount, amount);
            }
            else
            {
                base.Transfer(toAccount, amount);
                
            }
        }*/
        public override void activityEnquiry()
        {
            Console.WriteLine($"Checking Account:\n\n");

            base.activityEnquiry();

        }
        public override void DisplayAccountInfo()
        {
            base.DisplayAccountInfo();
            Console.WriteLine("Account Type: Checking Account");
            Console.WriteLine("Daily Withdraw Limit: " + dailyWithdrawLimit);
        }

    }

}
