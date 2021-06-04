using System;

namespace Lesson7
{
    internal static class TestMessages
    {
        internal static void Message(bool assertResult)
        {
            if (assertResult) Finished();
            else
                Failed();
        }
        
        
        private static void Finished()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("SUCCESS");
            Console.ResetColor();
        }
        
        private static void Failed()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"TEST FAILED");
            Console.ResetColor();
        }
    }
}