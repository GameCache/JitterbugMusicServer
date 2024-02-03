using JitterbugMusic.Models.OpenSubsonic;
using JitterbugMusic.Models.OpenSubsonic.Browsing;
using Microsoft.AspNetCore.Mvc;

namespace JitterbugMusic.Server.OpenSubsonic;

#pragma warning disable IDE0060

/// <summary>Endpoints for the OpenSubsonic System category.</summary>
[ApiController, Route("rest")]
public sealed class BrowsingController : ControllerBase
{
    /// <summary>A subsonic-response element with a nested musicFolders element on success.</summary>
    /// <param name="options"><inheritdoc cref="SubsonicRequest" path="/summary"/></param>
    /// <returns><inheritdoc cref="MusicFolderDto" path="/summary"/></returns>
    [HttpGet("getMusicFolders")]
    public SubsonicSeriesResponse<MusicFolderDto> GetMusicFolders([FromQuery] SubsonicRequest options)
    {
        return new SubsonicSeriesResponse<MusicFolderDto>()
        {
            Contents = new[]
            {
                new MusicFolderDto() { Id = "1", Name = "music" },
                new MusicFolderDto() { Id = "4", Name = "upload" }
            }
        };
    }

    /// <summary>Returns an indexed structure of all artists.</summary>
    /// <param name="options"><inheritdoc cref="SubsonicRequest" path="/summary"/></param>
    /// <param name="musicFolderId">
    ///     If specified, only return artists in the music folder with the given ID. See getMusicFolders.
    /// </param>
    /// <param name="ifModifiedSince">
    ///     If specified, only return a result if the artist collection has changed since the given time (in milliseconds since 1 Jan 1970).
    /// </param>
    /// <returns><inheritdoc cref="IndexesDto" path="/summary"/></returns>
    [HttpGet("getIndexes")]
    public SubsonicDataResponse<IndexesDto> GetIndexes(
        [FromQuery] SubsonicRequest options,
        [FromQuery] string? musicFolderId,
        [FromQuery] long? ifModifiedSince)
    {
        return new SubsonicDataResponse<IndexesDto>()
        {
            Content = new IndexesDto()
            {
                IgnoredArticles = ["The", "An", "A", "Die", "Das", "Ein", "Eine", "Les", "Le", "La"],
                Index = [
                    new IndexId3Dto()
                    {
                        Name = "C",
                        Artist = [
                            new ArtistId3Dto()
                            {
                                Id = "100000016",
                                Name = "CANDY",
                                CoverArt = "ar-100000016",
                                AlbumCount = 1
                            },
                            new ArtistId3Dto()
                            {
                                Id = "100000017",
                                Name = "Chic",
                                CoverArt = "ar-100000027",
                                AlbumCount = 0
                            }
                        ]
                    },
                    new IndexId3Dto()
                    {
                        Name = "I",
                        Artist = [
                            new ArtistId3Dto()
                            {
                                Id = "100000013",
                                Name = "Ok1",
                                CoverArt = "ar-100000013",
                                AlbumCount = 1,
                                Starred = DateTime.UtcNow
                            }
                        ]
                    }
                ]
            }
        };
    }

    /// <summary>Returns a listing of all files in a music directory.</summary>
    /// <param name="options"><inheritdoc cref="SubsonicRequest" path="/summary"/></param>
    /// <param name="id">A string which uniquely identifies the music folder. Obtained by calls to getIndexes or getMusicDirectory.</param>
    /// <returns><inheritdoc cref="DirectoryDto" path="/summary"/></returns>
    [HttpGet("getMusicDirectory")]
    public SubsonicDataResponse<DirectoryDto> GetMusicDirectory(
        [FromQuery] SubsonicRequest options,
        [FromQuery] string id)
    {
        return new SubsonicDataResponse<DirectoryDto>()
        {
            Content = new DirectoryDto()
            {
                Id = "1",
                Name = "music",
                Child = [
                    new()
                    {
                        Id = "100000016",
                        Parent = "1",
                        IsDir = true,
                        Title = "Cancun",
                        Artist = "Cancun",
                        CoverArt = "ar-100000016"
                    },
                    new()
                    {
                        Id = "100000027",
                        Parent = "1",
                        IsDir = true,
                        Title = "Chi.Otic",
                        Artist = "Chi.Otic",
                        CoverArt = "ar-100000027"
                    }
                ]
            }
        };
    }
}

#pragma warning restore IDE0060
