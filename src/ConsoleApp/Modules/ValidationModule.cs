using System;

namespace ConsoleApp.Modules
{
    public static class ValidationModule
    {
        // Проверка, что два числа не равны
        public static bool AreNumbersNotEqual(int num1, int num2)
        {
            return num1 != num2;
        }

        // Проверка, что массив не пустой
        public static bool IsArrayValid(int[] array)
        {
            return array != null && array.Length > 0;
        }

        // Проверка, что число находится в допустимом диапазоне
        public static bool IsInRange(int number, int min, int max)
        {
            return number >= min && number <= max;
        }

        // Старый метод для обратной совместимости
        public static bool IsNotEmpty(string input)
        {
            return !string.IsNullOrWhiteSpace(input);
        }
    }
}
