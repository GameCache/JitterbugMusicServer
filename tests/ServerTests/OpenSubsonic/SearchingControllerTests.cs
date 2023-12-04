using CreateAndFake;
using CreateAndFake.Fluent;
using JitterbugMusic.Server.OpenSubsonic;
using Xunit;

namespace JitterbugMusic.ServerTests.OpenSubsonic;

public class SearchingControllerTests
{
    [Theory, RandomData]
    public void Search_Works(SubsonicRequest request)
    {
        new SearchingController().Search(request).Assert().IsNot(null);
    }
}