using System;
using System.Collections.Generic;

namespace UltraWorldAI.Knowledge;

public class KnowledgeCell
{
    public string Name = string.Empty;
    public string BaseLocation = string.Empty;
    public List<string> ForbiddenTopics = new();
    public List<string> Members = new();
}

public static class SecretKnowledgeNetworkSystem
{
    public static List<KnowledgeCell> Cells { get; } = new();

    public static void CreateCell(
        string name,
        string baseLocation,
        IEnumerable<string> topics)
    {
        var cell = new KnowledgeCell
        {
            Name = name,
            BaseLocation = baseLocation,
            ForbiddenTopics = new List<string>(topics)
        };
        Cells.Add(cell);
        Console.WriteLine($"\uD83D\uDD75\uFE0F C\u00e9lula criada: {name} em {baseLocation}");
    }

    public static void AddMember(string cellName, string member)
    {
        var cell = Cells.Find(c => c.Name == cellName);
        if (cell != null && !cell.Members.Contains(member))
            cell.Members.Add(member);
    }
}
