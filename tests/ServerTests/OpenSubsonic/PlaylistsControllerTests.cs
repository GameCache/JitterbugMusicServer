using CreateAndFake;
using CreateAndFake.Fluent;
using JitterbugMusic.Server.OpenSubsonic;
using Xunit;

namespace JitterbugMusic.ServerTests.OpenSubsonic;

public class PlaylistsControllerTests
{
    [Theory, RandomData]
    public void GetPlaylists_Works(SubsonicRequest request)
    {
        new PlaylistsController().GetPlaylists(request).Assert().IsNot(null);
    }
}