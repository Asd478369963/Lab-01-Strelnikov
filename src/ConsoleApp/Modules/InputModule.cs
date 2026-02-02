using System;

namespace ConsoleApp.Modules
{
    public static class InputModule
    {
        // Метод для ввода целого числа
        public static int ReadInt(string prompt)
        {
            Console.Write(prompt);
            while (true)
            {
                string input = Console.ReadLine();
                if (int.TryParse(input, out int result))
                {
                    return result;
                }
                Console.Write("Ошибка: введите корректное целое число. Попробуйте снова: ");
            }
        }

        // Метод для ввода массива целых чисел
        public static int[] ReadIntArray(string prompt)
        {
            Console.Write(prompt);
            while (true)
            {
                string input = Console.ReadLine();
                string[] parts = input.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
                
                if (parts.Length == 0)
                {
                    Console.Write("Ошибка: массив не может быть пустым. Попробуйте снова: ");
                    continue;
                }

                int[] array = new int[parts.Length];
                bool success = true;

                for (int i = 0; i < parts.Length; i++)
                {
                    if (!int.TryParse(parts[i], out array[i]))
                    {
                        success = false;
                        break;
                    }
                }

                if (success)
                {
                    return array;
                }

                Console.Write("Ошибка: все элементы должны быть целыми числами. Попробуйте снова: ");
            }
        }

        // Старый метод для обратной совместимости
        public static string ReadString(string prompt)
        {
            Console.WriteLine(prompt);
            return Console.ReadLine();
        }
    }
}
