using CreateAndFake.Fluent;
using System.IO;
using System.Text.Json;
using System.Xml;
using System.Xml.Serialization;

namespace JitterbugMusic.ModelsTests.Conversion;

public static class ConvertTester
{
    public static void JsonTrip<T>(T original)
    {
        string json = JsonSerializer.Serialize(original);
        json.Assert().IsNot(null, json);
        JsonSerializer.Deserialize(json, original.GetType()).Assert().Is(original, json);
    }

    public static void XmlTrip<T>(T original)
    {
        XmlSerializer serializer = new(original.GetType());

        string xml;
        using (StringWriter writer = new())
        {
            serializer.Serialize(writer, original);
            xml = writer.ToString();
        }

        xml.Assert().IsNot(null, xml);

        using (StringReader text = new(xml))
        using (XmlReader reader = XmlReader.Create(text))
        {
            serializer.Deserialize(reader).Assert().Is(original, xml);
        }
    }
}