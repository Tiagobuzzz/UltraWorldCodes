using System;
using System.Collections.Generic;
using UltraWorldAI.World;

namespace UltraWorldAI.Politics.War;

public class EspionageOperation
{
    public string Origin { get; set; } = string.Empty;
    public string Target { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty; // Sabotagem, Infiltração, Suborno
    public string Result { get; set; } = string.Empty;
}

public static class EspionageSystem
{
    public static List<EspionageOperation> Ops { get; } = new();

    public static void RunEspionage(Settlement origin, Settlement target)
    {
        var rand = new Random();
        string type = rand.NextDouble() switch
        {
            < 0.33 => "Sabotagem",
            < 0.66 => "Infiltração",
            _ => "Suborno"
        };

        string result = Execute(type, target);
        Ops.Add(new EspionageOperation
        {
            Origin = origin.Name,
            Target = target.Name,
            Type = type,
            Result = result
        });

        SettlementHistoryTracker.Register(origin.Name, "Espionagem", $"{type} contra {target.Name}: {result}");
    }

    private static string Execute(string type, Settlement target)
    {
        var rand = new Random().NextDouble();
        return type switch
        {
            "Sabotagem" => rand < 0.5 ? "Incêndio nos grãos, perda de recursos" : "Tentativa falhou",
            "Infiltração" => rand < 0.4 ? "Ideologia infiltrada na população" : "Descoberto e expulso",
            "Suborno" => rand < 0.3 ? "Líderes locais comprados" : "Rejeição total",
            _ => "Erro"
        };
    }
}
