using System.Text.Json;
using System.Xml;

namespace JitterbugMusic.Models.Conversion.Simple;

/// <inheritdoc/>
/// <typeparam name="TData">Property type to convert.</typeparam>
/// <param name="name"><inheritdoc cref="IConvertHint{T}.Name" path="/summary"/></param>
/// <param name="getter">Delegate accessing the property.</param>
/// <param name="setter">Delegate to set the property's value.</param>
public abstract class BaseSimpleConvertHint<T, TData>(string name, Func<T, TData> getter, Action<T, TData> setter)
    : IConvertHint<T>
{
    /// <inheritdoc/>
    public string Name { get; } = name;

    /// <summary>Serializes property data to a string.</summary>
    /// <param name="value">Data to serialize.</param>
    /// <returns>The converted string.</returns>
    protected abstract string? ConvertToString(TData value);

    /// <summary>Deserializes a string into the property type.</summary>
    /// <param name="value">String to deserialize.</param>
    /// <returns>The converted data.</returns>
    protected abstract TData ConvertToData(string? value);

    /// <inheritdoc/>
    public dynamic? GetValueForJson(T instance)
    {
        return getter.Invoke(instance);
    }

    /// <inheritdoc/>
    public void SetValueForJson(T instance, JsonElement value)
    {
        TData? result = value.Deserialize<TData>();
        if (result != null)
        {
            setter.Invoke(instance, result);
        }
        else
        {
            ResetToDefault(instance);
        }
    }

    /// <inheritdoc/>
    public void WriteAttribute(XmlWriter? writer, T instance)
    {
        if (writer == null) throw new ArgumentNullException(nameof(writer));

        string? value = ConvertToString(getter.Invoke(instance));
        if (value != null)
        {
            writer.WriteAttributeString(Name, value);
        }
    }

    /// <inheritdoc/>
    public void ReadAttribute(XmlReader? reader, T instance)
    {
        if (reader == null) throw new ArgumentNullException(nameof(reader));

        setter.Invoke(instance, ConvertToData(reader.GetAttribute(Name)));
    }

    /// <inheritdoc/>
    public void WriteElement(XmlWriter? writer, T instance)
    {
        if (writer == null) throw new ArgumentNullException(nameof(writer));

        string? value = ConvertToString(getter.Invoke(instance));
        if (value != null)
        {
            writer.WriteElementString(Name, value);
        }
    }

    /// <inheritdoc/>
    public void ReadElement(XmlReader? reader, T instance)
    {
        if (reader == null) throw new ArgumentNullException(nameof(reader));

        setter.Invoke(instance, ConvertToData(reader.ReadElementContentAsString()));
    }

    /// <inheritdoc/>
    public void ResetToDefault(T instance)
    {
        setter.Invoke(instance, ConvertToData(null));
    }
}