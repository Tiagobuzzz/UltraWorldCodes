using UltraWorldAI.Civilization;

namespace UltraWorldAI.Diplomacy;

/// <summary>
/// Simple negotiation helper for treaties.
/// </summary>
public static class NegotiationAI
{
    public static string ProposeTreaty(SapientBeing a, SapientBeing b, string terms)
    {
        return $"{a.Name} propõe a {b.Name}: {terms}";
    }
}
