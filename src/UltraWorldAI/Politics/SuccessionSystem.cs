using System;
using System.Collections.Generic;

namespace UltraWorldAI.Politics;

public static class SuccessionSystem
{
    public static string DetermineSuccessor(PowerStructure gov, List<Person> candidates, string currentBloodline = "")
    {
        return gov.BaseOfPower switch
        {
            AuthorityBase.Sangue => FindHeirByBloodline(currentBloodline, candidates),
            AuthorityBase.Fe => ChooseByDivineSign(candidates),
            AuthorityBase.Sabedoria => ChooseByWisdom(candidates),
            AuthorityBase.Voto => SimulateVote(candidates),
            _ => candidates.Count > 0 ? candidates[0].Name : "Vazio de Poder"
        };
    }

    public static string FindHeirByBloodline(string currentBloodline, List<Person> candidates)
    {
        foreach (var c in candidates)
        {
            if (c.Bloodline == currentBloodline)
                return c.Name;
        }

        return "Sem herdeiro legítimo";
    }

    private static string ChooseByDivineSign(List<Person> candidates)
    {
        if (candidates.Count == 0) return "Silêncio Divino";
        var index = RandomSingleton.Shared.Next(candidates.Count);
        return $"{candidates[index].Name} (escolhido em sonho)";
    }

    private static string ChooseByWisdom(List<Person> candidates)
    {
        return candidates.Count > 1 ? candidates[^1].Name : candidates[0].Name;
    }

    private static string SimulateVote(List<Person> candidates)
    {
        return candidates.Count > 0 ? candidates[RandomSingleton.Shared.Next(candidates.Count)].Name : "Voto nulo";
    }

    public static void ApplySuccessor(PowerStructure gov, string newLeader)
    {
        gov.CurrentLeader = newLeader;
        gov.IsStable = newLeader != "Vazio de Poder" && !newLeader.Contains("Silêncio");
    }
}
