namespace UltraWorldAI.Doctrine;

public class HybridDoctrine
{
    public string Name { get; set; } = string.Empty;
    public string Symbol { get; set; } = string.Empty;
    public string EconomicOrigin { get; set; } = string.Empty;
    public string PhilosophicalOrigin { get; set; } = string.Empty;
    public List<string> Tenets { get; set; } = new();
    public List<string> Practices { get; set; } = new();
    public string SocialReaction { get; set; } = string.Empty; // "Cultuada", "Censurada" etc.
}

public static class HybridDoctrineSystem
{
    public static List<HybridDoctrine> Doctrines { get; } = new();

    public static HybridDoctrine CreateDoctrine(
        string name,
        string symbol,
        string econOrigin,
        string philoOrigin,
        IEnumerable<string> tenets,
        IEnumerable<string> practices,
        string reaction)
    {
        var doctrine = new HybridDoctrine
        {
            Name = name,
            Symbol = symbol,
            EconomicOrigin = econOrigin,
            PhilosophicalOrigin = philoOrigin,
            Tenets = new List<string>(tenets),
            Practices = new List<string>(practices),
            SocialReaction = reaction
        };

        Doctrines.Add(doctrine);
        Console.WriteLine($"\uD83D\uDD37 Doutrina criada: {name} ({reaction})");
        return doctrine;
    }

    public static void PrintAll()
    {
        foreach (var d in Doctrines)
        {
            Console.WriteLine($"\n\uD83D\uDD39 {d.Name} [{d.Symbol}]");
            Console.WriteLine($"\uD83D\uDCDC Origem: {d.EconomicOrigin} + {d.PhilosophicalOrigin}");
            Console.WriteLine($"\uD83D\uDCD6 Princ\u00edpios: {string.Join(", ", d.Tenets)}");
            Console.WriteLine($"\uD83D\uDD4B Pr\u00e1ticas: {string.Join(", ", d.Practices)}");
            Console.WriteLine($"\u2696\uFE0F Status social: {d.SocialReaction}");
        }
    }
}
