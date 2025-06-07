using System;
using System.Collections.Generic;

namespace UltraWorldAI.Knowledge;

public class KnowledgeItem
{
    public string Topic = string.Empty;
    public string Status = string.Empty; // "Aceito", "Contestado", "Censurado"
    public string Source = string.Empty; // "Tradi\u00e7\u00e3o", "Descoberta"
    public List<string> OpposingGroups = new();
}

public static class KnowledgeEvolutionSystem
{
    public static List<KnowledgeItem> KnowledgeBase { get; } = new();

    public static void RegisterKnowledge(
        string topic,
        string status,
        string source,
        List<string> opposition)
    {
        KnowledgeBase.Add(new KnowledgeItem
        {
            Topic = topic,
            Status = status,
            Source = source,
            OpposingGroups = opposition
        });

        Console.WriteLine($"\uD83E\uDDE0 Conhecimento '{topic}' registrado | Status: {status} | Fonte: {source}");
        if (opposition.Count > 0)
            Console.WriteLine($"\u26D4\uFE0F Oposto por: {string.Join(", ", opposition)}");
    }
}
