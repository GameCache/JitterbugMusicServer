using CreateAndFake;
using Xunit;
using System;
using JitterbugMusicServer.Web.Conversion.Nested;
using JitterbugMusicServer.Web.OpenSubsonic.System;
using System.Xml.Serialization;
using JitterbugMusicServer.Web.Conversion;
using System.Xml;
using System.Xml.Schema;
using System.Text.Json;
using CreateAndFake.Fluent;

namespace JitterbugMusicServer.WebTests.Conversion.Nested;

public sealed class NestedConvertHintTests : IXmlSerializable
{
    public LicenseModel? Element { get; set; }

    private static NestedConvertHint<NestedConvertHintTests, LicenseModel> ElementHint
        => new("element", m => m.Element, (m, v) => m.Element = v);

    [Theory, RandomData]
    internal void RoundTripsViaXml(NestedConvertHintTests original)
    {
        ConvertTester.XmlTrip(original);
    }

    [Fact]
    internal void RoundTripsDefaultsViaXml()
    {
        ConvertTester.XmlTrip(new NestedConvertHintTests());
    }

    [Theory, RandomData]
    internal void RoundTripsViaJson(NestedConvertHintTests original)
    {
        NestedConvertHintTests dupe = new();

        dynamic? elementValue = ElementHint.GetValueForJson(original);
        ElementHint.SetValueForJson(dupe, JsonSerializer.SerializeToElement(elementValue));

        original.Element.Assert().Is(dupe.Element);
    }

    [Theory, RandomData]
    internal void RoundTripsUsingDefaultsViaJson(NestedConvertHintTests dupe)
    {
        NestedConvertHintTests original = new() { Element = default };

        dynamic? attributeValue = ElementHint.GetValueForJson(original);
        ElementHint.SetValueForJson(dupe, JsonSerializer.SerializeToElement(attributeValue, typeof(LicenseModel)));

        original.Element.Assert().Is(dupe.Element);
    }

    [Theory, RandomData]
    internal void ResetToDefault_Works(NestedConvertHintTests original)
    {
        ElementHint.ResetToDefault(original);

        original.Element.Assert().Is(default);
    }

    [Fact]
    internal void PreventsAttribute()
    {
        dynamic instance = new NestedConvertHint<NestedConvertHintTests, LicenseModel>(
            "child", m => null, (m, v) => { });
        Tools.Asserter.Throws<InvalidOperationException>((Action)(() => instance.WriteAttribute(null, null)));
        Tools.Asserter.Throws<InvalidOperationException>((Action)(() => instance.ReadAttribute(null, null)));
    }

    [Fact]
    internal void GuardsNulls()
    {
        dynamic instance = new NestedConvertHint<NestedConvertHintTests, LicenseModel>(
            "child", m => null, (m, v) => { });
        Tools.Asserter.Throws<ArgumentNullException>((Action)(() => instance.WriteElement(null, null)));
        Tools.Asserter.Throws<ArgumentNullException>((Action)(() => instance.ReadElement(null, null)));
    }

    public XmlSchema? GetSchema()
    {
        return null;
    }

    void IXmlSerializable.ReadXml(XmlReader reader)
    {
        XmlHintConverter.FromXml(reader, this, null, [ElementHint]);
    }

    void IXmlSerializable.WriteXml(XmlWriter writer)
    {
        XmlHintConverter.ToXml(writer, this, null, [ElementHint]);
    }
}