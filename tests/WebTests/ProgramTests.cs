using CreateAndFake.Fluent;
using JitterbugMusicServer.Web.OpenSubsonic;
using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Xunit;

namespace JitterbugMusicServer.WebTests;

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
            object? result = new XmlSerializer(typeof(SubsonicResponse)).Deserialize(reader);
            (result as SubsonicResponse).Assert().IsNot(null);
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
            typeof(ResponseJsonWrapper<SubsonicResponse>));

        (result as ResponseJsonWrapper<SubsonicResponse>).Assert().IsNot(null);
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
            object? result = new XmlSerializer(typeof(SubsonicResponse)).Deserialize(reader);
            (result as SubsonicResponse).Assert().IsNot(null);
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