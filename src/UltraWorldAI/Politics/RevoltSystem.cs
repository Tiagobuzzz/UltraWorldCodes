using System;
using System.Collections.Generic;
using UltraWorldAI;

namespace UltraWorldAI.Politics;

public static class RevoltSystem
{
    public static bool CheckForRevolt(PowerStructure gov, float culturalTension, float economicStress, float religiousDisorder)
    {
        float revoltChance = (culturalTension + economicStress + religiousDisorder) / 3f;
        return revoltChance >= 0.7f;
    }

    public static string TriggerRevolt(PowerStructure gov, string rebelLeader)
    {
        string oldLeader = gov.CurrentLeader;
        gov.CurrentLeader = rebelLeader;
        gov.IsStable = false;
        gov.Laws.Add("Novo líder chegou pela revolta.");
        gov.SymbolsOfPower.Add("Estandarte rasgado como prova de ruptura");
        return $"⚔️ Revolta bem-sucedida: {rebelLeader} derrubou {oldLeader}. Novo governo instaurado.";
    }

    public static string SimulateFailedRevolt(string leader)
    {
        return $"A tentativa de revolta contra {leader} falhou. Rebeldes caíram ou foram silenciados.";
    }

    public static string? TriggerCivilUnrest(PowerStructure gov, List<Person> population, string rebelLeader)
    {
        if (population.Count == 0) return null;
        float avg = 0f;
        foreach (var p in population)
            avg += p.Mind.Stress.CurrentStressLevel;
        avg /= population.Count;
        if (avg < 0.8f) return null;
        return TriggerRevolt(gov, rebelLeader);
    }
}
