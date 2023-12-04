using JitterbugMusic.Models.OpenSubsonic;
using JitterbugMusic.Models.OpenSubsonic.System;
using Microsoft.AspNetCore.Mvc;

namespace JitterbugMusic.Server.OpenSubsonic;

#pragma warning disable IDE0060

/// <summary>Endpoints for the OpenSubsonic System category.</summary>
[ApiController, Route("rest")]
public sealed class SystemController : ControllerBase
{
    /// <summary>Used to test connectivity with the server.</summary>
    /// <param name="standard"><inheritdoc cref="SubsonicRequest" path="/summary"/></param>
    /// <returns><inheritdoc cref="NoContentDto" path="/summary"/></returns>
    [HttpGet("ping")]
    public SubsonicDataResponse<NoContentDto> Ping([FromQuery] SubsonicRequest standard)
    {
        return new SubsonicDataResponse<NoContentDto>();
    }

    /// <summary>Get details about the software license.</summary>
    /// <param name="standard"><inheritdoc cref="SubsonicRequest" path="/summary"/></param>
    /// <returns><inheritdoc cref="LicenseDto" path="/summary"/></returns>
    [HttpGet("getLicense")]
    public SubsonicDataResponse<LicenseDto> GetLicense([FromQuery] SubsonicRequest standard)
    {
        return new SubsonicDataResponse<LicenseDto>()
        {
            Content = new LicenseDto()
            {
                Email = "demo@demo.org",
                LicenseExpires = DateTime.UtcNow.AddYears(1),
                TrialExpires = DateTime.UtcNow
            },
            Error = new()
            {
                Code = 5,
                Message = "test"
            }
        };
    }

    /// <summary>List the OpenSubsonic extensions supported by this server.</summary>
    /// <param name="standard"><inheritdoc cref="SubsonicRequest" path="/summary"/></param>
    /// <returns><inheritdoc cref="ExtensionDto" path="/summary"/></returns>
    [HttpGet("getOpenSubsonicExtensions")]
    public SubsonicSeriesResponse<ExtensionDto> GetSupportedExtensions([FromQuery] SubsonicRequest standard)
    {
        return new SubsonicSeriesResponse<ExtensionDto>()
        {
            Contents = new[]
            {
                new ExtensionDto() { Name = "template", Versions = new [] { 1, 2 } },
                new ExtensionDto() { Name = "transcodeOffset", Versions = new[] { 1 } }
            }
        };
    }
}

#pragma warning restore IDE0060
