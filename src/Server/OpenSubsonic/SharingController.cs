using JitterbugMusic.Models.OpenSubsonic;
using JitterbugMusic.Models.OpenSubsonic.Sharing;
using Microsoft.AspNetCore.Mvc;

namespace JitterbugMusic.Server.OpenSubsonic;

#pragma warning disable IDE0060

/// <summary>Endpoints for the OpenSubsonic System category.</summary>
[ApiController, Route("rest")]
public sealed class SharingController : ControllerBase
{
    /// <summary>A subsonic-response element with a nested musicFolders element on success.</summary>
    /// <param name="standard"><inheritdoc cref="SubsonicRequest" path="/summary"/></param>
    /// <returns><inheritdoc cref="ShareDto" path="/summary"/></returns>
    [HttpGet("getShares")]
    public SubsonicSeriesResponse<ShareDto> GetShares([FromQuery] SubsonicRequest standard)
    {
        return new SubsonicSeriesResponse<ShareDto>()
        {
            Contents = new[]
            {
                new ShareDto() {
                    Id = "12",
                    Url= "http://localhost:8989/share.php?id=12&secret=fXlKyEv3",
                    Description= "Forget and Remember (Comfort Fit)",
                    Username= "user",
                    Created= DateTime.UtcNow,
                    VisitCount= 0
                }
            }
        };
    }
}

#pragma warning restore IDE0060