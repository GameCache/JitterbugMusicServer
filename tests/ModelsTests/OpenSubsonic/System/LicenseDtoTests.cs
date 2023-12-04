using CreateAndFake;
using CreateAndFake.Fluent;
using JitterbugMusic.Models.OpenSubsonic.System;
using Xunit;

namespace JitterbugMusic.ModelsTests.OpenSubsonic.System;

public class LicenseDtoTests : BaseSubsonicDtoTests<LicenseDto>
{
    [Theory, RandomData]
    internal void GetSchema_IsNull(LicenseDto model)
    {
        model.GetSchema().Assert().Is(null);
    }
}