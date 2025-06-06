using System;
using System.Collections.Generic;

namespace UltraWorldAI.Doctrine;

public class SubversiveAction
{
    public string OrderName = string.Empty;
    public string TargetEntity = string.Empty;
    public string ActionType = string.Empty; // "Golpe de Estado", "Assassinato Filosófico", etc.
    public int Year;
    public string Outcome = string.Empty;
}

public static class SubversiveActionSystem
{
    public static List<SubversiveAction> Actions { get; } = new();

    public static void ExecuteAction(string order, string target, string type, int year, string outcome)
    {
        Actions.Add(new SubversiveAction
        {
            OrderName = order,
            TargetEntity = target,
            ActionType = type,
            Year = year,
            Outcome = outcome
        });

        Console.WriteLine($"\u2694\uFE0F A\u00e7\u00e3o subversiva: {order} executou {type} contra {target} \u2192 {outcome} ({year})");
    }

    public static void PrintAllActions()
    {
        foreach (var a in Actions)
        {
            Console.WriteLine($"\n\uD83D\uDDFA️ {a.Year} | Ordem: {a.OrderName} | Alvo: {a.TargetEntity}");
            Console.WriteLine($"\uD83D\uDD2A A\u00e7\u00e3o: {a.ActionType} | Resultado: {a.Outcome}");
        }
    }
}
