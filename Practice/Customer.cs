using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Bonus_Lab
{/*
    class Customer
    {
        public  string name;
        //public CheckingAccount checkingAccount;
        //public SavingAccount savingAccount;

        public Customer(string name)
        {
            this.name = name;
            //this.checkingAccount = new CheckingAccount();
            //this.savingAccount = new SavingAccount();
        }

        /* public void DepositToChecking(double amount)
         {
             checkingAccount.Deposit(amount);
         }

         public void DepositToSaving(double amount)
         {
             savingAccount.Deposit(amount);
         }

         public void WithdrawFromChecking(double amount)
         {
             checkingAccount.Withdraw(amount);
         }

         public void WithdrawFromSaving(double amount)
         {
             savingAccount.Withdraw(amount);
         }

         public void TransferFromCheckingToSaving(double amount)
         {
             if (checkingAccount.Balance < amount)
             {
                 Console.WriteLine("Transfer amount exceeds the balance of the checking account.");
                 return;
             }

             double transferAmount = amount;
             if (amount + SavingAccount.penaltyAmount > savingAccount.Balance)
             {
                 transferAmount = savingAccount.Balance - SavingAccount.penaltyAmount;
             }

             checkingAccount.Withdraw(transferAmount);
             savingAccount.Deposit(transferAmount);

             Console.WriteLine("Transfer successful. Transferred {0:C} from checking account to saving account.", transferAmount);
         }

         public void TransferFromSavingToChecking(double amount)
         {
             if (savingAccount.Balance < amount)
             {
                 Console.WriteLine("Transfer amount exceeds the balance of the saving account.");
                 return;
             }

             checkingAccount.Deposit(amount);
             savingAccount.Withdraw(amount);

             Console.WriteLine("Transfer successful. Transferred {0:C} from saving account to checking account.", amount);
         }

         /*public void ActivityEnquiry()
         {
             Console.WriteLine($"Activity Enquiry for {name}:");
             Console.WriteLine($" {"Date",12}  {"Amount",12} {"Activity",12}");
             Console.WriteLine($"{checkingAccount.AccountType,12}");
             checkingAccount.DisplayTransactionHistory(double amount);
             Console.WriteLine($"{savingAccount.AccountType,12}");
             savingAccount.DisplayTransactionHistory(double amount);
         }

         public void BalanceEnquiry()
         {
             Console.WriteLine("Current balance for customer {0}:", name);
             Console.WriteLine("Checking Account balance: {0:C}", checkingAccount.Balance);
             Console.WriteLine("Saving Account balance: {0:C}", savingAccount.Balance);
         }
    }*/
}



