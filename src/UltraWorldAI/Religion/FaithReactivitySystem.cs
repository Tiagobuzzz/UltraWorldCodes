using System;
using System.Collections.Generic;

namespace UltraWorldAI.Religion;

public static class FaithReactivitySystem
{
    public static readonly Dictionary<string, float> FanaticismByCulture = new();

    public static void RegisterMiracle(string culture)
    {
        if (!FanaticismByCulture.ContainsKey(culture))
            FanaticismByCulture[culture] = 0f;

        FanaticismByCulture[culture] += 0.25f;

        if (FanaticismByCulture[culture] >= 1f)
        {
            Console.WriteLine($"\u26A0\uFE0F ALERTA: Fanatismo extremo em {culture} \u2192 comportamento radicalizado, inquisi\u00e7\u00f5es ou cruzadas poss\u00edveis.");
        }
        else
        {
            Console.WriteLine($"\uD83D\uDE96 {culture} se torna mais fervorosa ap\u00f3s testemunhar um milagre.");
        }
    }
}
