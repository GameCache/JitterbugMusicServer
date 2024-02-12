using JitterbugMusic.Models.OpenSubsonic;
using JitterbugMusic.Models.OpenSubsonic.AlbumSongLists;
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

    /// <summary>Returns all genres.</summary>
    /// <param name="options"><inheritdoc cref="SubsonicRequest" path="/summary"/></param>
    /// <returns><inheritdoc cref="GenresDto" path="/summary"/></returns>
    [HttpGet("getGenres")]
    public SubsonicDataResponse<GenresDto> GetGenres([FromQuery] SubsonicRequest options)
    {
        return new SubsonicDataResponse<GenresDto>()
        {
            Content = new GenresDto()
            {
                Genre =
                [
                    new GenreDto()
                    {
                        SongCount = 1,
                        AlbumCount = 1,
                        Value = "Punk"
                    },
                    new GenreDto()
                    {
                        SongCount = 4,
                        AlbumCount = 1,
                        Value = "Dark Ambient"
                    },
                    new GenreDto()
                    {
                        SongCount = 6,
                        AlbumCount = 1,
                        Value = "Noise"
                    },
                    new GenreDto()
                    {
                        SongCount = 11,
                        AlbumCount = 1,
                        Value = "Electronica"
                    },
                    new GenreDto()
                    {
                        SongCount = 11,
                        AlbumCount = 1,
                        Value = "Dance"
                    },
                    new GenreDto()
                    {
                        SongCount = 12,
                        AlbumCount = 1,
                        Value = "Electronic"
                    },
                    new GenreDto()
                    {
                        SongCount = 20,
                        AlbumCount = 1,
                        Value = "Hip-Hop"
                    }
                ]
            }
        };
    }

    /// <summary>Returns all artists.</summary>
    /// <param name="options"><inheritdoc cref="SubsonicRequest" path="/summary"/></param>
    /// <param name="musicFolderId">
    ///     If specified, only return artists in the music folder with the given ID. See getMusicFolders.
    /// </param>
    /// <returns><inheritdoc cref="ArtistsDto" path="/summary"/></returns>
    /// <remarks>Similar to getIndexes, but organizes music according to ID3 tags.</remarks>
    [HttpGet("getArtists")]
    public SubsonicDataResponse<ArtistsDto> GetArtists(
        [FromQuery] SubsonicRequest options,
        [FromQuery] string? musicFolderId)
    {
        return new SubsonicDataResponse<ArtistsDto>()
        {
            Content = new ArtistsDto()
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

    /// <summary>
    ///     Returns details for an artist, including a list of albums.
    ///     This method organizes music according to ID3 tags.
    /// </summary>
    /// <param name="options"><inheritdoc cref="SubsonicRequest" path="/summary"/></param>
    /// <param name="id">The artist ID.</param>
    /// <returns><inheritdoc cref="IndexesDto" path="/summary"/></returns>
    /// <remarks>Similar to getIndexes, but organizes music according to ID3 tags.</remarks>
    [HttpGet("getArtist")]
    public SubsonicDataResponse<ArtistDto> GetArtist(
        [FromQuery] SubsonicRequest options,
        [FromQuery] string id)
    {
        return new SubsonicDataResponse<ArtistDto>()
        {
            Content = new ArtistDto()
            {
                Id = "5432",
                Name = "AC/DC",
                Album =
                [
                    new AlbumId3Dto()
                    {
                        Id = "11047",
                        Name = "Back In Black",
                        CoverArt = "al-200000002",
                        SongCount = 12,
                        Created = DateTime.UtcNow,
                        Duration = 4568,
                        PlayCount = 1,
                        ArtistId = "100000002",
                        Artist = "Synthetic",
                        Year = 2007,
                        Genre = "Electronic",
                        UserRating = 5,
                        Starred = "2021-02-22T05:51:53Z"
                    }
                ]
            }
        };
    }
}

#pragma warning restore IDE0060
