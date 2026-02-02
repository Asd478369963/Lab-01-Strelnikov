using System;
using System.Linq;
namespace ConsoleApp.Modules
{
    public static class ProcessingModule
    {
        public static void CountAndPrintVowels(string input)
        {
            string vowels = "аеёиоуыэюяАЕЁИОУЫЭЮЯ";
            int vowelCount = 0;
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