using CreateAndFake;
using CreateAndFake.Fluent;
using Xunit;
using System.Xml.Serialization;
using System.IO;
using System.Xml;
using System.Xml.Schema;
using JitterbugMusicServer.Web.Conversion;
using System;

namespace JitterbugMusicServer.WebTests.Conversion;

public abstract class BaseXmlHintTests<T, TData> : IXmlSerializable where T : BaseXmlHintTests<T, TData>, new()
{
    public TData? Attribute { get; set; }

    public TData? Element { get; set; }

    protected abstract XmlHint<T> CreateHint(string name, Func<T, TData?> getter, Action<T, TData?> setter);

    private XmlHint<T> AttributeHint => CreateHint("attribute", m => m.Attribute, (m, v) => m.Attribute = v);

    private XmlHint<T> ElementHint => CreateHint("element", m => m.Element, (m, v) => m.Element = v);

    [Theory, RandomData]
    internal void SerializesToXml(TData attribute, TData element)
    {
        T original = new() { Attribute = attribute, Element = element };

        XmlSerializer serializer = new(original.GetType());

        string xml;
        using (StringWriter writer = new())
        {
            serializer.Serialize(writer, original);
            xml = writer.ToString();
        }

        xml.Assert().IsNot(null);
    }

    [Theory, RandomData]
    internal void DeserializesFromXml(TData attribute, TData element)
    {
        T original = new() { Attribute = attribute, Element = element };

        XmlSerializer serializer = new(original.GetType());

        string xml;
        using (StringWriter writer = new())
        {
            serializer.Serialize(writer, original);
            xml = writer.ToString();
        }

        using (StringReader text = new(xml))
        using (XmlReader reader = XmlReader.Create(text))
        {
            serializer.Deserialize(reader).Assert().Is(original, xml);
        }
    }

    [Fact]
    internal void DeserializesFromXmlUsingDefaults()
    {
        T original = new();

        XmlSerializer serializer = new(original.GetType());

        string xml;
        using (StringWriter writer = new())
        {
            serializer.Serialize(writer, original);
            xml = writer.ToString();
        }

        using (StringReader text = new(xml))
        using (XmlReader reader = XmlReader.Create(text))
        {
            serializer.Deserialize(reader).Assert().Is(original, xml);
        }
    }

    [Fact]
    internal void NullSafe()
    {
        T instance = new();
        AttributeHint.WriteAttribute(null, instance);
        AttributeHint.ReadAttribute(null, instance);
        AttributeHint.WriteElement(null, instance);
        AttributeHint.ReadElement(null, instance);
    }

    public XmlSchema? GetSchema()
    {
        return null;
    }

    public void ReadXml(XmlReader reader)
    {
        XmlHintConverter.FromXml<T>(reader, (T)this, [AttributeHint], [ElementHint]);
    }

    public void WriteXml(XmlWriter writer)
    {
        XmlHintConverter.ToXml<T>(writer, (T)this, [AttributeHint], [ElementHint]);
    }
}