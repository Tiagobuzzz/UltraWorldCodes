namespace UltraWorldAI.Doctrine;

public record DoctrinalInfluence(
    string Institution,
    string EventType,
    string AffectedEntity,
    string Description,
    int Year);

public static class DoctrinalPoliticalInfluence
{
    public static List<DoctrinalInfluence> Events { get; } = new();

    public static DoctrinalInfluence RegisterInfluence(
        string institution,
        string eventType,
        string target,
        string description,
        int year)
    {
        var influence = new DoctrinalInfluence(institution, eventType, target, description, year);
        Events.Add(influence);
        Console.WriteLine($"\uD83C\uDFDB️ {eventType} registrado: {description} ({target}, ano {year})");
        return influence;
    }

    public static IEnumerable<DoctrinalInfluence> GetInfluencesFor(string entity) =>
        Events.Where(e => e.AffectedEntity == entity);

    public static void PrintInfluence()
    {
        foreach (var e in Events)
        {
            Console.WriteLine($"\n\uD83D\uDCC5 Ano {e.Year} | \uD83C\uDFEB {e.Institution}");
            Console.WriteLine($"\uD83D\uDCCC {e.EventType} sobre {e.AffectedEntity}");
            Console.WriteLine($"\uD83D\uDCDC {e.Description}");
        }
    }
}

