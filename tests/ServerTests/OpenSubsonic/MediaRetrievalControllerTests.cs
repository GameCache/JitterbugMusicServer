using CreateAndFake;
using CreateAndFake.Fluent;
using JitterbugMusic.Server.OpenSubsonic;
using Xunit;

namespace JitterbugMusic.ServerTests.OpenSubsonic;

public class MediaRetrievalControllerTests
{
    [Theory, RandomData]
    public void GetLyrics_Works(SubsonicRequest request)
    {
        new MediaRetrievalController().GetLyrics(request).Assert().IsNot(null);
    }
}