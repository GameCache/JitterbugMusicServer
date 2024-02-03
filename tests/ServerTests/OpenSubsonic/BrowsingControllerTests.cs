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

    [Theory, RandomData]
    public void GetIndexes_Works(SubsonicRequest request, string musicFolderId, long ifModifiedSince)
    {
        new BrowsingController().GetIndexes(request, musicFolderId, ifModifiedSince).Assert().IsNot(null);
    }

    [Theory, RandomData]
    public void GetMusicDirectory_Works(SubsonicRequest request, string id)
    {
        new BrowsingController().GetMusicDirectory(request, id).Assert().IsNot(null);
    }
}