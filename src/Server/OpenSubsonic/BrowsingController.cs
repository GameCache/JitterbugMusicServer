using JitterbugMusic.Models.OpenSubsonic;
using JitterbugMusic.Models.OpenSubsonic.Browsing;
using Microsoft.AspNetCore.Mvc;

namespace JitterbugMusic.Server.OpenSubsonic;

#pragma warning disable IDE0060

/// <summary>Endpoints for the OpenSubsonic System category.</summary>
[ApiController, Route("rest")]
public sealed class BrowsingController : ControllerBase
{
    /// <summary>A subsonic-response element with a nested musicFolders element on success.</summary>
    /// <param name="standard"><inheritdoc cref="SubsonicRequest" path="/summary"/></param>
    /// <returns><inheritdoc cref="MusicFolderDto" path="/summary"/></returns>
    [HttpGet("getMusicFolders")]
    public SubsonicSeriesResponse<MusicFolderDto> GetMusicFolders([FromQuery] SubsonicRequest standard)
    {
        return new SubsonicSeriesResponse<MusicFolderDto>()
        {
            Contents = new[]
            {
                new MusicFolderDto() { Id = "1", Name = "music" },
                new MusicFolderDto() { Id = "4", Name = "upload" }
            }
        };
    }
}

#pragma warning restore IDE0060
