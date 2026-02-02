using System;
public class Customer
{
    public string Name { get; private set; }
    public decimal Balance { get; private set; }
    public Customer(string name, decimal balance)
    {
        Name = name;
        Balance = balance;
    }
    public bool CanPay(decimal amount)
    {
        return Balance >= amount;
    }
    public void Pay(decimal amount)
    {
        if (amount > Balance)
            throw new InvalidOperationException("Недостаточно средств на счёте");
        Balance -= amount;
    }
}