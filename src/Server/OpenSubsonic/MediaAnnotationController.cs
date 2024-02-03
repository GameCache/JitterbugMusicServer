using JitterbugMusic.Models.OpenSubsonic;
using JitterbugMusic.Models.OpenSubsonic.System;
using Microsoft.AspNetCore.Mvc;

namespace JitterbugMusic.Server.OpenSubsonic;

#pragma warning disable IDE0060

/// <summary>Endpoints for the OpenSubsonic System category.</summary>
[ApiController, Route("rest")]
public sealed class MediaAnnotationController : ControllerBase
{
    /// <summary>A subsonic-response element with a nested musicFolders element on success.</summary>
    /// <param name="options"><inheritdoc cref="SubsonicRequest" path="/summary"/></param>
    /// <returns><inheritdoc cref="NoContentDto" path="/summary"/></returns>
    [HttpPut("star")]
    public SubsonicDataResponse<NoContentDto> PutStar([FromQuery] SubsonicRequest options)
    {
        return new SubsonicDataResponse<NoContentDto>();
    }
}

#pragma warning restore IDE0060