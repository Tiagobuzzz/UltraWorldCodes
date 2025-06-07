using System;
using System.Collections.Generic;

namespace UltraWorldAI.Module13;

public class FragmentedSoul
{
    public string OriginalSoul { get; set; } = string.Empty;
    public List<string> Incarnations { get; set; } = new();
    public string CurrentDominantIdentity { get; set; } = string.Empty;
    public string SynchronizationState { get; set; } = string.Empty;
}

public static class FragmentedLifeSystem
{
    public static List<FragmentedSoul> Fragments { get; } = new();

    public static void CreateFragmentedSoul(string soul, List<string> incarnations, string dominant, string state)
    {
        Fragments.Add(new FragmentedSoul
        {
            OriginalSoul = soul,
            Incarnations = incarnations,
            CurrentDominantIdentity = dominant,
            SynchronizationState = state
        });

        Console.WriteLine($"\u2728 Alma fragmentada: {soul} | Dominante: {dominant} | Estado: {state}");
    }

    public static void PrintFragments()
    {
        foreach (var f in Fragments)
            Console.WriteLine($"\n\uD83E\uDDEC {f.OriginalSoul} | Identidades: {string.Join(", ", f.Incarnations)} | Dominante: {f.CurrentDominantIdentity} | Sincronia: {f.SynchronizationState}");
    }
}

