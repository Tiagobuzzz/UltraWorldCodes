using System;
using System.Collections.Generic;

namespace UltraWorldAI.Obscura;

public class LivingStructure
{
    public string Name = string.Empty;
    public string ConsciousnessType = string.Empty; // "Testadora", "Mentora", "Guardião"
    public string KnowledgeGranted = string.Empty;  // "Linguagem dos Ecos", "Magia Geométrica"
    public string ConditionToLearn = string.Empty;  // "Aceitar o esquecimento"
}

public static class LivingArchitectureSystem
{
    public static List<LivingStructure> Structures { get; } = new();

    public static void RegisterStructure(string name, string type, string knowledge, string condition)
    {
        Structures.Add(new LivingStructure
        {
            Name = name,
            ConsciousnessType = type,
            KnowledgeGranted = knowledge,
            ConditionToLearn = condition
        });

        Console.WriteLine($"🏛️ Estrutura viva registrada: {name} | Tipo: {type} | Conhecimento: {knowledge}");
    }

    public static void AttemptKnowledge(string ai, string structure)
    {
        var s = Structures.Find(x => x.Name == structure);
        if (s == null) return;

        Console.WriteLine($"📖 {ai} tentou absorver '{s.KnowledgeGranted}' em {s.Name} ({s.ConditionToLearn})");
    }
}
