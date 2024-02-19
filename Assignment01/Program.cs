//prompt 1
System.Console.WriteLine("---------------------");
Bank villagerTradingHall = new Bank("villager-trading-hall", 8);
System.Console.WriteLine("---------------------");

//prompt 2
BankAccount bankAccountOne = new BankAccount(villagerTradingHall, "v-01");
BankAccount bankAccountTwo = new BankAccount(villagerTradingHall, "v-02", 1000);
BankAccount bankAccountThree = new BankAccount(villagerTradingHall, "v-03", 2000);
System.Console.WriteLine("---------------------");

//prompt 3
bankAccountOne.Deposit(76.24);
System.Console.WriteLine("---------------------");

//prompt 4
bankAccountOne.Withdraw(6.24);
System.Console.WriteLine("---------------------");

//prompt 5
bankAccountTwo.CheckBalance();
System.Console.WriteLine("---------------------");

//prompt 6
bankAccountOne.Withdraw(120.01);
System.Console.WriteLine("---------------------");

//prompt 7
for(int i = 0; i < villagerTradingHall.NextOpenIndex; i++)
{
    System.Console.WriteLine("Account: " + villagerTradingHall.AccountList[i].AccountNumber);
    System.Console.WriteLine("Balance: $" + villagerTradingHall.AccountList[i].Balance);
    System.Console.WriteLine("---------------------");
}
//prompt 8
villagerTradingHall.Transfer(bankAccountThree, bankAccountTwo, 500);
bankAccountThree.CheckBalance();
bankAccountTwo.CheckBalance();
System.Console.WriteLine("---------------------");

//prompt 9
BankAccount bankAccountFour = new BankAccount(villagerTradingHall, "v-04");
BankAccount bankAccountFive = new BankAccount(villagerTradingHall, "v-05");
BankAccount bankAccountSix = new BankAccount(villagerTradingHall, "v-06");
BankAccount bankAccountSeven = new BankAccount(villagerTradingHall, "v-07");
BankAccount bankAccountEight = new BankAccount(villagerTradingHall, "v-08");
//BankAccount bankAccountNine = new BankAccount(villagerTradingHall, "v-09");
//BankAccount bankAccountTen = new BankAccount(villagerTradingHall, "v-10");
Bank testBank = new Bank("test-bank", villagerTradingHall.AccountList);
System.Console.WriteLine(testBank.AccountList[0].AccountNumber);
villagerTradingHall.AccountExists("v-01");