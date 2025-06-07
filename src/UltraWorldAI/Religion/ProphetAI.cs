using System;

namespace UltraWorldAI.Religion;

public class ProphetAI
{
    public string Name { get; set; } = string.Empty;
    public string Culture { get; set; } = string.Empty;
    public float FaithLevel { get; set; }
    public float MadnessLevel { get; set; }

    public void InterpretDivineWill()
    {
        var rng = new Random();
        var insight = FaithLevel - MadnessLevel + (float)rng.NextDouble() * 0.3f;

        if (insight > 0.8f)
        {
            Console.WriteLine($"\uD83D\uDD2E {Name} recebe vis\u00e3o clara: 'O deus deseja paz e reclus\u00e3o.'");
        }
        else if (insight > 0.5f)
        {
            Console.WriteLine($"\uD83C\uDF00 {Name} interpreta: 'Devemos sacrificar artistas... talvez isso agrade a divindade.'");
        }
        else
        {
            Console.WriteLine($"\uD83D\uDD25 {Name} entra em del\u00edrio: 'A voz do deus me disse para incendiar o oceano e beber a fuma\u00e7a.'");
        }
    }
}
