using CreateAndFake;
using CreateAndFake.Fluent;
using JitterbugMusic.Models.OpenSubsonic.Browsing;
using Xunit;

namespace JitterbugMusic.ModelsTests.OpenSubsonic.Browsing;

public class ArtistsDtoTests : BaseSubsonicDtoTests<ArtistsDto>
{
    [Theory, RandomData]
    internal void CombinedIgnoredArticles_NullSafe(ArtistsDto original)
    {
        original.CombinedIgnoredArticles = null;
        original.CombinedIgnoredArticles.Assert().Is(null);
    }
}
