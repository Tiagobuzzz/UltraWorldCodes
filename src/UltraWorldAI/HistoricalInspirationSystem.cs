using System;
using System.Collections.Generic;

namespace UltraWorldAI;

public static class HistoricalInspirationSystem
{
    private static readonly List<string> _events = new()
    {
        "A queda do Império Romano",
        "A descoberta do Brasil",
        "A Revolução Francesa",
        "A expedição de Magalhães"
    };

    private static readonly Random _rand = new();

    public static string GetRandomEvent() => _events[_rand.Next(_events.Count)];
}
