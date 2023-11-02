using CreateAndFake;
using CreateAndFake.Fluent;
using JitterbugMusicServer.Web.OpenSubsonic;
using Xunit;

namespace JitterbugMusicServer.WebTests.OpenSubsonic;

public class ResponseJsonWrapperTests : BaseSubsonicModelTests<ResponseJsonWrapper<SubsonicResponse>>
{
    protected internal override ResponseJsonWrapper<SubsonicResponse> FixModel(ResponseJsonWrapper<SubsonicResponse> original)
    {
        original.Content = new SubsonicResponseTests().FixModel(original.Content);
        return original;
    }

    [Theory, RandomData]
    internal void ResponseJsonWrapper_ContentConstructorExists(ResponseJsonWrapper<SubsonicResponse> original)
    {
        original.Assert().Is(new ResponseJsonWrapper<SubsonicResponse>(original.Content));
    }
}
