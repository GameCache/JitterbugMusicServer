using JitterbugMusic.Models.OpenSubsonic;
using JitterbugMusic.Models.OpenSubsonic.AlbumSongLists;
using Microsoft.AspNetCore.Mvc;

namespace JitterbugMusic.Server.OpenSubsonic;

#pragma warning disable IDE0060

/// <summary>Endpoints for the OpenSubsonic System category.</summary>
[ApiController, Route("rest")]
public sealed class AlbumSongListsController : ControllerBase
{
    /// <summary>A subsonic-response element with a nested musicFolders element on success.</summary>
    /// <param name="options"><inheritdoc cref="SubsonicRequest" path="/summary"/></param>
    /// <returns><inheritdoc cref="AlbumDto" path="/summary"/></returns>
    [HttpGet("getAlbumList")]
    public SubsonicSeriesResponse<AlbumDto> GetAlbumList([FromQuery] SubsonicRequest options)
    {
        return new SubsonicSeriesResponse<AlbumDto>()
        {
            Contents = new[]
            {
                new AlbumDto()
                {
                    Id = "200000021",
                    Parent = "100000036",
                    Album = "Forget and Remember",
                    Title = "Forget and Remember",
                    Name = "Forget and Remember",
                    IsDir = true,
                    CoverArt = "al-200000021",
                    SongCount = 20,
                    Created = DateTime.UtcNow,
                    Duration = 4248,
                    PlayCount = 0,
                    ArtistId = "100000036",
                    Artist = "Comfort Fit",
                    Year = 2005,
                    Genre = "Hip-Hop"
                }, new AlbumDto() {
                    Id = "200000012",
                    Parent = "100000019",
                    Album = "Buried in Nausea",
                    Title = "Buried in Nausea",
                    Name = "Buried in Nausea",
                    IsDir = true,
                    CoverArt = "al-200000012",
                    SongCount = 9,
                    Created = DateTime.UtcNow,
                    Duration = 1879,
                    PlayCount = 0,
                    ArtistId = "100000019",
                    Artist = "Various Artists",
                    Year = 2012,
                    Genre = "Punk"
                },
            }
        };
    }
}

#pragma warning restore IDE0060