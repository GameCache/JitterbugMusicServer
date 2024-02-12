using JitterbugMusic.Models.Conversion;
using JitterbugMusic.Models.Conversion.Nested;

namespace JitterbugMusic.Models.OpenSubsonic.Browsing;

/// <summary>Genres list.</summary>
public sealed class GenresDto() : SubsonicContent<GenresDto>(
    "genres", null, _ConvertElementHints)
{
    /// <inheritdoc cref="XmlHintSerializable{T}.ElementHints" path="/summary"/>
    private static readonly IEnumerable<IConvertHint<GenresDto>> _ConvertElementHints = [
        new NestedSeriesConvertHint<GenresDto, GenreDto>(null, "genre", m => m.Genre, (m, v) => m.Genre = v)
    ];

    /// <summary>List of genre</summary>
    public IEnumerable<GenreDto>? Genre { get; set; }
}
