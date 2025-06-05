using System.Collections.Generic;
using System.Linq;

namespace UltraWorldAI
{
    public static class CalendarBuilder
    {
        public static Calendar CreateBasicCalendar(string type)
        {
            var months = Enumerable.Range(1, 12)
                .Select(i => type switch
                {
                    "Lunar" => $"Lua-{i}",
                    "Solar" => $"Sol-{i}",
                    _ => $"M{i}"
                })
                .ToList();
            return new Calendar { Type = type, Months = months };
        }
    }
}
