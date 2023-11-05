using CreateAndFake;
using CreateAndFake.Fluent;
using JitterbugMusic.Models.Conversion;
using System;
using System.Text.Json;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using Xunit;

namespace JitterbugMusic.ModelsTests.Conversion;

public abstract class BaseConvertHintTests<T, TData> : IXmlSerializable where T : BaseConvertHintTests<T, TData>, new()
{
    public TData? Attribute { get; set; }

    public TData? Element { get; set; }

    protected abstract IConvertHint<T> CreateHint(string name, Func<T, TData?> getter, Action<T, TData?> setter);

    protected IConvertHint<T> AttributeHint => CreateHint("attribute", m => m.Attribute, (m, v) => m.Attribute = v);

    protected IConvertHint<T> ElementHint => CreateHint("element", m => m.Element, (m, v) => m.Element = v);

    protected virtual TData FixModel(TData original)
    {
        return original;
    }

    [Theory, RandomData]
    internal void RoundTripsViaXml(TData attribute, TData element)
    {
        T original = new() { Attribute = FixModel(attribute), Element = FixModel(element) };
        ConvertTester.XmlTrip(original);
    }

    [Fact]
    internal virtual void RoundTripsDefaultsViaXml()
    {
        ConvertTester.XmlTrip(new T());
    }

    [Theory, RandomData]
    internal void RoundTripsViaJson(TData attribute)
    {
        T original = new() { Attribute = FixModel(attribute) };
        T dupe = new();

        dynamic? attributeValue = AttributeHint.GetValueForJson(original);
        AttributeHint.SetValueForJson(dupe, JsonSerializer.SerializeToElement(attributeValue));

        original.Attribute.Assert().Is(dupe.Attribute);
    }

    [Theory, RandomData]
    internal void RoundTripsUsingDefaultsViaJson(TData attribute)
    {
        T original = new() { Attribute = default };
        T dupe = new() { Attribute = FixModel(attribute) };

        dynamic? attributeValue = AttributeHint.GetValueForJson(original);
        AttributeHint.SetValueForJson(dupe, JsonSerializer.SerializeToElement(attributeValue, typeof(TData)));

        original.Attribute.Assert().Is(dupe.Attribute);
    }

    [Theory, RandomData]
    internal virtual void ResetToDefault_Works(TData attribute)
    {
        T original = new() { Attribute = FixModel(attribute) };

        AttributeHint.ResetToDefault(original);

        original.Attribute.Assert().Is(default);
    }

    [Fact]
    internal void GuardsNulls()
    {
        T instance = new();
        Tools.Asserter.Throws<ArgumentNullException>(() => AttributeHint.WriteAttribute(null, instance));
        Tools.Asserter.Throws<ArgumentNullException>(() => AttributeHint.ReadAttribute(null, instance));
        Tools.Asserter.Throws<ArgumentNullException>(() => AttributeHint.WriteElement(null, instance));
        Tools.Asserter.Throws<ArgumentNullException>(() => AttributeHint.ReadElement(null, instance));
    }

    public XmlSchema? GetSchema()
    {
        return null;
    }

    public virtual void ReadXml(XmlReader reader)
    {
        XmlHintConverter.FromXml<T>(reader, (T)this, [AttributeHint], [ElementHint]);
    }

    public virtual void WriteXml(XmlWriter writer)
    {
        XmlHintConverter.ToXml<T>(writer, (T)this, [AttributeHint], [ElementHint]);
    }
}