using System;
using System.Globalization;
namespace ShopDebugPractice
{
    public static class DiscountCalculator
    {
        public static decimal CalculatePriceWithDiscount(decimal price, int discountPercent)
        {
            decimal discount = price * discountPercent / 100;
            return price - discount; 
        }
    }
    public static class ProductFinder
    {
        public static string FindMostExpensiveProduct(string[] products, decimal[] prices)
        {
            decimal maxPrice = 0;
            string maxProduct = "";
            for (int i = 0; i < products.Length; i++)
            {
                if (prices[i] > maxPrice)
                {
                    maxPrice = prices[i];
                    maxProduct = products[i];
                }
            }
            return maxProduct + " - " + maxPrice.ToString("C", CultureInfo.CurrentCulture);
        }
    }
    public static class StockChecker
    {
        public static bool CanBuy(int requestedQuantity, int inStock)
        {
            if (requestedQuantity <= 0) return false;
            if (inStock < requestedQuantity) return false;
            return true;
        }
    }
    public static class ReceiptFormatter
    {
        public static string FormatTotal(decimal total)
        {
            string rub = ((int)total).ToString();
            int kopInt = (int)Math.Round((total - (int)total) * 100);
            string kop = kopInt.ToString("00");
            if (kop == "01") kop = "одна копейка";
            else if (kop == "02") kop = "две копейки";
            else kop = kop + " копеек";
            return $"Итого: {rub} руб. {kop}";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== ОТЛАЖЕННЫЕ МОДУЛИ МАГАЗИНА ===\n");
            try
            {
                Console.WriteLine("--- Модуль 1: DiscountCalculator ---");
                decimal price = 1500m;
                int discount = 15;
                decimal result1 = DiscountCalculator.CalculatePriceWithDiscount(price, discount);
                Console.WriteLine($"Цена: {price}, Скидка: {discount}%. Итог: {result1} (Ожидалось: 1275)");
                Console.WriteLine("\n--- Модуль 2: ProductFinder ---");
                string[] names = { "Хлеб", "Молоко", "Сыр", "Масло" };
                decimal[] prices = { 45.50m, 78.00m, 650.00m, 320.00m };
                Console.WriteLine($"Самый дорогой товар: {ProductFinder.FindMostExpensiveProduct(names, prices)}");
                Console.WriteLine("\n--- Модуль 3: StockChecker ---");
                Console.WriteLine($"Запрос 5, Склад 3: {StockChecker.CanBuy(5, 3)} (Ожидалось: False)");
                Console.WriteLine($"Запрос 0, Склад 10: {StockChecker.CanBuy(0, 10)} (Ожидалось: False)");
                Console.WriteLine($"Запрос 5, Склад 10: {StockChecker.CanBuy(5, 10)} (Ожидалось: True)");
                Console.WriteLine("\n--- Модуль 4: ReceiptFormatter ---");
                Console.WriteLine(ReceiptFormatter.FormatTotal(1250.01m));
                Console.WriteLine(ReceiptFormatter.FormatTotal(1250.02m));
                Console.WriteLine(ReceiptFormatter.FormatTotal(1250.05m));
                Console.WriteLine(ReceiptFormatter.FormatTotal(10.00m));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\n[ОШИБКА]: {ex.Message}");
            }
            Console.WriteLine("\nПроверка завершена успешно.");
        }
    }
}