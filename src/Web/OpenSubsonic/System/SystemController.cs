using Microsoft.AspNetCore.Mvc;

namespace JitterbugMusicServer.Web.OpenSubsonic.System;

#pragma warning disable IDE0060

/// <summary>Endpoints for the OpenSubsonic System category.</summary>
[ApiController, Route("rest")]
public sealed class SystemController : ControllerBase
{
    /// <summary>Used to test connectivity with the server.</summary>
    /// <param name="standard"><inheritdoc cref="SubsonicRequest" path="/summary"/></param>
    /// <returns><inheritdoc cref="SubsonicResponse" path="/summary"/></returns>
    [HttpGet("ping")]
    public SubsonicResponse Ping([FromQuery] SubsonicRequest standard)
    {
        return new SubsonicResponse();
    }

    /// <summary>Get details about the software license.</summary>
    /// <param name="standard"><inheritdoc cref="SubsonicRequest" path="/summary"/></param>
    /// <returns><inheritdoc cref="LicenseResponse" path="/summary"/></returns>
    [HttpGet("getLicense")]
    public LicenseResponse GetLicense([FromQuery] SubsonicRequest standard)
    {
        return new LicenseResponse()
        {
            License = new LicenseModel()
            {
                Email = "demo@demo.org",
                LicenseExpires = DateTime.UtcNow.AddYears(1),
                TrialExpires = DateTime.UtcNow
            }
        };
    }

    /// <summary>List the OpenSubsonic extensions supported by this server.</summary>
    /// <param name="standard"><inheritdoc cref="SubsonicRequest" path="/summary"/></param>
    /// <returns><inheritdoc cref="ExtensionsResponse" path="/summary"/></returns>
    [HttpGet("getOpenSubsonicExtensions")]
    public ExtensionsResponse GetSupportedExtensions([FromQuery] SubsonicRequest standard)
    {
        return new ExtensionsResponse(new[] {
            new ExtensionModel("template", new [] { 1, 2 }),
            new ExtensionModel("transcodeOffset", new[] { 1 })
        });
    }
}

#pragma warning restore IDE0060
