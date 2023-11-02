using System.Xml;

namespace JitterbugMusicServer.Web.Conversion;

/// <summary>Provides XML conversion behavior for properties.</summary>
/// <typeparam name="T">Parent class with properties being converted.</typeparam>
/// <param name="name"></param>
public abstract class XmlHint<T>(string name)
{
    /// <summary>Name identifier used for serialization.</summary>
    public string Name { get; } = name;

    /// <summary>Serializes a property meant as an XML attribute.</summary>
    /// <param name="writer">Serializer to use.</param>
    /// <param name="instance">Instance currently being serialized.</param>
    public abstract void WriteAttribute(XmlWriter? writer, T instance);

    /// <summary>Deserializes a property's data serialized as an XML attribute.</summary>
    /// <param name="reader">Deserializer to use.</param>
    /// <param name="instance">Instance currently being deserialized.</param>
    public abstract void ReadAttribute(XmlReader? reader, T instance);

    /// <summary>Serializes a property meant as an XML element.</summary>
    /// <param name="writer">Serializer to use.</param>
    /// <param name="instance">Instance currently being serialized.</param>
    public abstract void WriteElement(XmlWriter? writer, T instance);

    /// <summary>Deserializes a property's data serialized as an XML element.</summary>
    /// <param name="reader">Deserializer to use.</param>
    /// <param name="instance">Instance currently being deserialized.</param>
    public abstract void ReadElement(XmlReader? reader, T instance);

    /// <summary>Sets the property's value to the default for it's type.</summary>
    /// <param name="instance">Instance whose property to modify.</param>
    public abstract void ResetToDefault(T instance);
}