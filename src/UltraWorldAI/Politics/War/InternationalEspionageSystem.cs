using System;
using UltraWorldAI.World;

namespace UltraWorldAI.Politics.War;

public record EspionageReport(string Origin, string Target, string Operation, double Risk, bool Success);

/// <summary>
/// Extension of the EspionageSystem with a simple risk calculation.
/// </summary>
public static class InternationalEspionageSystem
{
    private static readonly string[] Types = { "Sabotagem", "Infiltração", "Suborno" };

    public static EspionageReport Run(Settlement origin, Settlement target, double skill)
    {
        string op = Types[Random.Shared.Next(Types.Length)];
        double baseRisk = 0.2 + Math.Clamp((target.Population - origin.Population) / 1000.0, -0.1, 0.5);
        double risk = Math.Clamp(baseRisk * (1 - skill), 0, 1);
        bool success = Random.Shared.NextDouble() > risk;
        SettlementHistoryTracker.Register(origin.Name, "Espionagem Internacional",
            success ? $"{op} bem-sucedida" : $"{op} fracassou");
        return new EspionageReport(origin.Name, target.Name, op, risk, success);
    }
}
