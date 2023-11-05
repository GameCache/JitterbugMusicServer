using System.Xml;
using JitterbugMusicServer.Web.Conversion.Series;

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
        IEnumerable<IConvertHint<T>>? attributeHints, IEnumerable<IConvertHint<T>>? elementHints)
    {
        if (attributeHints != null)
        {
            foreach (IConvertHint<T> hint in attributeHints)
            {
                hint.WriteAttribute(writer, instance);
            }
        }
        if (elementHints != null)
        {
            foreach (IConvertHint<T> hint in elementHints)
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
        IEnumerable<IConvertHint<T>>? attributeHints, IEnumerable<IConvertHint<T>>? elementHints)
    {
        if (reader == null) throw new ArgumentNullException(nameof(reader));
        if (attributeHints != null)
        {
            foreach (IConvertHint<T> hint in attributeHints)
            {
                hint.ReadAttribute(reader, instance);
            }
        }

        IDictionary<string, IConvertHint<T>> elements
            = (elementHints ?? Array.Empty<IConvertHint<T>>())
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
                    if (elements.TryGetValue(reader.Name, out IConvertHint<T>? hint))
                    {
                        if (elements[reader.Name] is not ISeriesConvertHint<T>)
                        {
                            _ = elements.Remove(reader.Name);
                        }
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

        foreach (IConvertHint<T> hint in elements.Values)
        {
            if (hint is ISeriesConvertHint<T> series)
            {
                series.FinalizeRecording(instance);
            }
            else
            {
                hint.ResetToDefault(instance);
            }
        }
    }
}