using System;
using System.Collections.Generic;

namespace UltraWorldAI.Knowledge;

public class KnowledgeCenter
{
    public string Name = string.Empty;
    public string Type = string.Empty; // "Universidade", "Templo do Saber"
    public List<string> StoredTopics = new();
    public string Doctrine = string.Empty; // "Lógica", "Tradição oral"
    public List<string> Gatekeepers = new();
}

public static class KnowledgeCenterSystem
{
    public static List<KnowledgeCenter> Centers { get; } = new();

    public static void CreateCenter(
        string name,
        string type,
        string doctrine,
        List<string> keepers)
    {
        Centers.Add(new KnowledgeCenter
        {
            Name = name,
            Type = type,
            Doctrine = doctrine,
            Gatekeepers = keepers
        });

        Console.WriteLine($"\uD83C\uDFDB\uFE0F {type} criada: {name} | Doutrina: {doctrine} | Guardi\u00f5es: {string.Join(", ", keepers)}");
    }

    public static void StoreKnowledge(string centerName, string topic)
    {
        var center = Centers.Find(x => x.Name == centerName);
        if (center != null)
        {
            center.StoredTopics.Add(topic);
            Console.WriteLine($"\uD83D\uDCD6 Conhecimento '{topic}' armazenado em {centerName}");
        }
    }
}
