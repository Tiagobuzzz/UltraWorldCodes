using System;
using System.Collections.Generic;

namespace UltraWorldAI.Magic;

public class DimensionalPrison
{
    public string Name = string.Empty;
    public string Realm = string.Empty; // Plano onde está localizada
    public string Purpose = string.Empty; // "Conter um deus", "Isolar uma maldição", "Aprisionar tempo"
    public string SeloVivo = string.Empty; // Nome da entidade ou runa viva que mantém a prisão ativa
    public bool IsBreaking;
}

public static class DimensionalPrisonSystem
{
    public static List<DimensionalPrison> Prisons { get; } = new();

    public static void CreatePrison(string name, string realm, string purpose, string seloVivo, bool breaking)
    {
        Prisons.Add(new DimensionalPrison
        {
            Name = name,
            Realm = realm,
            Purpose = purpose,
            SeloVivo = seloVivo,
            IsBreaking = breaking
        });

        Console.WriteLine($"\uD83D\uDD12 Pris\u00E3o dimensional: {name} | Plano: {realm} | Prop\u00F3sito: {purpose} | Selo vivo: {seloVivo} | Quebrando: {breaking}");
    }

    public static void PrintPrisons()
    {
        foreach (var p in Prisons)
        {
            var status = p.IsBreaking ? "RUINDO" : "Est\u00E1vel";
            Console.WriteLine($"\n\uD83D\uDD73\uFE0F {p.Name} | Plano: {p.Realm} | Selo: {p.SeloVivo} | Finalidade: {p.Purpose} | Estabilidade: {status}");
        }
    }
}
