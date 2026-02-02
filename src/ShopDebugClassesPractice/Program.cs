using System;
using System.IO;
using System.Diagnostics;
using System.Text;
namespace ShopDebugClassesPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;
            SetupTraceListeners();
            Trace.WriteLine("=== Запуск программы ===");
            Debug.WriteLine("Программа запущена в режиме Debug");
            try
            {
                Console.Write("Введите цену товара: ");
                string priceInput = Console.ReadLine();
                decimal price = decimal.Parse(priceInput ?? "0");
                Debug.Assert(price > 0, "Цена должна быть положительной");
                Console.Write("Введите количество: ");
                string quantityInput = Console.ReadLine();
                int quantity = int.Parse(quantityInput ?? "0");
                Debug.Assert(quantity > 0, "Количество должно быть больше нуля");
                Trace.Indent();
                Trace.WriteLine("Начало расчёта стоимости");
                decimal total = CalculateTotal(price, quantity);
                Console.WriteLine($"Итого: {total:C}");
                SaveToFile("receipt.txt", total);
                Trace.WriteLine("Расчёт и сохранение выполнены успешно");
                Trace.Unindent();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Ошибка: {ex.Message}");
                Trace.WriteLine($"Критическая ошибка: {ex}");
                Console.WriteLine("Произошла ошибка при выполнении программы.");
            }
            finally
            {
                Trace.WriteLine("=== Завершение работы ===");
                Trace.Flush();
                Debug.Flush();
            }
            Console.WriteLine("\nНажмите любую клавишу для выхода...");
        }
        static decimal CalculateTotal(decimal price, int quantity)
        {
            Debug.WriteLine($"Вход в CalculateTotal: price={price}, quantity={quantity}");
            decimal result = price * quantity;
            Debug.WriteLine($"Результат расчёта: {result}");
            return result;
        }
        static void SaveToFile(string path, decimal total)
        {
            Trace.WriteLine($"Сохранение результата в файл {path}");
            File.WriteAllText(path, $"Итого к оплате: {total:C}\nДата: {DateTime.Now}");
            Trace.WriteLine("Файл успешно сохранён");
        }
        static void SetupTraceListeners()
        {
            Trace.Listeners.Add(new TextWriterTraceListener(Console.Out));
            string logFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "debug_trace.log");
            Trace.Listeners.Add(new TextWriterTraceListener(logFile));
            Trace.AutoFlush = true;
            Debug.AutoFlush = true;
        }
    }
}