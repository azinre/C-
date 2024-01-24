using Bonus_Lab;
using System;
using System.Transactions;
using System.Xml.Linq;
class Bank
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Banking System!");

        // Prompt user for name
        Console.Write("Enter your name: ");
        string? customerName = Console.ReadLine();


        //Customer customer = new Customer(customerName);
        Console.WriteLine("Hello, " + customerName + ". Please select one of the following activities:");

        CheckingAccount checking = new CheckingAccount();
        SavingAccount saving = new SavingAccount();
        Account account = new Account();
        
        bool exit = false;

        while (!exit)
        {
            try
            {
                Console.WriteLine("\nWhat would you like to do?");
                Console.WriteLine("1. Deposit");
                Console.WriteLine("2. Withdraw");
                Console.WriteLine("3. Transfer");
                Console.WriteLine("4. Activity Enquiry");
                Console.WriteLine("5. Balance Enquiry");
                Console.WriteLine("6. Exit");

                Console.WriteLine("Enter your selection (),1 to 6: ");
                int choice = Convert.ToInt32(Console.ReadLine());

                if (choice == 1)
                {
                    Console.Write("\nSelect Account (1- Checking Account, 2- Saving Account): ");
                    string type = Console.ReadLine();
                    if (type == "1")
                    {
                        Console.Write("Enter deposit amount: ");
                        double checkingWithdrawAmount = double.Parse(Console.ReadLine());
                        checking.deposit(checkingWithdrawAmount);
                        checking.transactionHistory(1, checkingWithdrawAmount);
                        Console.WriteLine($"\n\t deposit successful.account current balance: ${checking.balance}\n");
                        
                    }
                    else if (type == "2")
                    {
                        Console.Write("Enter deposit amount: ");
                        double savingDepositAmount = double.Parse(Console.ReadLine());
                        saving.deposit(savingDepositAmount);
                        double interestAmount = savingDepositAmount * SavingAccount.interestRate;
                        saving.transactionHistory(1, savingDepositAmount);
                        saving.transactionHistory(3, interestAmount);
                        Console.WriteLine($"Deposit successful. Interest amount: {interestAmount:C} account current balance: ${saving.balance}\n");
                    }
                    else
                   { 
                        Console.WriteLine("Please chhose the right account.");
                    }
                }
                if (choice == 2)
                {
                    Console.Write("\nSelect Account (1- Checking Account, 2- Saving Account): ");
                    string type = Console.ReadLine();
                    if (type == "1")
                    {
                        Console.Write("Enter withdraw amount: ");
                        double checkingWithdrawAmount = double.Parse(Console.ReadLine());
                        checking.listofWithdraw.Add(checkingWithdrawAmount);
                        if (checking.listofWithdraw.Sum() <= CheckingAccount.dailyWithdrawLimit)
                        {
                            checking.withdraw(checkingWithdrawAmount);
                            if (checking.lastTransactionState)
                            {
                                checking.transactionHistory(2, checkingWithdrawAmount);
                                Console.WriteLine($"\n\tWithdraw completed, account current balance ${checking.balance}");
                            }
                        }
                        else
                        {
                            checking.listofWithdraw.RemoveAt(checking.listofWithdraw.Count - 1);
                            Console.WriteLine("\n\tExceed the daily max withdraw amount $300");
                        }
                        
                    }
                    else if (type == "2")
                    {
                        Console.Write("Enter withdraw amount: ");
                        double savingWithdrawAmount = double.Parse(Console.ReadLine());
                        saving.withdraw(savingWithdrawAmount);
                        if (saving.lastTransactionState )
                        {
                            saving.transactionHistory(2, savingWithdrawAmount);
                            saving.transactionHistory(4, SavingAccount.penaltyAmount);
                            Console.WriteLine($"Withdraw successful. Penalty amount: {SavingAccount.penaltyAmount:C},  account current balance ${saving.balance}");
                        }
                        
                    }else
                    {
                        Console.WriteLine("Please chhose the right account.");
                    }
                }
                if (choice == 3)
                {
                    Console.Write("\nSelect Account (1- Checking Account, 2- Saving Account): ");
                    string type = Console.ReadLine();
                    if (type == "1")
                    {
                        
                        Console.Write("Enter amount of transfer: ");
                        double TransferFromCheckingToSaving = double.Parse(Console.ReadLine());
                        Account.transfer(1, TransferFromCheckingToSaving, saving, checking);
                        //checking.withdraw(TransferFromCheckingToSaving);
                        //saving.deposit(TransferFromCheckingToSaving);
                        //Console.WriteLine("Transfer successfully!");
                    }
                    else if (type == "2")
                    {
                        Console.Write("Enter amount of transfer: ");
                        double TransferFromSavingToChecking = double.Parse(Console.ReadLine());
                        Account.transfer(2, TransferFromSavingToChecking, saving, checking);
                        //saving.withdraw(TransferFromSavingToChecking);
                        //checking.deposit(TransferFromSavingToChecking);
                        //saving.withdraw(SavingAccount.penaltyAmount);
                    }
                    else
                    {
                        Console.WriteLine("Please chhose the right account.");
                    }
                }
                if (choice == 4)
                {
                    checking.activityEnquiry();
                    saving.activityEnquiry();
                    
                }
                if (choice == 5)
                {
                    account.balenceEnquiry(checking, saving);
                }
                if (choice == 6)
                {
                    Console.WriteLine("\nThank you for using Algonquin Banking System!");
                    exit = true;
                }
                else
                {
                    Console.WriteLine("\n\t Enter a valid option between 1 and 6!.");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }


        }
    }
}

    /*
                Console.Write("Enter deposit amount: ");
                double checkingDepositAmount = double.Parse(Console.ReadLine());
                customer.Deposit(checkingDepositAmount, AccountType.Checking);
                Console.WriteLine("Deposit successful.");
                break;

            case "2":
                Console.Write("Enter deposit amount: ");
                double savingDepositAmount = double.Parse(Console.ReadLine());
                customer.Deposit(savingDepositAmount, AccountType.Saving);
                double interestAmount = savingDepositAmount * SavingAccount.InterestRate;
                Console.WriteLine($"Deposit successful. Interest amount: {interestAmount:C}");
                break;

           
        }
    }

    static void Withdraw(Customer customer)
    {
        Console.WriteLine("\nWhich account would you like to withdraw from?");
        Console.WriteLine("1. Checking Account");
        Console.WriteLine("2. Saving Account");

        string choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                Console.Write("Enter withdraw amount: ");
                double checkingWithdrawAmount = double.Parse(Console.ReadLine());
                customer.
                customer.WithdrawFromChecking(checkingWithdrawAmount);
                Console.WriteLine("Withdraw successful.");
                break;

            case "2":
                Console.Write("Enter withdraw amount: ");
                double savingWithdrawAmount = double.Parse(Console.ReadLine());
                customer.Withdraw(savingWithdrawAmount);
                double penaltyAmount = SavingAccount.PenaltyAmount;
                Console.WriteLine($"Withdraw successful. Penalty amount: {penaltyAmount:C}");
                break;

            default:
                Console.WriteLine("Invalid choice. Please try again.");
                break;
        }
    }*/
    




    


  


