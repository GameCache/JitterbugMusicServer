using Microsoft.AspNetCore.Mvc;

namespace JitterbugMusicServer.Web.OpenSubsonic;

/// <summary>Basic query options for OpenSubsonic endpoints.</summary>
public sealed class SubsonicRequest
{
    /// <summary>The username.</summary>
    [FromQuery(Name = "u")]
    public string Username { get; set; } = "";

    /// <summary>The password, either in clear text or hex-encoded with a “enc:” prefix. Since 1.13.0 this should only be used for testing purposes.</summary>
    [FromQuery(Name = "p")]
    public string Password { get; set; } = "";

    /// <summary>(Since 1.13.0) The authentication token computed as md5(password + salt). See below for details.</summary>
    [FromQuery(Name = "t")]
    public string Token { get; set; } = "";

    /// <summary>(Since 1.13.0) A random string (“salt”) used as input for computing the password hash. See below for details.</summary>
    [FromQuery(Name = "s")]
    public string Salt { get; set; } = "";

    /// <summary>The protocol version implemented by the client, i.e., the version of the subsonic-rest-api.xsd schema used (see below).</summary>
    [FromQuery(Name = "v")]
    public string Version { get; set; } = "";

    /// <summary>A unique string identifying the client application.</summary>
    [FromQuery(Name = "c")]
    public string Client { get; set; } = "";

    /// <summary>Request data to be returned in this format. Supported values are “xml”, “json” (since 1.4.0) and “jsonp” (since 1.6.0). If using jsonp, specify name of javascript callback function using a callback parameter.</summary>
    [FromQuery(Name = "f")]
    public string? Format { get; set; } = "xml";

    /// <summary>Callback to use when using the "jsonp" format.</summary>
    [FromQuery(Name = "callback")]
    public string? Callback { get; set; }
}