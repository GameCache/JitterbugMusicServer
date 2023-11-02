using JitterbugMusicServer.Web.OpenSubsonic;

namespace JitterbugMusicServer.WebTests.OpenSubsonic;

public class SubsonicResponseTests : BaseSubsonicModelTests<SubsonicResponse>
{
    protected internal override SubsonicResponse FixModel(SubsonicResponse original)
    {
        return new SubsonicResponse()
        {
            Version = original.Version,
            Type = original.Type,
            ServerVersion = original.ServerVersion,
            OpenSubsonic = original.OpenSubsonic,
            Error = original.Error
        };
    }
}
