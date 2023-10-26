using System;
using CodeTemplate.Library;

namespace CodeTemplate.Terminal
{
    /// <summary>Handles running chess on the console.</summary>
    public static class Program
    {
        /// <summary>Application entry point.</summary>
        public static void Main()
        {
            while (true)
            {
                string input = Console.ReadLine() ?? "quit";
                if (TextChecker.IsOnlyNumbersAndLetters(input))
                {
                    switch (input)
                    {
                        default:
                            Console.WriteLine(input);
                            break;
                        case "quit":
                        case "q":
                            return;
                    }
                }
            }
        }
    }
}
