using System;
using System.IO;
using System.Text;
namespace ShopExceptionPractice
{
    class ShopException : Exception
    {
        public ShopException(string message) : base(message) { }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8; 
            Console.InputEncoding = Encoding.UTF8;
            Console.WriteLine("=== Практическая работа №7: Обработка исключений ===\n");
            try
            {
                decimal price = RequestDecimal("Введите цену товара (руб): ");
                int discount = RequestInt("Введите процент скидки (0–100): ");
                int quantity = RequestInt("Введите количество товара: ");
                decimal total = CalculateTotal(price, discount, quantity);
                decimal totalWithVat = AddVat(total);
                Console.WriteLine($"\nИтого без скидки: {(price * quantity):C}");
                Console.WriteLine($"С учётом скидки и НДС: {totalWithVat:C}");
                string path = "";
                bool pathValid = false;
                while (!pathValid)
                {
                    try
                    {
                        Console.Write("\nВведите путь для сохранения чека (например, receipt.txt): ");
                        path = Console.ReadLine();
                        SaveReceipt(path, price, discount, quantity, totalWithVat);
                        pathValid = true;
                    }
                    catch (ShopException ex)
                    {
                        Console.WriteLine("Ошибка пути: " + ex.Message);
                    }
                    catch (UnauthorizedAccessException)
                    {
                        Console.WriteLine("Ошибка: нет прав доступа к указанному пути.");
                    }
                    catch (IOException ex)
                    {
                        Console.WriteLine("Ошибка ввода-вывода при сохранении: " + ex.Message);
                    }
                }
                Console.WriteLine("\nЧек успешно сохранён.\n");
                try
                {
                    ReadReceipt(path);
                }
                catch (ShopException ex)
                {
                    Console.WriteLine("Ошибка при чтении чека: " + ex.Message);
                }
            }
            catch (ShopException ex)
            {
                Console.WriteLine("Ошибка магазина: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Критическая ошибка: " + ex.Message);
            }
            finally
            {
                Console.WriteLine("\nЗавершение работы программы.");
            }
        }
        static decimal RequestDecimal(string message)
        {
            while (true)
            {
                try
                {
                    Console.Write(message);
                    string input = Console.ReadLine();
                    decimal value = decimal.Parse(input);
                    if (value <= 0)
                        throw new ShopException("Значение должно быть больше нуля");
                    return value;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Ошибка ввода: требуется число");
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Ошибка ввода: число слишком большое или маленькое");
                }
            }
        }
        static int RequestInt(string message)
        {
            while (true)
            {
                try
                {
                    Console.Write(message);
                    string input = Console.ReadLine();
                    int value = int.Parse(input);
                    if (value < 0)
                        throw new ShopException("Значение не может быть отрицательным");
                    return value;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Ошибка ввода: требуется целое число");
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Ошибка ввода: число выходит за пределы допустимого диапазона");
                }
            }
        }
        static decimal CalculateTotal(decimal price, int discountPercent, int quantity)
        {
            if (discountPercent > 100)
                throw new ShopException("Скидка не может превышать 100%");
            decimal discount = price * discountPercent / 100;
            decimal discountedPrice = price - discount;
            if (discountedPrice < 0)
                throw new ShopException("Цена после скидки некорректна");
            return discountedPrice * quantity;
        }
        static decimal AddVat(decimal total)
        {
            const decimal vat = 0.20m;
            return total + total * vat;
        }
        static void SaveReceipt(string path, decimal price, int discount, int quantity, decimal total)
        {
            if (string.IsNullOrWhiteSpace(path))
                throw new ShopException("Путь к файлу не задан");
            if (!path.EndsWith(".txt", StringComparison.OrdinalIgnoreCase))
                throw new ShopException("Файл чека должен иметь расширение .txt");
            string receipt =
                "Чек магазина\n" +
                $"Дата: {DateTime.Now}\n" +
                $"Цена: {price:C}\n" +
                $"Скидка: {discount}%\n" +
                $"Количество: {quantity}\n" +
                $"Итого: {total:C}\n";
            File.WriteAllText(path, receipt);
        }
        static void ReadReceipt(string path)
        {
            if (!File.Exists(path))
                throw new ShopException("Файл чека не найден");
            Console.WriteLine("--- Содержимое файла чека ---");
            Console.WriteLine(File.ReadAllText(path));
            Console.WriteLine("-----------------------------");
        }
    }
}