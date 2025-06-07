using System;
using System.Collections.Generic;

namespace UltraWorldAI.Module13;

public class BodyMod
{
    public string Name = string.Empty;
    public string Type = string.Empty; // "Implante", "Mutacao", "Transfiguracao", "Runas"
    public string Benefit = string.Empty; // "Visao noturna", "Pele de ferro"
    public string OriginCulture = string.Empty;
    public bool IsReversible;
}

public static class BodyModificationSystem
{
    public static List<BodyMod> Modifications { get; } = new();

    public static void AddModification(string name, string type, string benefit, string origin, bool reversible)
    {
        Modifications.Add(new BodyMod
        {
            Name = name,
            Type = type,
            Benefit = benefit,
            OriginCulture = origin,
            IsReversible = reversible
        });

        Console.WriteLine($"\uD83E\uDDE4 Modifica\u00e7\u00e3o: {name} | Tipo: {type} | Benef\u00edcio: {benefit} | Origem: {origin} | Revers\u00edvel: {reversible}");
    }

    public static void PrintMods()
    {
        foreach (var m in Modifications)
            Console.WriteLine($"\uD83D\uDD27 {m.Name} | {m.Type} \u2192 {m.Benefit} | Cultura: {m.OriginCulture} | Revers\u00edvel: {m.IsReversible}");
    }
}
