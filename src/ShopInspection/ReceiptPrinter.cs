using System;
using System.IO;
using System.Globalization;
namespace ShopInspection
{
    public class ReceiptPrinter
    {
        public void PrintReceipt(string customerName, string productName, int quantity, decimal total)
        {
            string receipt = $"Чек для {customerName}\n" +
                             $"Товар: {productName}\n" +
                             $"Количество: {quantity}\n" +
                             $"Итого к оплате: {total.ToString("C", CultureInfo.CurrentCulture)}\n" +
                             $"Дата: {DateTime.Now}\n";
            try
            {
                File.WriteAllText("receipt.txt", receipt);
                Console.WriteLine("Чек сохранён в receipt.txt");
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Ошибка записи файла: {ex.Message}");
            }
        }
    }
}