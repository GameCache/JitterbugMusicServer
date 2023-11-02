using CreateAndFake;
using CreateAndFake.Fluent;
using JitterbugMusicServer.Web.OpenSubsonic.System;
using Xunit;

namespace JitterbugMusicServer.WebTests.OpenSubsonic.System;

public class LicenseModelTests : BaseSubsonicModelTests<LicenseModel>
{
    [Theory, RandomData]
    internal void GetSchema_IsNull(LicenseModel model)
    {
        model.GetSchema().Assert().Is(null);
    }
}