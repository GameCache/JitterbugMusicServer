using CreateAndFake;
using CreateAndFake.Fluent;
using JitterbugMusic.Server.OpenSubsonic;
using Xunit;

namespace JitterbugMusic.ServerTests.OpenSubsonic;

public class BrowsingControllerTests
{
    [Theory, RandomData]
    public void GetMusicFolders_Works(SubsonicRequest request)
    {
        new BrowsingController().GetMusicFolders(request).Assert().IsNot(null);
    }
}