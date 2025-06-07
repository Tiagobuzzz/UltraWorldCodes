using System;
using System.Collections.Generic;

namespace UltraWorldAI.Module16;

public enum MentalState { Normal, Perturbado, Extatico, Insano }

public class CognitiveReaction
{
    public string AI = string.Empty;
    public string Region = string.Empty;
    public float NoiseLevel;
    public MentalState State;
}

public static class CognitiveOverloadSystem
{
    public static List<CognitiveReaction> Reactions { get; } = new();

    public static MentalState EvaluateState(float noise)
    {
        if (noise < 5) return MentalState.Normal;
        if (noise < 15) return MentalState.Perturbado;
        if (noise < 25) return MentalState.Extatico;
        return MentalState.Insano;
    }

    public static void ReactToNoise(string ai, string region)
    {
        float noise = MentalNoiseSystem.GetNoiseLevel(region);
        var state = EvaluateState(noise);

        Reactions.Add(new CognitiveReaction
        {
            AI = ai,
            Region = region,
            NoiseLevel = noise,
            State = state
        });

        Console.WriteLine($"\uD83E\uDEE8 {ai} est\u00e1 agora em estado mental: {state} (Ru\u00eddo: {noise:0.00})");
    }
}
