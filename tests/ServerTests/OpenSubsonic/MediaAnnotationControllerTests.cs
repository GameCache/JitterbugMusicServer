using CreateAndFake;
using CreateAndFake.Fluent;
using JitterbugMusic.Server.OpenSubsonic;
using Xunit;

namespace JitterbugMusic.ServerTests.OpenSubsonic;

public class MediaAnnotationControllerTests
{
    [Theory, RandomData]
    public void PutStar_Works(SubsonicRequest request)
    {
        new MediaAnnotationController().PutStar(request).Assert().IsNot(null);
    }
}