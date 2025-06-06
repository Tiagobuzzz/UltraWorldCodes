using System;
using System.Collections.Generic;

namespace UltraWorldAI.Language;

public class MagicContract
{
    public string Author { get; set; } = string.Empty; // IA or entity
    public string Type { get; set; } = string.Empty; // "Contrato", "Selo", "Pacto"
    public string Effect { get; set; } = string.Empty;
    public bool IsActive { get; set; }
}

public static class MagicalContractSystem
{
    public static List<MagicContract> Contracts { get; } = new();

    public static void CreateContract(string author, string type, string effect)
    {
        Contracts.Add(new MagicContract
        {
            Author = author,
            Type = type,
            Effect = effect
        });
        Console.WriteLine($"\uD83C\uDFAD {author} criou {type} com efeito '{effect}'");
    }

    public static void Activate(string type)
    {
        var c = Contracts.Find(c => c.Type == type);
        if (c == null) return;
        c.IsActive = true;
        Console.WriteLine($"\u2728 {type} ativado: {c.Effect}");
    }

    public static void PrintContracts()
    {
        foreach (var c in Contracts)
        {
            Console.WriteLine($"\n\uD83D\uDDDD\uFE0F {c.Type} | Autor: {c.Author} | Ativo: {c.IsActive} | Efeito: {c.Effect}");
        }
    }
}
