using JitterbugMusic.Models.OpenSubsonic;
using JitterbugMusic.Models.OpenSubsonic.Searching;
using Microsoft.AspNetCore.Mvc;

namespace JitterbugMusic.Server.OpenSubsonic;

#pragma warning disable IDE0060

/// <summary>Endpoints for the OpenSubsonic System category.</summary>
[ApiController, Route("rest")]
public sealed class SearchingController : ControllerBase
{
    /// <summary>A subsonic-response element with a nested musicFolders element on success.</summary>
    /// <param name="standard"><inheritdoc cref="SubsonicRequest" path="/summary"/></param>
    /// <returns><inheritdoc cref="SearchResultDto" path="/summary"/></returns>
    [HttpGet("search")]
    public SubsonicSeriesResponse<SearchResultDto> Search([FromQuery] SubsonicRequest standard)
    {
        return new SubsonicSeriesResponse<SearchResultDto>()
        {
            Contents = new[]
            {
                new SearchResultDto()
                {
                    Id = "111",
                    Parent = "11",
                    Title = "Dancing Queen",
                    IsDir = false,
                    Album = "Arrival",
                    Artist = "ABBA",
                    Track = 7,
                    Year = 1978,
                    Genre = "Pop",
                    CoverArt = "24",
                    Size = 8421341,
                    ContentType = "audio/mpeg",
                    Suffix = "mp3",
                    Path = "ABBA/Arrival/Dancing Queen.mp3"
                }, new SearchResultDto() {
                    Id = "112",
                    Parent = "11",
                    Title = "Money, Money, Money",
                    IsDir = false,
                    Album = "Arrival",
                    Artist = "ABBA",
                    Track = 7,
                    Year = 1978,
                    Genre = "Pop",
                    CoverArt = "25",
                    Size = 4910028,
                    ContentType = "audio/flac",
                    Suffix = "flac",
                    TranscodedContentType = "audio/mpeg",
                    TranscodedSuffix = "mp3",
                    Path = "ABBA/Arrival/Money, Money, Money.mp3"
                }
            }
        };
    }
}

#pragma warning restore IDE0060