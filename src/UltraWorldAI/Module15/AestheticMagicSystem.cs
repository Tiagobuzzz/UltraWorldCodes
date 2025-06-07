using System;
using System.Collections.Generic;

namespace UltraWorldAI.Module15;

public class AestheticSpell
{
    public string Artist = string.Empty;
    public string ArtForm = string.Empty;
    public string Effect = string.Empty;
    public float Potency;
}

public static class AestheticMagicSystem
{
    public static List<AestheticSpell> Spells { get; } = new();

    public static void CreateSpell(string artist, string artForm, string effect, float potency)
    {
        Spells.Add(new AestheticSpell
        {
            Artist = artist,
            ArtForm = artForm,
            Effect = effect,
            Potency = potency
        });

        Console.WriteLine($"\uD83D\uDDFF Arte m\u00E1gica de {artist} em {artForm}: {effect} (Pot\u00EAncia: {potency})");
    }

    public static List<AestheticSpell> AllSpells() => Spells;
}
