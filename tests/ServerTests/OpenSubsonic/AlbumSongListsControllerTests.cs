using CreateAndFake;
using CreateAndFake.Fluent;
using JitterbugMusic.Server.OpenSubsonic;
using Xunit;

namespace JitterbugMusic.ServerTests.OpenSubsonic;

public class AlbumSongListsControllerTests
{
    [Theory, RandomData]
    public void GetAlbumList_Works(SubsonicRequest request)
    {
        new AlbumSongListsController().GetAlbumList(request).Assert().IsNot(null);
    }
}