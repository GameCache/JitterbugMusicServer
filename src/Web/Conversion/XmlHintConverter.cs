using System.Xml;

namespace JitterbugMusicServer.Web.Conversion;

/// <summary>Handles converting instance data to XML attributes.</summary>
public static class XmlHintConverter
{
    /// <summary>Serializes instance data based upon configured hints.</summary>
    /// <typeparam name="T">Parent class with properties being converted.</typeparam>
    /// <param name="writer">Serializer to use.</param>
    /// <param name="instance">Instance currently being serialized.</param>
    /// <param name="attributeHints">Convert behavior for properties representing attributes.</param>
    /// <param name="elementHints">Convert behavior for properties representing elements.</param>
    public static void ToXml<T>(XmlWriter writer, T instance,
        IEnumerable<XmlHint<T>>? attributeHints, IEnumerable<XmlHint<T>>? elementHints)
    {
        if (attributeHints != null)
        {
            foreach (XmlHint<T> hint in attributeHints)
            {
                hint.WriteAttribute(writer, instance);
            }
        }
        if (elementHints != null)
        {
            foreach (XmlHint<T> hint in elementHints)
            {
                hint.WriteElement(writer, instance);
            }
        }
    }

    /// <summary>Deserializes instance data based upon configured hints.</summary>
    /// <typeparam name="T">Parent class with properties being converted.</typeparam>
    /// <param name="reader">Deserializer to use.</param>
    /// <param name="instance">Instance currently being serialized.</param>
    /// <param name="attributeHints">Convert behavior for properties representing attributes.</param>
    /// <param name="elementHints">Convert behavior for properties representing elements.</param>
    /// <exception cref="ArgumentNullException">When <paramref name="reader"/> is null.</exception>
    public static void FromXml<T>(XmlReader? reader, T instance,
        IEnumerable<XmlHint<T>>? attributeHints, IEnumerable<XmlHint<T>>? elementHints)
    {
        if (reader == null) throw new ArgumentNullException(nameof(reader));
        if (attributeHints != null)
        {
            foreach (XmlHint<T> hint in attributeHints)
            {
                hint.ReadAttribute(reader, instance);
            }
        }

        IDictionary<string, XmlHint<T>> elements = (elementHints ?? Array.Empty<XmlHint<T>>())
            .ToDictionary(h => h.Name, h => h);

        if (reader.IsEmptyElement)
        {
            reader.ReadStartElement();
        }
        else
        {
            reader.ReadStartElement();
            while (reader.MoveToContent() != XmlNodeType.EndElement)
            {
                if (reader.IsStartElement())
                {
                    if (elements.TryGetValue(reader.Name, out XmlHint<T>? hint))
                    {
                        _ = elements.Remove(reader.Name);
                        hint.ReadElement(reader, instance);
                    }
                    else
                    {
                        reader.Skip();
                    }
                }
                else
                {
                    _ = reader.Read();
                }
            }
            reader.ReadEndElement();
        }

        foreach (XmlHint<T> hint in elements.Values)
        {
            hint.ResetToDefault(instance);
        }
    }
}