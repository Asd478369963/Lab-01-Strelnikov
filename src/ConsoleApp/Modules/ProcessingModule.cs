using System;
using System.Linq;

namespace ConsoleApp.Modules
{
    public static class ProcessingModule
    {
        // Найти большее из двух чисел
        public static int FindMax(int num1, int num2)
        {
            return Math.Max(num1, num2);
        }

        // Подсчитать количество чётных элементов в массиве
        public static int CountEvenElements(int[] array)
        {
            int count = 0;
            foreach (int num in array)
            {
                if (num % 2 == 0)
                {
                    count++;
                }
            }
            return count;
        }

        // Вывести результаты обработки
        public static void PrintResults(int maxNumber, int evenCount)
        {
            Console.WriteLine($"\nРезультаты обработки:");
            Console.WriteLine($"Большее из двух чисел: {maxNumber}");
            Console.WriteLine($"Количество чётных элементов в массиве: {evenCount}");
        }

        // Старый метод для обратной совместимости
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
