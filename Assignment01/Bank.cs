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
        bool accountAdded = false;
        for(int i = 0; i < this.NextOpenIndex; i++)
        {
            //account.AccountNumber.Equals(AccountList[i].AccountNumber)
            if(this.AccountExists(account.AccountNumber) != -1)
            {
                System.Console.WriteLine("Cannot add account: This account already exists.");
                return accountAdded;
            }
        }
        //AccountList.Length > NextOpenIndex
        if(this.Capacity() > 0)
        {
            AccountList[this.NextOpenIndex] = account;
            System.Console.WriteLine("Account " + account.AccountNumber + " has been added to " + Name + " in position " + (NextOpenIndex + 1) + "/" + AccountList.Length + ".");
            this.NextOpenIndex++;
            return accountAdded;
        }
        System.Console.WriteLine("Sorry, the bank doesn't have any more room for this account.");
        return accountAdded;
    }
    public bool Transfer(BankAccount accTransferFrom, BankAccount accTransferTo, double amount)
    {
        bool wasTransferred = false;
        if((accTransferFrom.Balance - amount) >= BankAccount.MaxNegativeAmount)
        {
            accTransferFrom.Balance -= amount;
            accTransferTo.Balance += amount;
            System.Console.WriteLine("Transfer of $" + amount + " from " + accTransferFrom.AccountNumber + " to " + accTransferTo.AccountNumber + " was successful.");
            return wasTransferred;
        }
        System.Console.WriteLine("Transfer not completed. Insufficient funds in account " + accTransferFrom.AccountNumber);
        return wasTransferred;
    }
    public int AccountExists(string accountNumber)
    {
        for(int i = 0; i < this.NextOpenIndex; i++)
        {
            if(AccountList[i].AccountNumber.Equals(accountNumber))
            {
                System.Console.WriteLine("Account " + AccountList[i].AccountNumber + " found in position " + (i + 1) + ".");
                return i;
            }
        }
        return -1;
    }
    public int Capacity()
    {
        int amountOfSpaces = AccountList.Length - NextOpenIndex;
        return amountOfSpaces;
    }
}