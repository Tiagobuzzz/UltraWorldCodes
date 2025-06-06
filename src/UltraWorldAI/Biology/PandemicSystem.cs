using System.Collections.Generic;

namespace UltraWorldAI.Biology;

public class Infection
{
    public string Region { get; set; } = string.Empty;
    public int Cases { get; set; }
}

public static class PandemicSystem
{
    private static readonly List<Infection> _infections = new();

    public static void Spread(string region, int cases)
    {
        var inf = _infections.Find(i => i.Region == region);
        if (inf == null)
        {
            inf = new Infection { Region = region, Cases = cases };
            _infections.Add(inf);
        }
        else
        {
            inf.Cases += cases;
        }
    }

    public static List<Infection> GetInfections() => new(_infections);
}
