using System;

namespace UltraWorldAI.Politics;

public static class IntergalacticDiplomacyAI
{
    public static DiplomaticRelation Evaluate(string factionA, int powerA, string factionB, int powerB)
    {
        int diff = Math.Abs(powerA - powerB);
        if (diff < 10) return DiplomaticRelation.Aliança;
        return powerA > powerB ? DiplomaticRelation.Desconfiança : DiplomaticRelation.Guerra;
    }
}
