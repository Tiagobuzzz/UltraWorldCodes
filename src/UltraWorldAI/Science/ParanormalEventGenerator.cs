using System;
using UltraWorldAI.Discovery;

namespace UltraWorldAI.Science;

public static class ParanormalEventGenerator
{
    private static readonly string[] _phenomena =
        ["Teletransporte fantasma", "Ectoplasma", "Visões místicas", "Levitação" ];

    public static DiscoveryEvent Generate(string researcher)
    {
        var name = _phenomena[Random.Shared.Next(_phenomena.Length)];
        DiscoveryHistory.Register(name, researcher, "Paranormal", "assombro", "misterio");
        return DiscoveryHistory.Log[^1];
    }
}
