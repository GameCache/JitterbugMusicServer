using System.Text.Json;
using System.Xml;
using System.Xml.Serialization;
using JitterbugMusic.Models.Conversion.Series;

namespace JitterbugMusic.Models.Conversion.Nested;

/// <inheritdoc/>
/// <typeparam name="TData">Property type to convert.</typeparam>
/// <param name="seriesName">If present, identifier used to group all items under.</param>
/// <param name="itemName">Identifier for each individual item of the collection.</param>
/// <param name="getter">Delegate accessing the property.</param>
/// <param name="setter">Delegate to set the property's value.</param>
public class NestedSeriesConvertHint<T, TData>(string? seriesName, string itemName,
    Func<T, IEnumerable<TData>?> getter, Action<T, IEnumerable<TData>?> setter)
    : ISeriesConvertHint<T> where TData : IXmlSerializable, new()
{
    /// <summary>Currently read XML elements.</summary>
    private List<TData>? _recording = null;

    /// <inheritdoc/>
    public string Name { get; } = seriesName ?? itemName;

    /// <inheritdoc/>
    public dynamic? GetValueForJson(T instance)
    {
        return getter.Invoke(instance);
    }

    /// <inheritdoc/>
    public void SetValueForJson(T instance, JsonElement value)
    {
        setter.Invoke(instance, value.Deserialize<List<TData>>());
    }

    /// <inheritdoc/>
    public void WriteAttribute(XmlWriter? writer, T instance)
    {
        throw new InvalidOperationException(
            $"{nameof(NestedSeriesConvertHint<T, TData>)} for '{Name}' must be an element, not an attribute.");
    }

    /// <inheritdoc/>
    public void ReadAttribute(XmlReader? reader, T instance)
    {
        throw new InvalidOperationException(
            $"{nameof(NestedSeriesConvertHint<T, TData>)} for '{Name}' must be an element, not an attribute.");
    }

    /// <inheritdoc/>
    public void WriteElement(XmlWriter? writer, T instance)
    {
        ArgumentNullException.ThrowIfNull(writer);

        IEnumerable<TData>? values = getter.Invoke(instance);
        if (values != null)
        {
            if (seriesName != null)
            {
                writer.WriteStartElement(seriesName);
            }

            foreach (TData value in values)
            {
                writer.WriteStartElement(itemName);
                value.WriteXml(writer);
                writer.WriteEndElement();
            }

            if (seriesName != null)
            {
                writer.WriteEndElement();
            }
        }
    }

    /// <inheritdoc/>
    /// <remarks>Begins recording items for the collection.</remarks>
    public void ReadElement(XmlReader? reader, T instance)
    {
        ArgumentNullException.ThrowIfNull(reader);

        if (seriesName != null)
        {
            ReadCollection(reader);
        }
        else
        {
            _recording ??= [];

            TData value = new();
            value.ReadXml(reader);
            _recording.Add(value);
        }
    }

    /// <inheritdoc cref="ReadElement"/>
    private void ReadCollection(XmlReader reader)
    {
        _recording ??= [];

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
                    if (reader.Name == itemName)
                    {
                        TData value = new();
                        value.ReadXml(reader);
                        _recording.Add(value);
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
    }

    /// <inheritdoc/>
    public void ResetToDefault(T instance)
    {
        setter.Invoke(instance, null);
    }

    /// <inheritdoc/>
    public void FinalizeRecording(T instance)
    {
        setter.Invoke(instance, _recording);
        _recording = null;
    }
}