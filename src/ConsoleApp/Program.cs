using System;
using ConsoleApp.Modules;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1. Ввод данных через InputModule
            string input = InputModule.ReadString("Введите строку для подсчета гласных:");

            // 2. Проверка через ValidationModule
            if (ValidationModule.IsNotEmpty(input))
            {
                // 3. Обработка и вывод через ProcessingModule
                ProcessingModule.CountAndPrintVowels(input);
            }
            else
            {
                Console.WriteLine("Ошибка: введена пустая строка.");
            }
        }
    }
}
