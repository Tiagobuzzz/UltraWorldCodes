using System.Collections.Generic;
using System.Linq;

namespace UltraWorldAI;

public static class CalendarBuilder
{
public static Calendar CreateCalendar(CalendarType type, List<string>? customMonths = null)
{
    var calendar = new Calendar(type)
    {
        Months = customMonths ?? Enumerable.Range(1, 12)
            .Select(i => type switch
            {
                CalendarType.Lunar => $"Lua-{i}",
                CalendarType.Solar => $"Sol-{i}",
                CalendarType.Ritmico => $"Pulso-{i}",
                CalendarType.Emocional => $"Sent-{i}",
                CalendarType.Profetico => $"Vis-{i}",
                _ => $"M{i}"
            })
            .ToList()
    };

        return calendar;
    }
}
