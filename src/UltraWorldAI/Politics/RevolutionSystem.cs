using System;
using System.Collections.Generic;

namespace UltraWorldAI.Politics;

public class Revolution
{
    public string Kingdom { get; set; } = string.Empty;
    public string Leader { get; set; } = string.Empty;
    public string Cause { get; set; } = string.Empty; // "Opressão", "Herança contestada", "Falha divina", etc.
    public bool WasSuccessful { get; set; }
}

public static class RevolutionSystem
{
    public static List<Revolution> Revolts { get; } = new();

    public static void StartRevolution(string kingdom, string leader, string cause)
    {
        var success = RandomSingleton.Shared.NextDouble() > 0.5;

        Revolts.Add(new Revolution
        {
            Kingdom = kingdom,
            Leader = leader,
            Cause = cause,
            WasSuccessful = success
        });

        Console.WriteLine(success
            ? $"🔥 Revolução bem-sucedida em {kingdom} liderada por {leader} (Motivo: {cause})"
            : $"❌ Revolução fracassada em {kingdom}. {leader} foi derrotado.");
    }

    public static void PrintRevolts()
    {
        foreach (var r in Revolts)
            Console.WriteLine($"\n💣 {r.Leader} | Reino: {r.Kingdom} | Motivo: {r.Cause} | Vitória: {r.WasSuccessful}");
    }
}
