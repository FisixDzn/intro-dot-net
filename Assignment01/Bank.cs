public class Bank
{
    public string Name {get; set;}
    public BankAccount[] AccountList {get; set;}
    public int NextOpenIndex {get; set;}

    public Bank(string bankName, int maxNumAccounts)
    {
        this.Name = bankName;
        this.AccountList = new BankAccount[maxNumAccounts];
        this.NextOpenIndex = 0;
        System.Console.WriteLine("Bank " + bankName + " has been successfully created.");
    }

    public Bank(string bankName, BankAccount[] bankAccounts)
    {
        this.Name = bankName;
        this.AccountList = new BankAccount[bankAccounts.Length];
        for(int i = 0; i < bankAccounts.Length; i++)
        {
            this.AccountList[i] = bankAccounts[i];
        }
        this.NextOpenIndex = bankAccounts.Length;
        System.Console.WriteLine("Bank " + bankName + " has been successfully created with " + this.NextOpenIndex + "/" + bankAccounts.Length + " spaces filled.");
    }

    public bool AddAccount(BankAccount account)
    { 
        for(int i = 0; i < NextOpenIndex; i++)
        {
            if(account.AccountNumber.Equals(AccountList[i].AccountNumber))
            {
                System.Console.WriteLine("Cannot add account: This account already exists.");
                return false;
            }
        }
        if(AccountList.Length > NextOpenIndex)
        {
            AccountList[NextOpenIndex] = account;
            System.Console.WriteLine("Account " + account.AccountNumber + " has been added to " + Name + " in position " + (NextOpenIndex + 1) + "/" + AccountList.Length + ".");
            NextOpenIndex++;
            return true;
        }
        else if(AccountList.Length <= NextOpenIndex)
        {
            System.Console.WriteLine("Sorry, the bank doesn't have any more room for this account.");
            return false;
        }
        else
        {
            System.Console.WriteLine("unexpected error with adding this account.");
            return false;
        }
    }
    public bool Transfer(BankAccount accTransferFrom, BankAccount accTransferTo, double amount)
    {
        if((accTransferFrom.Balance - amount) >= BankAccount.MaxNegativeAmount)
        {
            accTransferFrom.Balance -= amount;
            accTransferTo.Balance += amount;
            System.Console.WriteLine("Transfer of $" + amount + " from " + accTransferFrom.AccountNumber + " to " + accTransferTo.AccountNumber + " was successful.");
            return true;
        }
        else if((accTransferFrom.Balance - amount) < BankAccount.MaxNegativeAmount)
        {
            System.Console.WriteLine("Transfer not completed. Insufficient funds in account " + accTransferFrom.AccountNumber);
            return false;
        }
        else
        {
            System.Console.WriteLine("unexpected error with your transfer.");
            return false;
        }
    }

    public bool AccountExists(string accountNumber)
    {
        for(int i = 0; i < NextOpenIndex; i++)
        {
            if(AccountList[i].AccountNumber.Equals(accountNumber))
            {
                System.Console.WriteLine("Account " + AccountList[i].AccountNumber + " found in position " + (i + 1) + ".");
                return true;
            }
        }
        System.Console.WriteLine("Account was not found.");
        return false;
    }

    public int Capacity()
    {
        int amountOfSpaces = AccountList.Length - NextOpenIndex;
        System.Console.WriteLine("Amount of spaces left in " + Name + ": " + amountOfSpaces);
        return amountOfSpaces;
    }
}