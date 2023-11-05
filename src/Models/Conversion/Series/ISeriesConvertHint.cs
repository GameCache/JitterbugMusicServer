namespace JitterbugMusic.Models.Conversion.Series;

/// <inheritdoc/>
public interface ISeriesConvertHint<T> : IConvertHint<T>
{
    /// <summary>Sets the property value with recorded values.</summary>
    /// <param name="instance">Instance currently being deserialized.</param>
    public void FinalizeRecording(T instance);
}