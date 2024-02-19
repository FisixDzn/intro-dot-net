public class BankAccount
{
    public static double MaxNegativeAmount {get; private set;} = -50.0;
    public Bank HoldingBank {get; set;}
    public string AccountNumber {get; set;}
    public double Balance {get; set;}

    public BankAccount(Bank holdingBank, string accountNum)
    {
        if(holdingBank.Capacity() <= 0)
        {
            throw new InvalidOperationException("A new bank must be created to successfully add this account.");
        }
        this.HoldingBank = holdingBank;
        this.AccountNumber = accountNum;
        this.Balance = 0;
        System.Console.WriteLine("Account " + accountNum + " has been created in " + holdingBank.Name + ".");
        holdingBank.AddAccount(this);
        
    }
    public BankAccount(Bank holdingBank, string accountNum, double accountBalance)
    {
        if(holdingBank.Capacity() == 0)
        {
            throw new InvalidOperationException("A new bank must be created to successfully add this account.");
        }
        this.HoldingBank = holdingBank;
        this.AccountNumber = accountNum;
        this.Balance = accountBalance;
        System.Console.WriteLine("Account " + accountNum + " has been created for " + holdingBank.Name + ".");
        holdingBank.AddAccount(this);
        
    }
    public void Deposit(double amount)
    {
        Balance += amount;
        System.Console.WriteLine("$" + amount + " has been deposited into account " + AccountNumber + ". Your new balance is: $" + Balance + ".");
    }
    public double Withdraw(double amount)
    {
        if((Balance - amount) >= MaxNegativeAmount)
        {
            Balance -= amount;
            System.Console.WriteLine("$" + amount + " was withdrawn from account " + AccountNumber + ". Your new balance is: $" + Balance + ".");
            return Balance;
        }
        else
        {
            System.Console.WriteLine("Cannot make withdrawal: Insufficient funds.");
            return MaxNegativeAmount - 1;
        }
    }
    public double CheckBalance()
    {
        System.Console.WriteLine("$" + Balance + " is the current balance of account " + AccountNumber + ".");
        return Balance;
    }
    public double GetMaxNegativeAmount()
    {
        return MaxNegativeAmount;
    }
}