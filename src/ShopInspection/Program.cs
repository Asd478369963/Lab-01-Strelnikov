using System;
using System.Globalization;
using System.Text;
namespace ShopInspection
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Customer alice = new Customer("Alice", 500m);
            Inventory inventory = new Inventory();
            inventory.AddStock("Хлеб", 10);
            inventory.AddStock("Молоко", 5);
            inventory.AddStock("Сыр", 5);
            ProductManager pm = new ProductManager();
            pm.AddProduct("Хлеб", 50m);
            pm.AddProduct("Молоко", 100m);
            pm.AddProduct("Сыр", 200m);
            DiscountCalculator discountCalc = new DiscountCalculator();
            decimal price = pm.GetMostExpensivePrice();
            string productName = pm.GetMostExpensive();
            decimal discountedPrice = discountCalc.CalculatePrice(price, 15);
            int quantity = 2;
            decimal total = discountedPrice * quantity;
            Console.WriteLine($"Товар: {productName}, Цена со скидкой: {discountedPrice.ToString("C", CultureInfo.CurrentCulture)}");
            if (alice.CanPay(total))
            {
                if (inventory.CheckStock(productName, quantity))
                {
                    alice.DeductBalance(total);
                    ReceiptPrinter printer = new ReceiptPrinter();
                    printer.PrintReceipt(alice.Name, productName, quantity, total);
                }
                else
                {
                    Console.WriteLine("Недостаточно товара на складе.");
                }
            }
            else
            {
                Console.WriteLine("Недостаточно средств у покупателя.");
            }
            Console.WriteLine("Программа завершена.");
        }
    }
}