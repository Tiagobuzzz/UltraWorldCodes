using System;
using System.Collections.Generic;

namespace UltraWorldAI.Language;

public class WritingLegacy
{
    public string Name { get; set; } = string.Empty;
    public int RememberedBy { get; set; }
    public bool IsExtinct => RememberedBy <= 0;
}

public static class WritingExtinctionSystem
{
    public static List<WritingLegacy> Legacies { get; } = new();

    public static void Remember(string name)
    {
        var record = Legacies.Find(l => l.Name == name);
        if (record == null)
        {
            record = new WritingLegacy { Name = name };
            Legacies.Add(record);
        }
        record.RememberedBy++;
    }

    public static void Forget(string name)
    {
        var record = Legacies.Find(l => l.Name == name);
        if (record == null) return;
        record.RememberedBy--;
        if (record.IsExtinct)
            Console.WriteLine($"\uD83D\uDC80 Legado da escrita {name} morreu.");
    }

    public static void Restore(string name, int people)
    {
        var record = Legacies.Find(l => l.Name == name);
        if (record == null)
        {
            record = new WritingLegacy { Name = name };
            Legacies.Add(record);
        }
        record.RememberedBy = people;
        Console.WriteLine($"\u2728 Escrita {name} restaurada.");
    }
}
