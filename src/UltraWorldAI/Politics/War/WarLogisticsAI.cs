using System;
using System.Collections.Generic;

namespace UltraWorldAI.Politics.War;

public class ArmyStatus
{
    public Army Army { get; set; } = new();
    public int Supplies { get; set; }
    public int Morale { get; set; }
    public string Climate { get; set; } = string.Empty;
}

public static class WarLogisticsAI
{
    public static List<ArmyStatus> Statuses { get; } = new();

    public static void UpdateStatus(Army army, string climate)
    {
        var rand = new Random();
        var status = new ArmyStatus
        {
            Army = army,
            Supplies = rand.Next(40, 100),
            Morale = rand.Next(30, 100),
            Climate = climate
        };

        if (climate == "Frio") status.Morale -= 10;
        if (climate == "Chuva") status.Supplies -= 15;
        if (climate == "Quente") status.Morale -= 5;

        Statuses.Add(status);
    }

    public static string TacticalDecision(ArmyStatus status)
    {
        if (status.Supplies < 30)
            return "Recuar para reabastecer";
        if (status.Morale < 40)
            return "Evitar combate e fortificar posição";
        if (status.Climate == "Chuva" && status.Army.Strategy == "Guerra Relâmpago")
            return "Atrasar avanço devido ao terreno encharcado";
        return "Avançar com cautela e explorar vantagem";
    }

    public static void Execute()
    {
        foreach (var s in Statuses)
        {
            var decision = TacticalDecision(s);
            Console.WriteLine($"\U0001F9E0 [Status de {s.Army.Settlement}] - Suprimentos: {s.Supplies}, Morale: {s.Morale}, Clima: {s.Climate}");
            Console.WriteLine($"\U0001F50D Decisão Tática: {decision}\n");
        }
    }
}
