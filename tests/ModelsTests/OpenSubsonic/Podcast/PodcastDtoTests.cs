using System.Linq;
using JitterbugMusic.Models.OpenSubsonic.Podcast;

namespace JitterbugMusic.ModelsTests.OpenSubsonic.Podcast;

public class PodcastDtoTests : BaseSubsonicDtoTests<PodcastDto>
{
    protected internal override PodcastDto FixModel(PodcastDto original)
    {
        original.Episodes = original.Episodes.ToList();
        return original;
    }
}