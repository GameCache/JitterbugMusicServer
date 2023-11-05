using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Xml;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.Primitives;
using Microsoft.Net.Http.Headers;

namespace JitterbugMusic.Server.OpenSubsonic;

/// <summary>Controls Subsonic serialization based upon format in request header.</summary>
internal sealed class SubsonicOutputFormatter : TextOutputFormatter
{
    /// <summary>Standard XML formatter to use for serialization.</summary>
    private static readonly XmlSerializerOutputFormatter _XmlFormatter = new(new XmlWriterSettings
    {
        OmitXmlDeclaration = true,
        NamespaceHandling = NamespaceHandling.OmitDuplicates
    });

    /// <summary>Standard JSON formatter to use for serialization.</summary>
    private static readonly SystemTextJsonOutputFormatter _JsonFormatter = new(new JsonSerializerOptions
    {
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
    });

    /// <inheritdoc cref="SubsonicOutputFormatter"/>
    public SubsonicOutputFormatter()
    {
        SupportedMediaTypes.Add(MediaTypeHeaderValue.Parse("application/json"));
        SupportedMediaTypes.Add(MediaTypeHeaderValue.Parse("application/xml"));
        SupportedMediaTypes.Add(MediaTypeHeaderValue.Parse("text/javascript"));

        SupportedEncodings.Add(Encoding.UTF8);
    }

    /// <inheritdoc/>
    protected override bool CanWriteType(Type? type)
    {
        return true;
        //return typeof(SubsonicResponse<>).IsAssignableFrom(type);
    }

    /// <inheritdoc/>
    public override Task WriteResponseBodyAsync(OutputFormatterWriteContext context, Encoding selectedEncoding)
    {
        if (context.Object != null)
        {
            string format = "";
            if (context.HttpContext.Request.Query.TryGetValue("f", out StringValues value))
            {
                format = value.ToString();
            }

            switch (format)
            {
                case "json":
                    SetMediaTypeHeader(context, "application/json");
                    return _JsonFormatter.WriteResponseBodyAsync(context, selectedEncoding);
                case "jsonp":
                    SetMediaTypeHeader(context, "text/javascript");
                    return WriteJsonpResponseBodyAsync(context, selectedEncoding);
                default:
                    SetMediaTypeHeader(context, "application/xml");
                    return _XmlFormatter.WriteResponseBodyAsync(context, selectedEncoding);
            }
        }
        else
        {
            return Task.CompletedTask;
        }
    }

    /// <inheritdoc/>
    private static async Task WriteJsonpResponseBodyAsync(
        OutputFormatterWriteContext context, Encoding selectedEncoding)
    {
        string? callback;
        if (context.HttpContext.Request.Query.TryGetValue("callback", out StringValues value))
        {
            callback = value;
        }
        else
        {
            callback = null;
        }

        await context.HttpContext.Response.WriteAsync(callback + "(", selectedEncoding).ConfigureAwait(false);
        await _JsonFormatter.WriteResponseBodyAsync(context, selectedEncoding).ConfigureAwait(false);
        await context.HttpContext.Response.WriteAsync(");", selectedEncoding).ConfigureAwait(false);
    }

    /// <summary>Fixes the content type header.</summary>
    /// <param name="context">Current context to fix.</param>
    /// <param name="mediaType">Media type for the content.</param>
    private static void SetMediaTypeHeader(OutputFormatterWriteContext context, string mediaType)
    {
        context.HttpContext.Response.ContentType = new MediaTypeHeaderValue(mediaType)
        {
            Charset = "utf-8"
        }.ToString();
    }
}
