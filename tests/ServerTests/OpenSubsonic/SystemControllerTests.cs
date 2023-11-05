using CreateAndFake;
using CreateAndFake.Fluent;
using JitterbugMusic.Server.OpenSubsonic;
using Xunit;

namespace JitterbugMusic.ServerTests.OpenSubsonic;

public class SystemControllerTests
{
    [Theory, RandomData]
    public void Ping_Works(SubsonicRequest request)
    {
        new SystemController().Ping(request).Assert().IsNot(null);
    }

    [Theory, RandomData]
    public void GetLicense_Works(SubsonicRequest request)
    {
        new SystemController().GetLicense(request).Assert().IsNot(null);
    }

    [Theory, RandomData]
    public void GetSupportedExtensions_Works(SubsonicRequest request)
    {
        new SystemController().GetSupportedExtensions(request).Assert().IsNot(null);
    }
}
