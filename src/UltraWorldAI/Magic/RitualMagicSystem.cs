using System;
using System.Collections.Generic;

namespace UltraWorldAI.Magic;

public class Ritual
{
    public string Name = string.Empty;
    public List<string> RequiredComponents = new();
    public string CirclePattern = string.Empty; // "Pentagrama de Sangue", "Espiral Lunar", etc.
    public string Effect = string.Empty; // "Invocar criatura", "Selar portal", "Purificar alma"
}

public static class RitualMagicSystem
{
    public static List<Ritual> Rituals { get; } = new();

    public static void RegisterRitual(string name, List<string> components, string pattern, string effect)
    {
        Rituals.Add(new Ritual
        {
            Name = name,
            RequiredComponents = components,
            CirclePattern = pattern,
            Effect = effect
        });

        Console.WriteLine($"\uD83D\uDD6F Ritual registrado: {name} | Padr\u00E3o: {pattern} | Efeito: {effect}");
    }

    public static void PrintRituals()
    {
        foreach (var r in Rituals)
            Console.WriteLine($"\n\uD83D\uDD34 {r.Name} | Padr\u00E3o: {r.CirclePattern} | Efeito: {r.Effect} | Componentes: {string.Join(", ", r.RequiredComponents)}");
    }
}
