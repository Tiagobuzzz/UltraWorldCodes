using System.Linq;

namespace UltraWorldAI.Civilization;

public static class CulturalInfluenceAnalyzer
{
    public static double CalculateInfluence(string fromRace, string toRace)
    {
        var from = RaceCultureSystem.GetForRace(fromRace);
        var to = RaceCultureSystem.GetForRace(toRace);
        if (from == null || to == null) return 0;
        double shared = from.PreferredProfessions.Intersect(to.PreferredProfessions).Count();
        double total = from.PreferredProfessions.Union(to.PreferredProfessions).Count();
        return total == 0 ? 0 : shared / total;
    }
}
