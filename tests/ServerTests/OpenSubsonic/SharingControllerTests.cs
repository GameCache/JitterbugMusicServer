using CreateAndFake;
using CreateAndFake.Fluent;
using JitterbugMusic.Server.OpenSubsonic;
using Xunit;

namespace JitterbugMusic.ServerTests.OpenSubsonic;

public class SharingControllerTests
{
    [Theory, RandomData]
    public void GetShares_Works(SubsonicRequest request)
    {
        new SharingController().GetShares(request).Assert().IsNot(null);
    }
}