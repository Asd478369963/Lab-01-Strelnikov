using System;
namespace ConsoleApp.Modules
{
    public static class ValidationModule
    {
        public static bool AreNumbersNotEqual(int num1, int num2)
        {
            return num1 != num2;
        }
        public static bool IsArrayValid(int[] array)
        {
            return array != null && array.Length > 0;
        }
        public static bool IsInRange(int number, int min, int max)
        {
            return number >= min && number <= max;
        }
        public static bool IsNotEmpty(string input)
        {
            return !string.IsNullOrWhiteSpace(input);
        }
    }
}