using System;
namespace ConsoleApp.Modules
{
    public static class ValidationModule
    {
        public static bool IsNotEmpty(string input)
        {
            return !string.IsNullOrWhiteSpace(input);
        }
    }
}