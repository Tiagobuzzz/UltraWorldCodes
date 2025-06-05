using System;
using UltraWorldAI.Religion;
using UltraWorldAI.World;

namespace UltraWorldAI.Politics.War;

public static class BeliefDrivenWarfare
{
    public static void EvaluateBeliefConflict(Settlement a, Settlement b)
    {
        var beliefA = CultureBeliefSystem.GetBelief(a.Race);
        var beliefB = CultureBeliefSystem.GetBelief(b.Race);
        if (beliefA == beliefB) return;

        var cause = (beliefA, beliefB) switch
        {
            ("Purificação", _) => "Guerra Santa",
            ("Expansão", _) => "Dominação Filosófica",
            ("Equilíbrio", "Caos") => "Correção Cósmica",
            ("Caos", "Ordem") => "Conflito Existencial",
            (_, "Paz") => "Ataque contra pacifistas",
            _ => "Divergência Dogmática"
        };

        if (new Random().NextDouble() < 0.2)
        {
            WarConflictSystem.ActiveWars.Add(new War
            {
                Attacker = a.Name,
                Defender = b.Name,
                Reason = cause,
                StartDate = DateTime.Now
            });

            SettlementHistoryTracker.Register(a.Name, "Guerra por Crença", $"Atacou {b.Name} por: {cause}");
        }
    }
}
