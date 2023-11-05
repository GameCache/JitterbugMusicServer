using System;
using System.IO;
using System.Xml;
using CreateAndFake;
using JitterbugMusic.Models.Conversion;
using JitterbugMusic.Models.Conversion.Series;
using Xunit;

namespace JitterbugMusic.ModelsTests.Conversion.Series;

public abstract class BaseSeriesConvertHint<T, TData>
    : BaseConvertHintTests<T, TData> where T : BaseSeriesConvertHint<T, TData>, new()
{
    public TData? SeriesAttribute { get; set; }

    public TData? SeriesElement { get; set; }

    protected IConvertHint<T> SeriesAttributeHint => CreateSeriesHint(
        "attributeSeries", "attributeItem", m => m.SeriesAttribute, (m, v) => m.SeriesAttribute = v);

    protected IConvertHint<T> SeriesElementHint => CreateSeriesHint(
        "elementSeries", "elementItem", m => m.SeriesElement, (m, v) => m.SeriesElement = v);

    protected BaseSeriesConvertHint()
    {
        SeriesAttribute = FixModel(Tools.Randomizer.Create<TData>());
        SeriesElement = FixModel(Tools.Randomizer.Create<TData>());
    }

    protected abstract ISeriesConvertHint<T> CreateSeriesHint(
        string? seriesName, string itemName, Func<T, TData?> getter, Action<T, TData?> setter);

    protected override IConvertHint<T> CreateHint(string name, Func<T, TData?> getter, Action<T, TData?> setter)
    {
        return CreateSeriesHint(null, name, getter, setter);
    }

    [Fact]
    internal override void RoundTripsDefaultsViaXml()
    {
        T original = new()
        {
            SeriesAttribute = default,
            SeriesElement = default
        };
        ConvertTester.XmlTrip(original);
    }

    [Fact]
    internal void ReadElement_IgnoresRandomNodes()
    {
        string xml = "<elementSeries><a><b/></a><![CDATA[stuff]]><c/></elementSeries>";

        using (StringReader text = new(xml))
        using (XmlReader reader = XmlReader.Create(text))
        {
            SeriesElementHint.ReadElement(reader, new T());
        }
    }

    public override void ReadXml(XmlReader reader)
    {
        XmlHintConverter.FromXml<T>(reader, (T)this,
            [AttributeHint, SeriesAttributeHint], [ElementHint, SeriesElementHint]);
    }

    public override void WriteXml(XmlWriter writer)
    {
        XmlHintConverter.ToXml<T>(writer, (T)this,
            [AttributeHint, SeriesAttributeHint], [ElementHint, SeriesElementHint]);
    }
}