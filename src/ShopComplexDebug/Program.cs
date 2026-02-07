using System;
class Program
{
    static void Main(string[] args)
    {
        ShopManager manager = new ShopManager();
        Inventory inventory = new Inventory();
        DiscountPolicy discountPolicy = new DiscountPolicy();
        Customer customer = new Customer("Иван Иванов", 5000m);
        ReceiptPrinter printer = new ReceiptPrinter();
        try
        {
            Console.WriteLine("=== Комплексная отладка проекта магазина ===\n");
            Console.Write("Введите название товара (Сыр, Хлеб, Молоко, Масло): ");
            string productName = Console.ReadLine() ?? "";
            Console.Write("Введите цену товара: ");
            decimal price = decimal.Parse(Console.ReadLine() ?? "0");
            Console.Write("Введите количество: ");
            int quantity = int.Parse(Console.ReadLine() ?? "0");
            Console.Write("Введите процент скидки: ");
            int discountPercent = int.Parse(Console.ReadLine() ?? "0");
            if (!inventory.HasStock(productName, quantity))
            {
                Console.WriteLine("На складе недостаточно товара или товар не найден.");
                return;
            }
            decimal discountAmount = discountPolicy.GetDiscount(price * quantity, discountPercent);
            decimal total = manager.CalculateOrderTotal(price, quantity, discountAmount);
            if (!customer.CanPay(total))
            {
                Console.WriteLine($"Недостаточно средств. Баланс: {customer.Balance:C}, Требуется: {total:C}");
                return;
            }
            customer.Pay(total);
            inventory.ReduceStock(productName, quantity);
            printer.PrintReceipt(productName, price, quantity, discountAmount, total);
            Console.WriteLine("\nЗаказ успешно обработан!");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Произошла ошибка: " + ex.Message);
        }
    }
}