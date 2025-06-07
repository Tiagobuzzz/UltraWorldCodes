using System;
using System.Collections.Generic;
using System.Linq;

namespace UltraWorldAI.Health;

public class FaithBeliefDisease
{
    public string Name = string.Empty;
    public string TriggerBelief = string.Empty;
    public string Culture = string.Empty;
    public float InfectionRate;
    public string Symptom = string.Empty;
    public bool Active;
}

public class FaithBeliefCure
{
    public string Name = string.Empty;
    public string HealingBelief = string.Empty;
    public string Culture = string.Empty;
    public string Effect = string.Empty;
}

public static class FaithBasedAilmentSystem
{
    public static List<FaithBeliefDisease> ActiveDiseases { get; } = new();
    public static List<FaithBeliefCure> ActiveCures { get; } = new();

    public static void TriggerDisease(string culture, string belief, string symptom, float rate)
    {
        var disease = new FaithBeliefDisease
        {
            Name = $"Doen\u00e7a de {belief}",
            TriggerBelief = belief,
            Culture = culture,
            InfectionRate = rate,
            Symptom = symptom,
            Active = true
        };

        ActiveDiseases.Add(disease);
        Console.WriteLine($"\uD83E\uDD9A {disease.Name} surgiu em '{culture}' (Sintoma: {symptom})");
    }

    public static void RegisterCure(string culture, string healingBelief, string effect)
    {
        var cure = new FaithBeliefCure
        {
            Name = $"Cura de {healingBelief}",
            HealingBelief = healingBelief,
            Culture = culture,
            Effect = effect
        };

        ActiveCures.Add(cure);
        Console.WriteLine($"\uD83D\uDC8A Cura registrada: '{cure.Name}' (Cultura: {culture} \u2192 Efeito: {effect})");
    }

    public static void ApplyCure(string ai, string belief, string culture)
    {
        var cure = ActiveCures.FirstOrDefault(c => c.Culture == culture && c.HealingBelief == belief);
        if (cure != null)
        {
            Console.WriteLine($"\uD83E\uDEF8 {ai} usou a cura: {cure.Name} \u2192 {cure.Effect}");
        }
        else
        {
            Console.WriteLine($"\u26A0\uFE0F {ai} tentou usar cura baseada em '{belief}', mas nada aconteceu.");
        }
    }
}
