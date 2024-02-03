using System.Text.Json;
using System.Xml;
using System.Xml.Serialization;

namespace JitterbugMusic.Models.Conversion.Nested;

/// <inheritdoc/>
/// <typeparam name="TData">Property type to convert.</typeparam>
/// <param name="name"><inheritdoc cref="IConvertHint{T}.Name" path="/summary"/></param>
/// <param name="getter">Delegate accessing the property.</param>
/// <param name="setter">Delegate to set the property's value.</param>
public class NestedConvertHint<T, TData>(string name, Func<T, TData?> getter, Action<T, TData?> setter)
    : IConvertHint<T> where TData : IXmlSerializable, new()
{
    /// <inheritdoc/>
    public string Name { get; } = name;

    /// <inheritdoc/>
    public dynamic? GetValueForJson(T instance)
    {
        return getter.Invoke(instance);
    }

    /// <inheritdoc/>
    public void SetValueForJson(T instance, JsonElement value)
    {
        setter.Invoke(instance, value.Deserialize<TData>());
    }

    /// <inheritdoc/>
    public void WriteAttribute(XmlWriter? writer, T instance)
    {
        throw new InvalidOperationException(
            $"{nameof(NestedConvertHint<T, TData>)} for '{Name}' must be an element, not an attribute.");
    }

    /// <inheritdoc/>
    public void ReadAttribute(XmlReader? reader, T instance)
    {
        throw new InvalidOperationException(
            $"{nameof(NestedConvertHint<T, TData>)} for '{Name}' must be an element, not an attribute.");
    }

    /// <inheritdoc/>
    public void WriteElement(XmlWriter? writer, T instance)
    {
        ArgumentNullException.ThrowIfNull(writer);

        TData? value = getter.Invoke(instance);
        if (value != null)
        {
            writer.WriteStartElement(Name);
            value.WriteXml(writer);
            writer.WriteEndElement();
        }
    }

    /// <inheritdoc/>
    public void ReadElement(XmlReader? reader, T instance)
    {
        ArgumentNullException.ThrowIfNull(reader);

        TData value = new();
        value.ReadXml(reader);
        setter.Invoke(instance, value);
    }

    /// <inheritdoc/>
    public void ResetToDefault(T instance)
    {
        setter.Invoke(instance, default);
    }
}