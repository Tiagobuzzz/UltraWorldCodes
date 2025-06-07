using System;
using System.Collections.Generic;

namespace UltraWorldAI.Politics;

public class HistoricalManipulation
{
    public string Record { get; set; } = string.Empty;
    public string Source { get; set; } = string.Empty;
    public string Action { get; set; } = string.Empty; // "ForgeTreaty", "RewriteHistory"
    public string Intent { get; set; } = string.Empty;
    public bool Success { get; set; }
}

public static class HistoricalManipulationSystem
{
    public static List<HistoricalManipulation> Actions { get; } = new();

    public static void ForgeTreaty(string title, string issuer, string intent)
    {
        Actions.Add(new HistoricalManipulation
        {
            Record = title,
            Source = issuer,
            Action = "ForgeTreaty",
            Intent = intent,
            Success = true
        });

        RoyalDocumentSystem.IssueDocument(title, issuer, "Tratado", $"Intento: {intent}", true);
    }

    public static void RewriteHistory(string eventName, string actor, string intent, bool success)
    {
        Actions.Add(new HistoricalManipulation
        {
            Record = eventName,
            Source = actor,
            Action = "RewriteHistory",
            Intent = intent,
            Success = success
        });

        var result = success ? "alterado" : "exposto";
        Console.WriteLine($"\uD83D\uDCDD Evento '{eventName}' {result} por {actor} (Motivo: {intent})");
    }
}
