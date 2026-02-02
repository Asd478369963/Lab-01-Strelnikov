using System;
using ConsoleApp.Modules;
namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = InputModule.ReadString("Введите строку для подсчета гласных:");
            if (ValidationModule.IsNotEmpty(input))
            {
                ProcessingModule.CountAndPrintVowels(input);
            }
            else
            {
                Console.WriteLine("Ошибка: введена пустая строка.");
            }
        }
    }
}