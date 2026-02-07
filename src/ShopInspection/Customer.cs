using System;
namespace ShopInspection
{
    public class Customer
    {
        public string Name { get; set; }
        public decimal Balance { get; private set; }
        public Customer(string name, decimal balance)
        {
            if (balance < 0) throw new ArgumentException("Баланс не может быть отрицательным");
            Name = name;
            Balance = balance;
        }
        public bool CanPay(decimal amount)
        {
            return Balance >= amount;
        }
        public void DeductBalance(decimal amount)
        {
            if (amount > Balance) throw new InvalidOperationException("Недостаточно средств");
            Balance -= amount;
        }
    }
}