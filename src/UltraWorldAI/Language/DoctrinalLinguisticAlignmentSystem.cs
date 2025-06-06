using System;
using System.Collections.Generic;

namespace UltraWorldAI.Language;

public class LinguisticDoctrine
{
    public string CultName { get; set; } = string.Empty;
    public string Language { get; set; } = string.Empty;
    public string DoctrineName { get; set; } = string.Empty;
    public bool IsHeretical { get; set; }
    public string Stance { get; set; } = string.Empty; // "Reforma", "Resistência", "Dogma", "Cisma"
}

public static class DoctrinalLinguisticAlignmentSystem
{
    public static readonly List<LinguisticDoctrine> Doctrines = new();

    public static void RegisterDoctrine(string cult, string language, string doctrine, bool heresy, string stance)
    {
        Doctrines.Add(new LinguisticDoctrine
        {
            CultName = cult,
            Language = language,
            DoctrineName = doctrine,
            IsHeretical = heresy,
            Stance = stance
        });

        Console.WriteLine($"\uD83D\uDCD6 Doutrina lingu\u00edstica registrada: {doctrine} (Culto: {cult}, L\u00edngua: {language}) \u2014 Heresia? {heresy} | Posi\u00e7\u00e3o: {stance}");
    }

    public static void PrintAll()
    {
        foreach (var d in Doctrines)
        {
            Console.WriteLine($"\n\u26EA {d.DoctrineName} | Culto: {d.CultName} | L\u00edngua: {d.Language}");
            Console.WriteLine($"\uD83D\uDD25 Heresia? {d.IsHeretical} | Posi\u00e7\u00e3o: {d.Stance}");
        }
    }
}
