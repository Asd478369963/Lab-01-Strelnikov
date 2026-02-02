using System;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите строку для подсчета гласных:");
            string input = Console.ReadLine();
            int vowelCount = 0;
            string vowels = "аеёиоуыэюяАЕЁИОУЫЭЮЯ";

            foreach (char c in input)
            {
                if (vowels.Contains(c))
                {
                    vowelCount++;
                }
            }

            Console.WriteLine($"Количество гласных: {vowelCount}");
        }
    }
}
