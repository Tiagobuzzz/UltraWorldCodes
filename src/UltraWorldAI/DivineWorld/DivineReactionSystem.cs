using System;

namespace UltraWorldAI.DivineWorld;

public static class DivineReactionSystem
{
    public static void ReactToSilence(string culture)
    {
        var rng = new Random();
        var roll = rng.Next(0, 100);

        if (roll < 30)
        {
            Console.WriteLine($"\uD83D\uDE28 {culture} come\u00e7a a temer o abandono divino \u2192 surgem hereges e cultos apocal\u00edpticos.");
        }
        else if (roll < 60)
        {
            Console.WriteLine($"\uD83D\uDE4B {culture} interpreta o sil\u00eancio como teste \u2192 nasce uma nova doutrina de paci\u00eancia sagrada.");
        }
        else
        {
            Console.WriteLine($"\uD83D\uDCA3 {culture} declara que o deus est\u00e1 morto \u2192 revolu\u00e7\u00f5es e guerras teol\u00f3gicas se iniciam.");
        }
    }
}
