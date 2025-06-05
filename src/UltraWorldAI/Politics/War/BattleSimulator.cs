using System;
using UltraWorldAI.World;

namespace UltraWorldAI.Politics.War;

public static class BattleSimulator
{
    public static void Resolve(War war)
    {
        var attacker = ArmyMobilizer.Armies.Find(a => a.Settlement == war.Attacker);
        var defender = ArmyMobilizer.Armies.Find(a => a.Settlement == war.Defender);

        if (attacker == null || defender == null) return;

        double powerA = attacker.Size * GetMultiplier(attacker.Strategy);
        double powerB = defender.Size * GetMultiplier(defender.Strategy);

        string result;
        if (powerA > powerB)
        {
            result = $"{war.Attacker} venceu a guerra contra {war.Defender}.";
            var defeated = RaceSettlementDistributor.Settlements.Find(s => s.Name == war.Defender);
            if (defeated != null) defeated.Population /= 2;
        }
        else
        {
            result = $"{war.Defender} resistiu e venceu a guerra.";
            var attackerSettle = RaceSettlementDistributor.Settlements.Find(s => s.Name == war.Attacker);
            if (attackerSettle != null) attackerSettle.Population /= 2;
        }

        war.IsOngoing = false;
        SettlementHistoryTracker.Register(war.Attacker, "Resultado de Guerra", result);
        SettlementHistoryTracker.Register(war.Defender, "Resultado de Guerra", result);
    }

    private static double GetMultiplier(string strategy)
    {
        return strategy switch
        {
            "Ataque Total" => 1.2,
            "Cerco Prolongado" => 1.1,
            "Retaliação Tática" => 1.05,
            "Guerra Relâmpago" => 0.95,
            _ => 1.0
        };
    }
}
