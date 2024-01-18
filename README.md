# Sistema de Cuentas Bancarias

Un programa simple en C# que simula un sistema de cuentas bancarias con una clase base `Account` y dos clases derivadas `SavingsAccount` y `CheckingAccount`.

## Resumen

El programa representa cuentas bancarias con la capacidad de realizar operaciones como acreditar (`Credit`), debitar (`Debit`), calcular interés (`CalculateInterest`), y aplicar tarifas de transacción para cuentas de cheques. Cada cuenta tiene un saldo y realiza operaciones específicas según el tipo de cuenta.

## Clases

### `Account`

- Proporciona una funcionalidad básica de cuenta.
- Permite acreditar y debitar fondos.

### `SavingsAccount`

- Deriva de la clase `Account`.
- Incluye una tasa de interés.
- Permite calcular el interés sobre el saldo actual.

### `CheckingAccount`

- Deriva de la clase `Account`.
- Incluye una tarifa de transacción.
- Modifica el método `Debit` para aplicar la tarifa después de un débito exitoso.

## Uso de Ejemplo

```csharp
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
```
