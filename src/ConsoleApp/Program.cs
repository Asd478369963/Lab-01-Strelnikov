using System;
using ConsoleApp.Modules;
namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Лабораторная работа №5 - Вариант 5 ===");
            Console.WriteLine("Задача: Ввести два числа и массив.");
            Console.WriteLine("Найти большее из двух чисел и подсчитать количество чётных элементов массива.\n");
            int num1 = InputModule.ReadInt("Введите первое число: ");
            int num2 = InputModule.ReadInt("Введите второе число: ");
            int[] array = InputModule.ReadIntArray("Введите элементы массива (через пробел или запятую): ");
            if (!ValidationModule.AreNumbersNotEqual(num1, num2))
            {
                Console.WriteLine("Ошибка: числа не должны быть равны!");
                return;
            }
            if (!ValidationModule.IsArrayValid(array))
            {
                Console.WriteLine("Ошибка: массив некорректен!");
                return;
            }
            Console.WriteLine("\nДанные прошли валидацию успешно!");
            int maxNumber = ProcessingModule.FindMax(num1, num2);
            int evenCount = ProcessingModule.CountEvenElements(array);
            ProcessingModule.PrintResults(maxNumber, evenCount);
            Console.WriteLine("\nПрограмма завершена.");
        }
    }
}