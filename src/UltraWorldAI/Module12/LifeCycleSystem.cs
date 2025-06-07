using System;
using System.Collections.Generic;

namespace UltraWorldAI.Module12;

public enum LifeStage
{
    Infant,
    Youth,
    Adult,
    Elder,
    Deceased
}

public class LifeProfile
{
    public string Name { get; set; } = string.Empty;
    public string Species { get; set; } = string.Empty;
    public int Age { get; set; }
    public LifeStage Stage { get; set; }
    public Dictionary<string, float> Traits { get; set; } = new();
}

public static class LifeCycleSystem
{
    public static List<LifeProfile> Beings { get; } = new();

    public static void RegisterBeing(string name, string species, int age, Dictionary<string, float> traits)
    {
        var stage = GetStage(age);
        Beings.Add(new LifeProfile
        {
            Name = name,
            Species = species,
            Age = age,
            Stage = stage,
            Traits = traits
        });

        Console.WriteLine($"\uD83D\uDC76 Nascido: {name} | Raça: {species} | Idade: {age} | Estágio: {stage}");
    }

    public static LifeStage GetStage(int age)
    {
        if (age <= 5) return LifeStage.Infant;
        if (age <= 18) return LifeStage.Youth;
        if (age <= 60) return LifeStage.Adult;
        return LifeStage.Elder;
    }

    public static void AgeAll()
    {
        foreach (var b in Beings)
        {
            b.Age++;
            b.Stage = GetStage(b.Age);
        }
    }
}
