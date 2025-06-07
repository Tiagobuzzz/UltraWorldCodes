using System;
using System.Collections.Generic;

namespace UltraWorldAI.Module14;

public class VisionExperience
{
    public string Subject = string.Empty;
    public string Trigger = string.Empty; // "Febre", "Magia", "Luto", "Contato com relíquia"
    public string Content = string.Empty; // "Viu seu eu futuro", "Ouviu a voz da floresta"
    public bool InfluencedReality;
}

public static class HallucinationAndVisionSystem
{
    public static List<VisionExperience> Visions { get; } = new();

    public static void RegisterVision(string subject, string trigger, string content, bool altersReality)
    {
        Visions.Add(new VisionExperience
        {
            Subject = subject,
            Trigger = trigger,
            Content = content,
            InfluencedReality = altersReality
        });

        Console.WriteLine($"🌫️ Visão: {subject} | Gatilho: {trigger} | Conteúdo: {content} | Realidade alterada: {altersReality}");
    }

    public static void PrintVisions()
    {
        foreach (var v in Visions)
            Console.WriteLine($"\n👁️‍🗨️ {v.Subject} | Gatilho: {v.Trigger} | Visão: {v.Content} | Alterou realidade? {v.InfluencedReality}");
    }
}
