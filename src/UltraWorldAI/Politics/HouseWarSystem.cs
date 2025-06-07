namespace UltraWorldAI.Politics;

public class HouseWar
{
    public string HouseA { get; set; } = string.Empty;
    public string HouseB { get; set; } = string.Empty;
    public string Cause { get; set; } = string.Empty;
    public bool IsResolved { get; set; }
    public string Winner { get; set; } = string.Empty;
}

public static class HouseWarSystem
{
    public static List<HouseWar> Wars { get; } = new();

    public static void DeclareWar(string a, string b, string cause)
    {
        Wars.Add(new HouseWar { HouseA = a, HouseB = b, Cause = cause });
        Console.WriteLine($"💥 Guerra declarada entre {a} e {b} | Motivo: {cause}");
    }

    public static void ResolveWar(HouseWar war, string winner)
    {
        if (war == null || war.IsResolved) return;
        war.IsResolved = true;
        war.Winner = winner;
        Console.WriteLine($"☮️ Guerra entre {war.HouseA} e {war.HouseB} resolvida. Vencedor: {winner}");
    }
}
