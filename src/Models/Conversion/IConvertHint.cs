using System.Text.Json;
using System.Xml;

namespace JitterbugMusic.Models.Conversion;

/// <summary>Provides conversion behavior for properties.</summary>
/// <typeparam name="T">Parent class with properties being converted.</typeparam>
public interface IConvertHint<T>
{
    /// <summary>Name identifier used for serialization.</summary>
    public string Name { get; }

    /// <summary>Retrieves the property value for JSON serialization.</summary>
    /// <param name="instance">Instance currently being serialized.</param>
    /// <returns>The value to serialize.</returns>
    public dynamic? GetValueForJson(T instance);

    /// <summary>Sets the property value from a JSON value.</summary>
    /// <param name="instance">Instance currently being deserialized.</param>
    /// <param name="value">Value being deserialized.</param>
    public void SetValueForJson(T instance, JsonElement value);

    /// <summary>Serializes a property meant as an XML attribute.</summary>
    /// <param name="writer">Serializer to use.</param>
    /// <param name="instance">Instance currently being serialized.</param>
    public void WriteAttribute(XmlWriter? writer, T instance);

    /// <summary>Deserializes a property's data serialized as an XML attribute.</summary>
    /// <param name="reader">Deserializer to use.</param>
    /// <param name="instance">Instance currently being deserialized.</param>
    public void ReadAttribute(XmlReader? reader, T instance);

    /// <summary>Serializes a property meant as an XML element.</summary>
    /// <param name="writer">Serializer to use.</param>
    /// <param name="instance">Instance currently being serialized.</param>
    public void WriteElement(XmlWriter? writer, T instance);

    /// <summary>Deserializes a property's data serialized as an XML element.</summary>
    /// <param name="reader">Deserializer to use.</param>
    /// <param name="instance">Instance currently being deserialized.</param>
    public void ReadElement(XmlReader? reader, T instance);

    /// <summary>Sets the property's value to the default for it's type.</summary>
    /// <param name="instance">Instance whose property to modify.</param>
    public void ResetToDefault(T instance);
}