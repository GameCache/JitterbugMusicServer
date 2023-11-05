using CreateAndFake;
using CreateAndFake.Fluent;
using JitterbugMusicServer.Web.OpenSubsonic;
using JitterbugMusicServer.Web.OpenSubsonic.System;
using JitterbugMusicServer.WebTests.Conversion;
using Xunit;

namespace JitterbugMusicServer.WebTests.OpenSubsonic;

public class SubsonicResponseTests
{
    [Theory, RandomData]
    internal void RoundTripsViaJson(SubsonicResponse<LicenseModel> original)
    {
        ConvertTester.JsonTrip(original);
    }

    [Fact]
    internal virtual void RoundTripsDefaultsViaJson()
    {
        SubsonicResponse<LicenseModel> original = new()
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
    internal void RoundTripsViaXml(SubsonicResponse<LicenseModel> original)
    {
        ConvertTester.XmlTrip(original);
    }

    [Fact]
    internal virtual void RoundTripsDefaultsViaXml()
    {
        SubsonicResponse<LicenseModel> original = new()
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
        SubsonicResponse<LicenseModel> original = new()
        {
            Status = null,
            Version = null,
            Type = null,
            ServerVersion = null,
            OpenSubsonic = null
        };
        SubsonicResponse<LicenseModel> dupe = new()
        {
            JsonDataProvider = null
        };

        original.Assert().Is(dupe);
    }

    [Theory, RandomData]
    internal virtual void GetSchema_IsNull(SubsonicResponse<LicenseModel> original)
    {
        original.GetSchema().Assert().Is(null);
    }
}
