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
    /// <returns><inheritdoc cref="NoContentModel" path="/summary"/></returns>
    [HttpGet("ping")]
    public SubsonicResponse<NoContentModel> Ping([FromQuery] SubsonicRequest standard)
    {
        return new SubsonicResponse<NoContentModel>();
    }

    /// <summary>Get details about the software license.</summary>
    /// <param name="standard"><inheritdoc cref="SubsonicRequest" path="/summary"/></param>
    /// <returns><inheritdoc cref="LicenseModel" path="/summary"/></returns>
    [HttpGet("getLicense")]
    public SubsonicResponse<LicenseModel> GetLicense([FromQuery] SubsonicRequest standard)
    {
        return new SubsonicResponse<LicenseModel>()
        {
            Content = new LicenseModel()
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
    /// <returns><inheritdoc cref="ExtensionsModel" path="/summary"/></returns>
    [HttpGet("getOpenSubsonicExtensions")]
    public SubsonicResponse<ExtensionsModel> GetSupportedExtensions([FromQuery] SubsonicRequest standard)
    {
        return new SubsonicResponse<ExtensionsModel>()
        {
            Content = new ExtensionsModel()
            {
                OpenSubsonicExtensions = new[]
                {
                    new ExtensionModel() { Name = "template", Versions = new [] { 1, 2 } },
                    new ExtensionModel() { Name = "transcodeOffset", Versions = new[] { 1 } }
                }
            }
        };
    }
}

#pragma warning restore IDE0060
