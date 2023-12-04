using CreateAndFake.Fluent;
using JitterbugMusic.Models.OpenSubsonic;
using JitterbugMusic.Models.OpenSubsonic.System;
using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Xunit;

namespace JitterbugMusic.ServerTests;

public class ProgramTests(WebApplicationFactory<Program> factory) : IClassFixture<WebApplicationFactory<Program>>
{
    [Fact]
    internal async Task Program_SwaggerEndpointWorks()
    {
        HttpResponseMessage response = await factory
            .CreateClient()
            .GetAsync(new Uri("/swagger"))
            .ConfigureAwait(false);

        response.EnsureSuccessStatusCode();
        response.Content.Headers.ContentType.ToString().Assert().Is("text/html; charset=utf-8");
    }

    [Fact]
    internal async Task Program_PingWorksWithXmlResult()
    {
        HttpResponseMessage response = await factory
            .CreateClient()
            .GetAsync("/rest/ping?f=xml")
            .ConfigureAwait(false);

        response.EnsureSuccessStatusCode();
        response.Content.Headers.ContentType.ToString().Assert().Is("application/xml; charset=utf-8");

        using (XmlReader reader = XmlReader.Create(await response.Content.ReadAsStreamAsync().ConfigureAwait(false)))
        {
            object? result = new XmlSerializer(typeof(SubsonicDataResponse<NoContentDto>)).Deserialize(reader);
            (result as SubsonicDataResponse<NoContentDto>).Assert().IsNot(null);
        }
    }

    [Fact]
    internal async Task Program_PingWorksWithJsonResult()
    {
        HttpResponseMessage response = await factory
            .CreateClient()
            .GetAsync("/rest/ping?f=json")
            .ConfigureAwait(false);

        response.EnsureSuccessStatusCode();
        response.Content.Headers.ContentType.ToString().Assert().Is("application/json; charset=utf-8");

        object? result = JsonSerializer.Deserialize(
            await response.Content.ReadAsStringAsync().ConfigureAwait(false),
            typeof(SubsonicDataResponse<NoContentDto>));

        (result as SubsonicDataResponse<NoContentDto>).Assert().IsNot(null);
    }

    [Fact]
    internal async Task Program_PingWorksWithJsonpResult()
    {
        HttpResponseMessage response = await factory
            .CreateClient()
            .GetAsync("/rest/ping?f=jsonp&callback=myFunc")
            .ConfigureAwait(false);

        response.EnsureSuccessStatusCode();
        response.Content.Headers.ContentType.ToString().Assert().Is("text/javascript; charset=utf-8");

        string result = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
        result.Assert().Contains("myFunc");
    }

    [Fact]
    internal async Task Program_PingDefaultIsXmlResult()
    {
        HttpResponseMessage response = await factory
            .CreateClient()
            .GetAsync("/rest/ping")
            .ConfigureAwait(false);

        response.EnsureSuccessStatusCode();
        response.Content.Headers.ContentType.ToString().Assert().Is("application/xml; charset=utf-8");

        using (XmlReader reader = XmlReader.Create(await response.Content.ReadAsStreamAsync().ConfigureAwait(false)))
        {
            object? result = new XmlSerializer(typeof(SubsonicDataResponse<NoContentDto>)).Deserialize(reader);
            (result as SubsonicDataResponse<NoContentDto>).Assert().IsNot(null);
        }
    }

    [Fact]
    internal async Task Program_PingMissingCallbackWithJsonpEmpty()
    {
        HttpResponseMessage response = await factory
            .CreateClient()
            .GetAsync("/rest/ping?f=jsonp")
            .ConfigureAwait(false);

        response.EnsureSuccessStatusCode();
        response.Content.Headers.ContentType.ToString().Assert().Is("text/javascript; charset=utf-8");

        string result = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
        result.Assert().Contains(";");
    }
}