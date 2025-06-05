using System.Collections.Generic;

namespace UltraWorldAI.Territory;

public static class SacredSpace
{
    private static readonly HashSet<string> _sacredRegions = new();

    public static void SanctifyRegion(string regionName)
    {
        if (!_sacredRegions.Contains(regionName))
            _sacredRegions.Add(regionName);
    }

    public static bool IsSacred(string regionName)
    {
        return _sacredRegions.Contains(regionName);
    }

    public static string DescribeSacred()
    {
        if (_sacredRegions.Count == 0)
            return "Nenhuma região é sagrada ainda.";

        return $"Regiões sagradas: {string.Join(", ", _sacredRegions)}";
    }

    public static void InfluenceMind(Mind mind, string regionName)
    {
        if (!IsSacred(regionName))
            return;

        mind.IdeaEngine.GenerateIdea(
            $"Lugar Sagrado: {regionName}",
            new() { regionName },
            0.9f,
            0.95f);

        mind.Stress.ReduceStress(0.1f);
    }
}
