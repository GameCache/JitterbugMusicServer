using System;
using System.Globalization;
using CodeTemplate.Library;
using CreateAndFake;
using CreateAndFake.Fluent;
using Xunit;

namespace CodeTemplate.LibraryTests
{
    public static class TextCheckerTests
    {
        [Fact]
        internal static void IsOnlyNumbersAndLetters_MatchesNumbers()
        {
            int value = Math.Abs(Tools.Randomizer.Create<int>());
            TextChecker
                .IsOnlyNumbersAndLetters(value.ToString(CultureInfo.InvariantCulture))
                .Assert()
                .Is(true);
        }

        [Fact]
        internal static void IsOnlyNumbersAndLetters_MatchesText()
        {
            TextChecker
                .IsOnlyNumbersAndLetters("message")
                .Assert()
                .Is(true);
        }

        [Fact]
        internal static void IsOnlyNumbersAndLetters_NotMatchesSymbols()
        {
            TextChecker
                .IsOnlyNumbersAndLetters("$test")
                .Assert()
                .Is(false);
        }
    }
}
