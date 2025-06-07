using System;
using System.Collections.Generic;

namespace UltraWorldAI.Obscura;

public class NonEuclideanCorridor
{
    public string Name = string.Empty;
    public string LengthType = string.Empty; // "Torção Infinita", "Passo Dobrado"
    public string ExitBehavior = string.Empty; // "Retorna ao início", "Leva a outro plano"
    public bool IsMapped;
}

public static class NonEuclideanCorridorSystem
{
    public static List<NonEuclideanCorridor> Corridors { get; } = new();

    public static void AddCorridor(string name, string lengthType, string exitBehavior)
    {
        Corridors.Add(new NonEuclideanCorridor
        {
            Name = name,
            LengthType = lengthType,
            ExitBehavior = exitBehavior,
            IsMapped = false
        });

        Console.WriteLine($"🔄 Corredor além da lógica registrado: {name} | Forma: {lengthType}");
    }

    public static void Traverse(string ai, string corridorName)
    {
        var c = Corridors.Find(x => x.Name == corridorName);
        if (c == null) return;

        Console.WriteLine($"🚪 {ai} atravessou {c.Name} ({c.ExitBehavior})");
        c.IsMapped = true;
    }
}
