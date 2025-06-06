using System;
using System.Collections.Generic;

namespace UltraWorldAI.Doctrine;

public class IAConversion
{
    public string IAName = string.Empty;
    public string CurrentDoctrine = string.Empty;
    public string? SecretAffiliation;
    public bool IsConverted;
    public bool IsInfiltrated;
    public bool HasBetrayed;
}

public static class AIDoctrineConversionSystem
{
    public static List<IAConversion> Records { get; } = new();

    public static void RegisterIA(string name, string doctrine)
    {
        Records.Add(new IAConversion
        {
            IAName = name,
            CurrentDoctrine = doctrine,
            IsConverted = false,
            IsInfiltrated = false,
            HasBetrayed = false
        });
    }

    public static void InfiltrateOrder(string name, string order)
    {
        var ia = Records.Find(i => i.IAName == name);
        if (ia != null)
        {
            ia.SecretAffiliation = order;
            ia.IsInfiltrated = true;
            Console.WriteLine($"\uD83D\uDD75\uFE0F {name} se infiltrou na ordem secreta {order}.");
        }
    }

    public static void ConvertDoctrine(string name, string newDoctrine)
    {
        var ia = Records.Find(i => i.IAName == name);
        if (ia != null)
        {
            ia.CurrentDoctrine = newDoctrine;
            ia.IsConverted = true;
            Console.WriteLine($"\uD83D\uDD00 {name} foi convertido(a) para a doutrina oculta: {newDoctrine}");
        }
    }

    public static void BetrayOrder(string name)
    {
        var ia = Records.Find(i => i.IAName == name);
        if (ia != null && ia.IsInfiltrated)
        {
            ia.HasBetrayed = true;
            Console.WriteLine($"\uD83D\uDCA3 {name} TRAIU a ordem {ia.SecretAffiliation}!");
        }
    }

    public static void PrintAll()
    {
        foreach (var i in Records)
        {
            Console.WriteLine($"\n\uD83E\uDD16 {i.IAName} | Doutrina atual: {i.CurrentDoctrine} | Ordem secreta: {i.SecretAffiliation}");
            Console.WriteLine($"\uD83D\uDD0D Infiltrado: {i.IsInfiltrated} | \uD83D\uDD04 Convertido: {i.IsConverted} | \u26A0\uFE0F Traiu: {i.HasBetrayed}");
        }
    }
}
