using JitterbugMusic.Models.OpenSubsonic;
using JitterbugMusic.Models.OpenSubsonic.Podcast;
using Microsoft.AspNetCore.Mvc;

namespace JitterbugMusic.Server.OpenSubsonic;

#pragma warning disable IDE0060

/// <summary>Endpoints for the OpenSubsonic System category.</summary>
[ApiController, Route("rest")]
public sealed class PodcastController : ControllerBase
{
    /// <summary>A subsonic-response element with a nested musicFolders element on success.</summary>
    /// <param name="options"><inheritdoc cref="SubsonicRequest" path="/summary"/></param>
    /// <returns><inheritdoc cref="PodcastDto" path="/summary"/></returns>
    [HttpGet("getPodcasts")]
    public SubsonicSeriesResponse<PodcastDto> GetPodcasts([FromQuery] SubsonicRequest options)
    {
        return new SubsonicSeriesResponse<PodcastDto>()
        {
            Contents = new[]
            {
                new PodcastDto() {
                    Id = "1",
                    Url = new Uri("http://downloads.bbc.co.uk/podcasts/fivelive/drkarl/rss.xml"),
                    Title = "Dr Karl and the Naked Scientist",
                    Description = "Dr Chris Smith aka The Naked Scientist with the latest news from the world of science and Dr Karl answers listeners' science questions.",
                    CoverArt = "pod-1",
                    OriginalImageUrl = new Uri("http://downloads.bbc.co.uk/podcasts/fivelive/drkarl/drkarl.jpg"),
                    Status = "completed",
                    Episodes = new[]
                    {
                        new EpisodeDto()
                        {
                            Id = "34",
                            StreamId = "523",
                            ChannelId = "1",
                            Title = "Scorpions have re-evolved eyes",
                            Description = "This week Dr Chris fills us in on the UK's largest free science festival, plus all this week's big scientific discoveries.",
                            PublishDate = DateTime.UtcNow,
                            Status = "completed",
                            Parent = "11",
                            IsDir = false,
                            Year = 2011,
                            Genre = "Podcast",
                            CoverArt = "24",
                            Size = 78421341,
                            ContentType = "audio/mpeg",
                            Suffix = "mp3",
                            Duration = 3146,
                            BitRate = 128,
                            Path = "Podcast/drkarl/20110203.mp3"
                        }, new EpisodeDto() {
                            Id = "35",
                            StreamId = "524",
                            ChannelId = "1",
                            Title = "Scar tissue and snake venom treatment",
                            Description = "This week Dr Karl tells the gruesome tale of a surgeon who operated on himself.",
                            PublishDate = DateTime.UtcNow,
                            Status = "completed",
                            Parent = "11",
                            IsDir = false,
                            Year = 2011,
                            Genre = "Podcast",
                            CoverArt = "27",
                            Size = 45624671,
                            ContentType = "audio/mpeg",
                            Suffix = "mp3",
                            Duration = 3099,
                            BitRate = 128,
                            Path = "Podcast/drkarl/20110903.mp3"
                        }
                    }
                }, new PodcastDto() {
                    Id = "2",
                    Url = new Uri("http://podkast.nrk.no/program/herreavdelingen.rss"),
                    Title = "NRK P1 - Herreavdelingen",
                    Description = "Et program der herrene Yan Friis og Finn Bjelke møtes og musikk nytes.",
                    CoverArt = "pod-2",
                    OriginalImageUrl = new Uri("http://gfx.nrk.no/oP_mZkqyrOkZiAOilZPvFA1nlzIxOYVV9yq7P_J-ngjw.jpg"),
                    Status = "completed"
                }, new PodcastDto() {
                    Id = "3",
                    Url = new Uri("http://foo.bar.com/xyz.rss"),
                    Status = "error",
                    ErrorMessage = "Not found."
                }
            }
        };
    }
}

#pragma warning restore IDE0060