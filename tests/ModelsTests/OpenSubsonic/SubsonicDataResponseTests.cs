using CreateAndFake;
using CreateAndFake.Fluent;
using JitterbugMusic.Models.OpenSubsonic;
using JitterbugMusic.Models.OpenSubsonic.System;
using JitterbugMusic.ModelsTests.Conversion;
using Xunit;

namespace JitterbugMusic.ModelsTests.OpenSubsonic;

public class SubsonicDataResponseTests
{
    [Theory, RandomData]
    internal void RoundTripsViaJson(SubsonicDataResponse<LicenseDto> original)
    {
        ConvertTester.JsonTrip(original);
    }

    [Fact]
    internal virtual void RoundTripsDefaultsViaJson()
    {
        SubsonicDataResponse<LicenseDto> original = new()
        {
            Status = null,
            Version = null,
            Type = null,
            ServerVersion = null,
            OpenSubsonic = null
        };
        ConvertTester.JsonTrip(original);
    }

    [Theory, RandomData]
    internal void RoundTripsViaXml(SubsonicDataResponse<LicenseDto> original)
    {
        ConvertTester.XmlTrip(original);
    }

    [Fact]
    internal virtual void RoundTripsDefaultsViaXml()
    {
        SubsonicDataResponse<LicenseDto> original = new()
        {
            Status = null,
            Version = null,
            Type = null,
            ServerVersion = null,
            OpenSubsonic = null
        };
        ConvertTester.XmlTrip(original);
    }

    [Fact]
    internal virtual void NullDictViaJsonResets()
    {
        SubsonicDataResponse<LicenseDto> original = new()
        {
            Status = null,
            Version = null,
            Type = null,
            ServerVersion = null,
            OpenSubsonic = null
        };
        SubsonicDataResponse<LicenseDto> dupe = new()
        {
            JsonDataProvider = null
        };

        original.Assert().Is(dupe);
    }

    [Theory, RandomData]
    internal virtual void GetSchema_IsNull(SubsonicDataResponse<LicenseDto> original)
    {
        original.GetSchema().Assert().Is(null);
    }
}
