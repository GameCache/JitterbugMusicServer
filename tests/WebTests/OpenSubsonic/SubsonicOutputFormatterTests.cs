using System.Text;
using System.Threading.Tasks;
using CreateAndFake;
using CreateAndFake.Fluent;
using JitterbugMusicServer.Web.OpenSubsonic;
using Microsoft.AspNetCore.Mvc.Formatters;
using Xunit;

namespace JitterbugMusicServer.WebTests.OpenSubsonic;

public class SubsonicOutputFormatterTests
{
    [Theory, RandomData]
    internal void WriteResponseBodyAsync_NullObjectJustCompletes([Stub] OutputFormatterWriteContext context)
    {
        new SubsonicOutputFormatter()
            .WriteResponseBodyAsync(context, Encoding.UTF8)
            .Assert()
            .Is(Task.CompletedTask);
    }
}