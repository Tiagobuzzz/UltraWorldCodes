using System;
using UltraWorldAI.Civilization;
using UltraWorldAI.Religion;
using UltraWorldAI.World;

namespace UltraWorldAI.Politics.War;

public static class ContextAwareWarAI
{
    public static string EvaluateIntent(SapientBeing ia, Settlement target)
    {
        string reason = string.Empty;

        var beingCulture = RaceCultureSystem.GetForRace(ia.Race)?.SocialStructure;
        if (beingCulture != null && beingCulture == target.CultureSummary)
            return "⚖️ Neutralidade – Mesma Cultura";

        var beliefA = CultureBeliefSystem.GetBelief(ia.Race);
        var beliefB = CultureBeliefSystem.GetBelief(target.Race);
        if (beliefA == beliefB)
            reason = "Tensão não-violenta – Divergência interpretativa";

        if (ia.CurrentRegion == target.Region)
            reason = "🗺️ Conflito Territorial";

        var history = SettlementHistoryTracker.GetRelation(ia.CurrentRegion, target.Name);
        if (history.Contains("aliança", StringComparison.OrdinalIgnoreCase))
            reason = "🤝 Trégua Honrada";
        if (history.Contains("traição", StringComparison.OrdinalIgnoreCase))
            reason = "🔥 Revanche Histórica";

        var rand = new Random();
        if (reason.Contains("Revanche") || reason.Contains("Territorial"))
            return rand.NextDouble() < 0.6 ? "⚔️ Guerra Justificada – " + reason : "🔍 Espionagem antes de atacar";

        if (reason.Contains("Trégua") || reason.Contains("Neutralidade"))
            return "💬 Diplomacia preferida – " + reason;

        return "😐 Observação estratégica – Nenhum motivo forte";
    }
}
