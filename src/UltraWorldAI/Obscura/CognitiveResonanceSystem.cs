using System;
using System.Collections.Generic;

namespace UltraWorldAI.Obscura;

public enum MindEffect
{
    None,
    Amnesia,
    Obsessao,
    Visao,
    Despersonalizacao,
    Transcendencia
}

public class MentalReaction
{
    public string AI = string.Empty;
    public string Location = string.Empty;
    public MindEffect Effect;
}

public static class CognitiveResonanceSystem
{
    public static List<MentalReaction> Reactions { get; } = new();

    public static void ApplyEffect(string ai, string location)
    {
        MindEffect effect = (MindEffect)new Random().Next(1, 6);

        Reactions.Add(new MentalReaction
        {
            AI = ai,
            Location = location,
            Effect = effect
        });

        Console.WriteLine($"🌀 {ai} foi afetado por {effect} após entrar em {location}");
    }
}
