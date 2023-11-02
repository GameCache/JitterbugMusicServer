using System.Xml;

namespace JitterbugMusicServer.Web.Conversion;

/// <inheritdoc/>
/// <typeparam name="TData">Property type being convert.</typeparam>
/// <param name="name"><inheritdoc cref="XmlHint{T}.Name" path="/summary"/></param>
/// <param name="getter">Delegate accessing the property.</param>
/// <param name="setter">Delegate to set the property's value.</param>
public abstract class BaseXmlHint<T, TData>(string name, Func<T, TData> getter, Action<T, TData> setter)
    : XmlHint<T>(name)
{
    /// <summary>Serializes property data to a string.</summary>
    /// <param name="value">Data to serialize.</param>
    /// <returns>The converted string.</returns>
    protected abstract string? ConvertToString(TData value);

    /// <summary>Deserializes a string into the property type.</summary>
    /// <param name="value">String to deserialize.</param>
    /// <returns>The converted data.</returns>
    protected abstract TData ConvertToData(string? value);

    /// <inheritdoc/>
    public override void WriteAttribute(XmlWriter? writer, T instance)
    {
        string? value = ConvertToString(getter.Invoke(instance));
        if (value != null)
        {
            writer?.WriteAttributeString(Name, value);
        }
    }

    /// <inheritdoc/>
    public override void ReadAttribute(XmlReader? reader, T instance)
    {
        setter.Invoke(instance, ConvertToData(reader?.GetAttribute(Name)));
    }

    /// <inheritdoc/>
    public override void WriteElement(XmlWriter? writer, T instance)
    {
        string? value = ConvertToString(getter.Invoke(instance));
        if (value != null)
        {
            writer?.WriteElementString(Name, value);
        }
    }

    /// <inheritdoc/>
    public override void ReadElement(XmlReader? reader, T instance)
    {
        setter.Invoke(instance, ConvertToData(reader?.ReadElementContentAsString()));
    }

    /// <inheritdoc/>
    public override void ResetToDefault(T instance)
    {
        setter.Invoke(instance, ConvertToData(null));
    }
}