using System;

public class Account
{
    protected decimal balance;

    public Account(decimal initialBalance)
    {
        if (initialBalance < 0.0m)
        {
            throw new ArgumentException("El saldo inicial debe ser mayor o igual a 0.0");
        }

        balance = initialBalance;
    }

    public decimal Balance
    {
        get { return balance; }
    }

    public void Credit(decimal amount)
    {
        balance += amount;
    }

    public bool Debit(decimal amount)
    {
        if (amount > balance)
        {
            Console.WriteLine("El monto del débito excedió el saldo de la cuenta.");
            return false;
        }

        balance -= amount;
        return true;
    }
}

public class SavingsAccount : Account
{
    private decimal interestRate;

    public SavingsAccount(decimal initialBalance, decimal initialInterestRate)
        : base(initialBalance)
    {
        interestRate = initialInterestRate;
    }

    public decimal CalculateInterest()
    {
        return Balance * interestRate;
    }
}

public class CheckingAccount : Account
{
    private decimal transactionFee;

    public CheckingAccount(decimal initialBalance, decimal initialTransactionFee)
        : base(initialBalance)
    {
        transactionFee = initialTransactionFee;
    }

    public new bool Debit(decimal amount)
    {
        bool success = base.Debit(amount);

        if (success)
        {
            balance -= transactionFee;
        }

        return success;
    }
}

class Program
{
    static void Main()
    {
        Account account = new Account(1000.0m);
        SavingsAccount savingsAccount = new SavingsAccount(1500.0m, 0.05m);
        CheckingAccount checkingAccount = new CheckingAccount(2000.0m, 2.0m);

        Console.WriteLine($"Saldo de la cuenta: {account.Balance}");
        account.Credit(500.0m);
        Console.WriteLine($"Saldo después de acreditar 500: {account.Balance}");

        bool debitSuccess = account.Debit(200.0m);
        Console.WriteLine($"Saldo después de debitar 200: {account.Balance}");

        debitSuccess = account.Debit(1500.0m);
        Console.WriteLine($"Saldo después de intentar debitar 1500: {account.Balance}");

        decimal interest = savingsAccount.CalculateInterest();
        Console.WriteLine($"Interés calculado en cuenta de ahorros: {interest}");

        savingsAccount.Credit(interest);
        Console.WriteLine($"Saldo después de acreditar interés a la cuenta de ahorros: {savingsAccount.Balance}");

        debitSuccess = checkingAccount.Debit(500.0m);
        Console.WriteLine($"Saldo después de debitar 500 de la cuenta de cheques: {checkingAccount.Balance}");
    }
}
