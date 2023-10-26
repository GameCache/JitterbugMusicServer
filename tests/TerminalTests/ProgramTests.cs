using System;
using System.IO;
using CodeTemplate.Terminal;
using CreateAndFake.Fluent;
using Xunit;

namespace CodeTemplate.TerminalTests
{
    public static class ProgramTests
    {
        [Fact]
        internal static void Main_Runs()
        {
            using StringReader input = new(string.Join(Environment.NewLine, "test", "$yo", null, "quit"));
            Console.SetIn(input);

            using StringWriter output = new();
            Console.SetOut(output);

            Program.Main();

            string result = output.ToString();
            result.Assert().Contains("test");
            result.Assert().ContainsNot("$yo");
        }

        [Fact]
        internal static void Main_EndOfInputTerminates()
        {
            using StringReader input = new(string.Join(Environment.NewLine, "test", "test2"));
            Console.SetIn(input);

            using StringWriter output = new();
            Console.SetOut(output);

            Program.Main();

            string result = output.ToString();
            result.Assert().Contains("test");
            result.Assert().Contains("test2");
        }
    }
}
