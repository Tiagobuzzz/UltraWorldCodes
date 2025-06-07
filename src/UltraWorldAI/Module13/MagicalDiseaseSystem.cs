using System;
using System.Collections.Generic;

namespace UltraWorldAI.Module13;

public class MagicalDisease
{
    public string Name = string.Empty;
    public string Origin = string.Empty; // "Maldi\u00e7\u00e3o", "Plano da N\u00e9voa", "Deus Esquecido"
    public string Symptom = string.Empty; // "Sangue canta", "Pele cristaliza"
    public float SpreadRate;
    public bool IsCultural;
}

public static class MagicalDiseaseSystem
{
    public static List<MagicalDisease> Diseases { get; } = new();

    public static void AddDisease(string name, string origin, string symptom, float spreadRate, bool cultural)
    {
        Diseases.Add(new MagicalDisease
        {
            Name = name,
            Origin = origin,
            Symptom = symptom,
            SpreadRate = spreadRate,
            IsCultural = cultural
        });

        Console.WriteLine($"\uD83E\uDEC0 Doen\u00e7a m\u00e1gica: {name} | Origem: {origin} | Sintoma: {symptom} | Cont\u00e1gio: {spreadRate} | Cultural: {cultural}");
    }

    public static void PrintDiseases()
    {
        foreach (var d in Diseases)
            Console.WriteLine($"\u2623\uFE0F {d.Name} | Origem: {d.Origin} | Sintoma: {d.Symptom} | Cont\u00e1gio: {d.SpreadRate} | Cultural: {d.IsCultural}");
    }
}
