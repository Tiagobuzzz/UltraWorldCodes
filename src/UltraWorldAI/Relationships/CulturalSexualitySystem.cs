using System;
using System.Collections.Generic;

namespace UltraWorldAI.Relationships;

public class SexualNorms
{
    public string Culture = string.Empty;
    public string UnionModel = string.Empty;
    public List<string> AcceptedActs = new();
    public string ReproductionMethod = string.Empty;
}

public static class CulturalSexualitySystem
{
    public static List<SexualNorms> Norms { get; } = new();

    public static void DefineNorms(string culture, string model, List<string> acts, string reproduction)
    {
        Norms.Add(new SexualNorms
        {
            Culture = culture,
            UnionModel = model,
            AcceptedActs = acts,
            ReproductionMethod = reproduction
        });

        Console.WriteLine($"\uD83C\uDF3A Culture {culture}: {model}, Reproduction: {reproduction}");
    }
}
