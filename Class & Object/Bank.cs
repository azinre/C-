using Lab4._1;
using System.Xml.Linq;
class Bank
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter the number of months to deposit: ");
        int months = Convert.ToInt32(Console.ReadLine());

        var accounts = new List<Account>();

        while (true)
        {
            Console.WriteLine("Enter customer's name: ");
            string name = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(name))
            {
                break;
            }

            Console.WriteLine("Enter " + name + "'s initial deposit amount (minimum  $1,000.00): ");
            double initialDeposit = Convert.ToDouble(Console.ReadLine());
            while (initialDeposit < Account.MinimumInitialBalance)
            {
                Console.WriteLine($"The minimum initial deposit amount is {Account.MinimumInitialBalance}. Enter again:");
                initialDeposit = Convert.ToDouble(Console.ReadLine());
            }

            Console.WriteLine("Enter " + name + "'s monthly deposit amount (minimum $50.00): ");
            double monthlyDeposit = Convert.ToDouble(Console.ReadLine());
            while (monthlyDeposit < Account.MinimumMonthlyDeposit)
            {
                Console.WriteLine($"The minimum monthly deposit amount is {Account.MinimumMonthlyDeposit}. Enter again:");
                monthlyDeposit = Convert.ToDouble(Console.ReadLine());
            }
            Console.WriteLine("");

            var account = new Account(name, initialDeposit);
            account.MonthlyDepositAmount = monthlyDeposit;
            accounts.Add(account);
        }
        foreach (var account in accounts)
        {
            for (int i = 0; i < months; i++)
            {
                account.Withdraw(Account.MonthlyFee);
                account.Deposit(account.Balance * Account.MonthlyInterestRate);
                account.Deposit(account.MonthlyDepositAmount);
            }
            Console.WriteLine(" After " + months + " month," + account.OwnerName + "'s account (#" + account.AccountNumber + "), has a balance of : "+ account.Balance.ToString("C"));

        }
        Console.WriteLine("Press Enter To Compelete");
    }
   
}

