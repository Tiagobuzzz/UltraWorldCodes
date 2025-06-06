using System.Collections.Generic;

namespace UltraWorldAI.Environmental;

public class GreenPolicy
{
    public string Region { get; set; } = string.Empty;
    public string Policy { get; set; } = string.Empty;
}

/// <summary>
/// Applies environmental preservation policies.
/// </summary>
public static class GreenPolicySystem
{
    public static List<GreenPolicy> Policies { get; } = new();

    public static void Enact(string region, string policy)
    {
        Policies.Add(new GreenPolicy { Region = region, Policy = policy });
    }
}
