using CreateAndFake;
using CreateAndFake.Fluent;
using JitterbugMusic.Server.OpenSubsonic;
using Xunit;

namespace JitterbugMusic.ServerTests.OpenSubsonic;

public class PodcastControllerTests
{
    [Theory, RandomData]
    public void GetPodcasts_Works(SubsonicRequest request)
    {
        new PodcastController().GetPodcasts(request).Assert().IsNot(null);
    }
}