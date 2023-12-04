using System.Linq;
using CreateAndFake;
using CreateAndFake.Fluent;
using JitterbugMusic.Models.OpenSubsonic;
using JitterbugMusic.Models.OpenSubsonic.System;
using JitterbugMusic.ModelsTests.Conversion;
using JitterbugMusic.ModelsTests.OpenSubsonic.System;
using Xunit;

namespace JitterbugMusic.ModelsTests.OpenSubsonic;

public class SubsonicSeriesResponseTests
{
    [Theory, RandomData]
    internal void RoundTripsViaJson(SubsonicSeriesResponse<ExtensionDto> original)
    {
        original.Contents = original.Contents.Select(c => new ExtensionDtoTests().FixModel(c)).ToList();
        ConvertTester.JsonTrip(original);
    }

    [Fact]
    internal virtual void RoundTripsDefaultsViaJson()
    {
        SubsonicSeriesResponse<ExtensionDto> original = new()
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
    internal void RoundTripsViaXml(SubsonicSeriesResponse<ExtensionDto> original)
    {
        original.Contents = original.Contents.Select(c => new ExtensionDtoTests().FixModel(c)).ToList();
        ConvertTester.XmlTrip(original);
    }

    [Fact]
    internal virtual void RoundTripsDefaultsViaXml()
    {
        SubsonicSeriesResponse<ExtensionDto> original = new()
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
        SubsonicSeriesResponse<ExtensionDto> original = new()
        {
            Status = null,
            Version = null,
            Type = null,
            ServerVersion = null,
            OpenSubsonic = null
        };
        SubsonicSeriesResponse<ExtensionDto> dupe = new()
        {
            JsonDataProvider = null
        };

        original.Assert().Is(dupe);
    }

    [Theory, RandomData]
    internal virtual void GetSchema_IsNull(SubsonicSeriesResponse<ExtensionDto> original)
    {
        original.GetSchema().Assert().Is(null);
    }
}