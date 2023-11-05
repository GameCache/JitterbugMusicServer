using CreateAndFake;
using CreateAndFake.Fluent;
using JitterbugMusic.Models.OpenSubsonic.System;
using Xunit;

namespace JitterbugMusic.ModelsTests.OpenSubsonic.System;

public class LicenseModelTests : BaseSubsonicModelTests<LicenseModel>
{
    [Theory, RandomData]
    internal void GetSchema_IsNull(LicenseModel model)
    {
        model.GetSchema().Assert().Is(null);
    }
}