using JitterbugMusic.Models.OpenSubsonic;
using JitterbugMusic.Models.OpenSubsonic.Playlists;
using Microsoft.AspNetCore.Mvc;

namespace JitterbugMusic.Server.OpenSubsonic;

#pragma warning disable IDE0060

/// <summary>Endpoints for the OpenSubsonic System category.</summary>
[ApiController, Route("rest")]
public sealed class PlaylistsController : ControllerBase
{
    /// <summary>A subsonic-response element with a nested musicFolders element on success.</summary>
    /// <param name="standard"><inheritdoc cref="SubsonicRequest" path="/summary"/></param>
    /// <returns><inheritdoc cref="PlaylistDto" path="/summary"/></returns>
    [HttpGet("getPlaylists")]
    public SubsonicSeriesResponse<PlaylistDto> GetPlaylists([FromQuery] SubsonicRequest standard)
    {
        return new SubsonicSeriesResponse<PlaylistDto>()
        {
            Contents = new[]
            {
                new PlaylistDto() {
                    Id="15",
                    Name="Some random songs",
                    Comment="Just something I tossed together",
                    Owner="admin",
                    Public=false,
                    SongCount=6,
                    Duration=1391,
                    Created= DateTime.UtcNow,
                    CoverArt="pl-15",
                    AllowedUser = ["Sin", "John"]
                }, new PlaylistDto() {
                    Id="16",
                    Name="More random songs",
                    Comment="No comment",
                    Owner="admin",
                    Public=true,
                    SongCount=5,
                    Duration=1018,
                    Created=DateTime.UtcNow,
                    CoverArt="pl-16"
                }
            }
        };
    }
}

#pragma warning restore IDE0060
