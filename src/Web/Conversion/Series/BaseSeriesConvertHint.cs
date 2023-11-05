using System.Text.Json;
using System.Xml;

namespace JitterbugMusicServer.Web.Conversion.Series;

/// <inheritdoc/>
/// <typeparam name="TData">Property type to convert.</typeparam>
/// <param name="seriesName">If present, identifier used to group all items under.</param>
/// <param name="itemName">Identifier for each individual item of the collection.</param>
/// <param name="delimiter">Delimiter used when serializing via an attribute.</param>
/// <param name="getter">Delegate accessing the property.</param>
/// <param name="setter">Delegate to set the property's value.</param>
public abstract class BaseSeriesConvertHint<T, TData>(string? seriesName, string itemName, string delimiter,
    Func<T, IEnumerable<TData>?> getter, Action<T, IEnumerable<TData>?> setter)
    : ISeriesConvertHint<T>
{
    /// <summary>Currently read XML elements.</summary>
    private IList<TData>? _recording = null;

    /// <inheritdoc/>
    public string Name { get; } = seriesName ?? itemName;

    /// <summary>Serializes property data to a string.</summary>
    /// <param name="value">Data to serialize.</param>
    /// <returns>The converted string.</returns>
    protected abstract string? ConvertToString(TData value);

    /// <summary>Deserializes a string into the property type.</summary>
    /// <param name="value">String to deserialize.</param>
    /// <returns>The converted data.</returns>
    protected abstract TData ConvertToData(string value);

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
        if (writer == null) throw new ArgumentNullException(nameof(writer));

        IEnumerable<TData>? values = getter.Invoke(instance);
        if (values != null)
        {
            writer.WriteAttributeString(Name, string.Join(delimiter, values.Select(ConvertToString)));
        }
    }

    /// <inheritdoc/>
    public void ReadAttribute(XmlReader? reader, T instance)
    {
        if (reader == null) throw new ArgumentNullException(nameof(reader));

        setter.Invoke(instance, reader
            .GetAttribute(Name)
            ?.Split(delimiter)
            .Select(ConvertToData)
            .ToList());
    }

    /// <inheritdoc/>
    public void WriteElement(XmlWriter? writer, T instance)
    {
        if (writer == null) throw new ArgumentNullException(nameof(writer));

        if (seriesName != null)
        {
            writer.WriteStartElement(seriesName);
        }

        IEnumerable<TData>? values = getter.Invoke(instance);
        if (values != null)
        {
            foreach (TData value in values)
            {
                writer.WriteElementString(itemName, ConvertToString(value));
            }
        }

        if (seriesName != null)
        {
            writer.WriteEndElement();
        }
    }

    /// <inheritdoc/>
    /// <remarks>Begins recording items for the collection.</remarks>
    public void ReadElement(XmlReader? reader, T instance)
    {
        if (reader == null) throw new ArgumentNullException(nameof(reader));

        if (seriesName != null)
        {
            ReadCollection(reader);
        }
        else
        {
            _recording ??= new List<TData>();
            _recording.Add(ConvertToData(reader.ReadElementContentAsString()));
        }
    }

    /// <inheritdoc cref="ReadElement"/>
    private void ReadCollection(XmlReader reader)
    {
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
                        _recording ??= new List<TData>();
                        _recording.Add(ConvertToData(reader.ReadElementContentAsString()));
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