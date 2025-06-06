using UltraWorldAI;
using System.Collections.Generic;
using Xunit;

public class CalendarBuilderTests
{
    [Fact]
    public void CustomMonthsAreUsed()
    {
        var months = new List<string> { "Alpha", "Beta" };
        var cal = CalendarBuilder.CreateCalendar(CalendarType.Lunar, months);
        Assert.Equal(months, cal.Months);
    }
}
