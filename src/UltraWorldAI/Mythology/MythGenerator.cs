using System;

namespace UltraWorldAI.Mythology;

/// <summary>
/// Generates short procedural legends and myths.
/// </summary>
public static class MythGenerator
{
    private static readonly string[] Heroes = { "Arion", "Belthar", "Celes", "Darian", "Eldric" };
    private static readonly string[] Creatures =
        { "drag\u00e3o", "esp\u00edrito ancestral", "tit\u00e3 do fogo", "ser da floresta", "deus esquecido" };
    private static readonly string[] Quests =
        { "buscou a chama eterna", "desafiou a f\u00faria do mar", "selou o portal proibido", "traiu os pr\u00f3prios irm\u00e3os", "encontrou a fonte da vida" };

    public static string GenerateLegend()
    {
        var hero = Heroes[RandomSingleton.Shared.Next(Heroes.Length)];
        var creature = Creatures[RandomSingleton.Shared.Next(Creatures.Length)];
        var quest = Quests[RandomSingleton.Shared.Next(Quests.Length)];
        return $"\uD83D\uDCDC Lenda de {hero}, que enfrentou um {creature} e {quest}.";
    }
}
