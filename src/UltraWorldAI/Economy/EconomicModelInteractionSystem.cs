using System;
using System.Collections.Generic;

namespace UltraWorldAI.Economy;

public class ModelInteraction
{
    public string ModelA { get; set; } = string.Empty;
    public string ModelB { get; set; } = string.Empty;
    public string Result { get; set; } = string.Empty;
    public string InteractionType { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
}

public static class EconomicModelInteractionSystem
{
    public static List<ModelInteraction> Interactions { get; } = new();

    public static void RegisterInteraction(string modelA, string modelB, string type, string result, string description)
    {
        Interactions.Add(new ModelInteraction
        {
            ModelA = modelA,
            ModelB = modelB,
            Result = result,
            InteractionType = type,
            Description = description
        });

        Console.WriteLine($"\uD83D\uDD00 Intera\u00e7\u00e3o registrada: {modelA} x {modelB} \u2192 {result} ({type})");
    }

    public static void PrintInteractions()
    {
        foreach (var i in Interactions)
        {
            Console.WriteLine($"\uD83E\uDD01 {i.ModelA} \u00d7 {i.ModelB} | {i.InteractionType} \u2192 {i.Result}");
            Console.WriteLine($"\uD83D\uDCDD {i.Description}\n");
        }
    }
}
