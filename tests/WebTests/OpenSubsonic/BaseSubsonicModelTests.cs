using CreateAndFake;
using CreateAndFake.Fluent;
using Xunit;
using System.Xml.Serialization;
using System.IO;
using System.Text.Json;
using System.Xml;

namespace JitterbugMusicServer.WebTests.OpenSubsonic;

public abstract class BaseSubsonicModelTests<T> where T : new()
{
    protected internal virtual T FixModel(T original)
    {
        return original;
    }

    [Theory, RandomData]
    internal void SerializesToJson(T original)
    {
        original = FixModel(original);
        JsonSerializer.Serialize(original).Assert().IsNot(null);
    }

    [Theory, RandomData]
    internal void DeserializesFromJson(T original)
    {
        original = FixModel(original);
        string json = JsonSerializer.Serialize(original);

        JsonSerializer.Deserialize(json, original.GetType()).Assert().Is(original, json);
    }

    [Theory, RandomData]
    internal void SerializesToXml(T original)
    {
        original = FixModel(original);
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
    internal void DeserializesFromXml(T original)
    {
        original = FixModel(original);
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
    internal virtual void DeserializesDefaultsFromXml()
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
}
