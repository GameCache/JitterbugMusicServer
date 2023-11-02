using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Xml;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.Primitives;
using Microsoft.Net.Http.Headers;

namespace JitterbugMusicServer.Web.OpenSubsonic;

internal sealed class SubsonicOutputFormatter : TextOutputFormatter
{
    private static readonly XmlSerializerOutputFormatter _XmlFormatter = new(new XmlWriterSettings
    {
        OmitXmlDeclaration = true,
        NamespaceHandling = NamespaceHandling.OmitDuplicates
    });

    private static readonly SystemTextJsonOutputFormatter _JsonFormatter = new(new JsonSerializerOptions
    {
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
    });

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
        return typeof(SubsonicResponse).IsAssignableFrom(type);
    }

    private static object CreateJsonWrapper(object content)
    {
#pragma warning disable CS8602
        return typeof(ResponseJsonWrapper<>)
            .MakeGenericType(content.GetType())
            .GetConstructor([content.GetType()])
            .Invoke([content]);
#pragma warning restore CS8602
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

                    object wrapper = CreateJsonWrapper(context.Object);
                    return _JsonFormatter.WriteResponseBodyAsync(new OutputFormatterWriteContext(
                        context.HttpContext, context.WriterFactory, wrapper.GetType(), wrapper), selectedEncoding);
                case "jsonp":
                    SetMediaTypeHeader(context, "text/javascript");
                    return WriteJsonpResponseBodyAsync(context.Object, context, selectedEncoding);
                default:
                    SetMediaTypeHeader(context, "application/xml");
                    return _XmlFormatter.WriteResponseBodyAsync(context, selectedEncoding);
            }
        }
        return Task.CompletedTask;
    }

    private static void SetMediaTypeHeader(OutputFormatterWriteContext context, string mediaType)
    {
        context.HttpContext.Response.ContentType = new MediaTypeHeaderValue(mediaType)
        {
            Charset = "utf-8"
        }.ToString();
    }

    /// <inheritdoc/>
    private static async Task WriteJsonpResponseBodyAsync(
        object content, OutputFormatterWriteContext context, Encoding selectedEncoding)
    {
        object wrapper = CreateJsonWrapper(content);

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
        await _JsonFormatter.WriteResponseBodyAsync(new OutputFormatterWriteContext(
            context.HttpContext, context.WriterFactory, wrapper.GetType(), wrapper), selectedEncoding).ConfigureAwait(false);
        await context.HttpContext.Response.WriteAsync(");", selectedEncoding).ConfigureAwait(false);
    }
}
