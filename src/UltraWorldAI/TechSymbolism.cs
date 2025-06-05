using System.Collections.Generic;

namespace UltraWorldAI.Discovery;

public class TechSymbolicStatus
{
    public string TechName { get; set; } = string.Empty;
    public string SymbolicForm { get; set; } = string.Empty;
    public string AdoptedByCulture { get; set; } = string.Empty;
}

public static class TechSymbolism
{
    public static List<TechSymbolicStatus> Codified { get; } = new();

    public static void Codify(string techName, string form, string culture)
    {
        Codified.Add(new TechSymbolicStatus
        {
            TechName = techName,
            SymbolicForm = form,
            AdoptedByCulture = culture
        });
    }

    public static string ListAll()
    {
        if (Codified.Count == 0) return "Nenhuma tecnologia foi codificada culturalmente.";
        return string.Join("\n\n", Codified.ConvertAll(t =>
            $"\uD83D\uDCD8 {t.TechName} virou {t.SymbolicForm} na cultura {t.AdoptedByCulture}"));
    }
}
