using System;
using System.Collections.Generic;

namespace UltraWorldAI.Politics.War;

public class WarDeclaration
{
    public string Aggressor { get; set; } = string.Empty;
    public string Defender { get; set; } = string.Empty;
    public string Reason { get; set; } = string.Empty;
    public DateTime Date { get; set; }
}

public static class WarDeclarationSystem
{
    public static List<WarDeclaration> Declarations { get; } = new();

    public static void DeclareWar(string aggressor, string defender, string reason)
    {
        var decl = new WarDeclaration
        {
            Aggressor = aggressor,
            Defender = defender,
            Reason = reason,
            Date = DateTime.Now
        };
        Declarations.Add(decl);
    }
}
