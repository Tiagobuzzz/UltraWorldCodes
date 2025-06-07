using System;
using System.Linq;

namespace UltraWorldAI;

public static class PsychogenesisOverload
{
    public static void CheckForOverload(string culture)
    {
        var manifested = PsychogenesisSystem.ActiveBeliefs.Count(b => b.Culture == culture && b.Manifested);
        if (manifested > 3)
        {
            CulturalCollapse.CollapseCulture(new Culture { Name = culture });
            Console.WriteLine($"\uD83E\uDD2F Cultura '{culture}' se autodestruiu por excesso de psicog\u00eanese.");
        }
    }
}
