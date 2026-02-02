using System;
using System.IO;
public class ReceiptPrinter
{
    public void PrintReceipt(string productName, decimal price, int quantity, decimal discountAmount, decimal total)
    {
        string receipt = $"Чек\n" +
                         $"Товар: {productName}\n" +
                         $"Цена: {price:C}\n" +
                         $"Кол-во: {quantity}\n" +
                         $"Скидка: {discountAmount:C}\n" +
                         $"Итого к оплате: {total:C}\n" +
                         $"Дата: {DateTime.Now}\n";
        try
        {
            File.WriteAllText("receipt.txt", receipt);
            Console.WriteLine("Чек сохранён в receipt.txt");
        }
        catch (IOException ex)
        {
            Console.WriteLine("Ошибка сохранения файла: " + ex.Message);
        }
    }
}