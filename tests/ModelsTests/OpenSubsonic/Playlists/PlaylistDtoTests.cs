using System.Linq;
using JitterbugMusic.Models.OpenSubsonic.Playlists;

namespace JitterbugMusic.ModelsTests.OpenSubsonic.Playlists;

public class PlaylistDtoTests : BaseSubsonicDtoTests<PlaylistDto>
{
    protected internal override PlaylistDto FixModel(PlaylistDto original)
    {
        original.AllowedUser = original.AllowedUser.ToList();
        return original;
    }
}
