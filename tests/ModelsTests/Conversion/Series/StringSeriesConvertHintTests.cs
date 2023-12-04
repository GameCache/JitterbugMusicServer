using System;
using System.Collections.Generic;
using System.Linq;
using JitterbugMusic.Models.Conversion.Series;

namespace JitterbugMusic.ModelsTests.Conversion.Series;

public class StringSeriesConvertHintTests : BaseSeriesConvertHint<StringSeriesConvertHintTests, IEnumerable<string>>
{
    protected override ISeriesConvertHint<StringSeriesConvertHintTests> CreateSeriesHint(
        string? seriesName, string itemName,
        Func<StringSeriesConvertHintTests, IEnumerable<string>?> getter,
        Action<StringSeriesConvertHintTests, IEnumerable<string>?> setter)
    {
        return new StringSeriesConvertHint<StringSeriesConvertHintTests>(seriesName, itemName, getter, setter);
    }

    protected override IEnumerable<string> FixModel(IEnumerable<string> original)
    {
        return original.ToList();
    }
}