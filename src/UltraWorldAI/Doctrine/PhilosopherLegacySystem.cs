namespace UltraWorldAI.Doctrine;

public class MercantilePhilosopher
{
    public string Name { get; set; } = string.Empty;
    public string Culture { get; set; } = string.Empty;
    public string Style { get; set; } = string.Empty;
    public List<string> FoundedSchools { get; } = new();
    public List<string> DoctrinesInfluenced { get; } = new();
    public string Fate { get; set; } = string.Empty; // "Exilado", "Morto", etc.
    public string Quote { get; set; } = string.Empty;
}

public static class PhilosopherLegacySystem
{
    public static List<MercantilePhilosopher> Figures { get; } = new();

    public static MercantilePhilosopher RegisterPhilosopher(
        string name,
        string culture,
        string style,
        string fate,
        string quote)
    {
        var philosopher = new MercantilePhilosopher
        {
            Name = name,
            Culture = culture,
            Style = style,
            Fate = fate,
            Quote = quote
        };

        Figures.Add(philosopher);
        Console.WriteLine($"\uD83E\uDD20 Fil\u00f3sofo registrado: {name} ({fate})");
        return philosopher;
    }

    public static void AddSchool(string name, string school)
    {
        var p = Figures.Find(f => f.Name == name);
        p?.FoundedSchools.Add(school);
    }

    public static void AddDoctrine(string name, string doctrine)
    {
        var p = Figures.Find(f => f.Name == name);
        p?.DoctrinesInfluenced.Add(doctrine);
    }

    public static void PrintAll()
    {
        foreach (var f in Figures)
        {
            Console.WriteLine($"\n\uD83E\uDDD9 {f.Name} | Cultura: {f.Culture} | Estilo: {f.Style} | Destino: {f.Fate}");
            Console.WriteLine($"\uD83C\uDFEB Escolas fundadas: {string.Join(", ", f.FoundedSchools)}");
            Console.WriteLine($"\uD83D\uDD37 Doutrinas influenciadas: {string.Join(", ", f.DoctrinesInfluenced)}");
            Console.WriteLine($"\uD83D\uDDAC \"{f.Quote}\"");
        }
    }
}
