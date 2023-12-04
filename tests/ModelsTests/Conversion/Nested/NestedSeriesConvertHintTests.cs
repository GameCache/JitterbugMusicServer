using CreateAndFake;
using Xunit;
using System;
using JitterbugMusic.Models.Conversion.Nested;
using JitterbugMusic.Models.OpenSubsonic.System;
using System.Xml.Schema;
using System.Xml.Serialization;
using System.Xml;
using JitterbugMusic.Models.Conversion;
using System.Text.Json;
using CreateAndFake.Fluent;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace JitterbugMusic.ModelsTests.Conversion.Nested;

public sealed class NestedSeriesConvertHintTests : IXmlSerializable
{
    public IEnumerable<LicenseDto>? SeriesA { get; set; }

    public IEnumerable<LicenseDto>? SeriesB { get; set; }

    private static NestedSeriesConvertHint<NestedSeriesConvertHintTests, LicenseDto> ElementAHint
        => new(null, "seriesA", m => m.SeriesA, (m, v) => m.SeriesA = v);

    private static NestedSeriesConvertHint<NestedSeriesConvertHintTests, LicenseDto> ElementBHint
        => new("group", "seriesB", m => m.SeriesB, (m, v) => m.SeriesB = v);

    private static void FixModel(NestedSeriesConvertHintTests model)
    {
        model.SeriesA = model.SeriesA.ToList();
        model.SeriesB = model.SeriesB.ToList();
    }

    [Theory, RandomData]
    internal void RoundTripsViaXml(NestedSeriesConvertHintTests original)
    {
        FixModel(original);
        ConvertTester.XmlTrip(original);
    }

    [Fact]
    internal void RoundTripsDefaultsViaXml()
    {
        ConvertTester.XmlTrip(new NestedSeriesConvertHintTests());
    }

    [Theory, RandomData]
    internal void RoundTripsViaJson(NestedSeriesConvertHintTests original)
    {
        FixModel(original);
        NestedSeriesConvertHintTests dupe = new();

        dynamic? elementAValue = ElementAHint.GetValueForJson(original);
        ElementAHint.SetValueForJson(dupe, JsonSerializer.SerializeToElement(elementAValue));
        dynamic? elementBValue = ElementBHint.GetValueForJson(original);
        ElementBHint.SetValueForJson(dupe, JsonSerializer.SerializeToElement(elementBValue));

        original.Assert().Is(dupe);
    }

    [Theory, RandomData]
    internal void RoundTripsUsingDefaultsViaJson(NestedSeriesConvertHintTests dupe)
    {
        FixModel(dupe);
        NestedSeriesConvertHintTests original = new() { SeriesA = default };

        dynamic? attributeValue = ElementAHint.GetValueForJson(original);
        ElementAHint.SetValueForJson(dupe, JsonSerializer.SerializeToElement(attributeValue, typeof(LicenseDto)));

        original.SeriesA.Assert().Is(dupe.SeriesA);
    }

    [Theory, RandomData]
    internal void ResetToDefault_Works(NestedSeriesConvertHintTests original)
    {
        ElementAHint.ResetToDefault(original);

        original.SeriesA.Assert().Is(default);
    }

    [Fact]
    internal void PreventsAttribute()
    {
        dynamic instance = new NestedSeriesConvertHint<NestedSeriesConvertHintTests, LicenseDto>(
            "series", "item", m => null, (m, v) => { });
        Tools.Asserter.Throws<InvalidOperationException>((Action)(() => instance.WriteAttribute(null, null)));
        Tools.Asserter.Throws<InvalidOperationException>((Action)(() => instance.ReadAttribute(null, null)));
    }

    [Fact]
    internal void GuardsNulls()
    {
        dynamic instance = new NestedSeriesConvertHint<NestedSeriesConvertHintTests, LicenseDto>(
            "series", "item", m => null, (m, v) => { });
        Tools.Asserter.Throws<ArgumentNullException>((Action)(() => instance.WriteElement(null, null)));
        Tools.Asserter.Throws<ArgumentNullException>((Action)(() => instance.ReadElement(null, null)));
    }

    [Theory, RandomData]
    internal void ReadElement_IgnoresRandomNodes(NestedSeriesConvertHintTests original)
    {
        string xml = "<group><a><b/></a><![CDATA[stuff]]><c/></group>";

        using (StringReader text = new(xml))
        using (XmlReader reader = XmlReader.Create(text))
        {
            ElementBHint.ReadElement(reader, original);
        }
    }

    public XmlSchema? GetSchema()
    {
        return null;
    }

    void IXmlSerializable.ReadXml(XmlReader reader)
    {
        XmlHintConverter.FromXml(reader, this, null, [ElementAHint, ElementBHint]);
    }

    void IXmlSerializable.WriteXml(XmlWriter writer)
    {
        XmlHintConverter.ToXml(writer, this, null, [ElementAHint, ElementBHint]);
    }
}