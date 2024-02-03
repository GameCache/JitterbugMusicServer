using System;
using System.Collections.Generic;
using JitterbugMusic.Models.Conversion.Series;

namespace JitterbugMusic.ModelsTests.Conversion.Series;

public class IntSeriesConvertHintTests : BaseSeriesConvertHint<IntSeriesConvertHintTests, IEnumerable<int>>
{
    protected override ISeriesConvertHint<IntSeriesConvertHintTests> CreateSeriesHint(
        string? seriesName, string itemName,
        Func<IntSeriesConvertHintTests, IEnumerable<int>?> getter,
        Action<IntSeriesConvertHintTests, IEnumerable<int>?> setter)
    {
        return new IntSeriesConvertHint<IntSeriesConvertHintTests>(seriesName, itemName, getter, setter);
    }
}