using System;
using System.Collections.Generic;

namespace UltraWorldAI.Politics;

public class HiddenTitle
{
    public string Title { get; set; } = string.Empty;
    public string Holder { get; set; } = string.Empty;
    public string ConditionToReveal { get; set; } = string.Empty; // "Profecia", "Relíquia", "Conquista", etc.
    public bool IsRevealed { get; set; }
}

public static class HiddenTitleSystem
{
    public static List<HiddenTitle> HiddenTitles { get; } = new();

    public static void GrantHiddenTitle(string title, string holder, string condition)
    {
        HiddenTitles.Add(new HiddenTitle
        {
            Title = title,
            Holder = holder,
            ConditionToReveal = condition,
            IsRevealed = false
        });

        Console.WriteLine($"🕯️ Título oculto '{title}' concedido a {holder}. Condição: {condition}");
    }

    public static void RevealTitle(string holder)
    {
        foreach (var t in HiddenTitles)
        {
            if (t.Holder == holder && !t.IsRevealed)
            {
                t.IsRevealed = true;
                Console.WriteLine($"👑 Título oculto revelado: {t.Title} por {holder}!");
            }
        }
    }

    public static void PrintHiddenTitles()
    {
        foreach (var t in HiddenTitles)
            Console.WriteLine($"\n🏷️ {t.Holder} | Título: {t.Title} | Revelado: {t.IsRevealed} | Condição: {t.ConditionToReveal}");
    }
}
