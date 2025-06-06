using System;
using System.Collections.Generic;

namespace UltraWorldAI.Literature;

public class PoeticSecret
{
    public string Creator { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public string EncodedSecret { get; set; } = string.Empty;
    public string UnlockForm { get; set; } = string.Empty; // "Lido em voz alta", "Em ritual", etc.
}

public static class PoeticSecretSystem
{
    public static List<PoeticSecret> Secrets { get; } = new();

    public static void HideSecret(string creator, string title, string secret, string unlockForm)
    {
        Secrets.Add(new PoeticSecret
        {
            Creator = creator,
            Title = title,
            EncodedSecret = secret,
            UnlockForm = unlockForm
        });

        Console.WriteLine($"\ud83d\udc9c Segredo escondido em poema: {title} (Criado por {creator})");
    }

    public static void AttemptUnlock(string title, string condition)
    {
        var s = Secrets.Find(s => s.Title == title);
        if (s != null && s.UnlockForm == condition)
            Console.WriteLine($"\ud83d\udd13 O poema '{title}' revelou o segredo: {s.EncodedSecret}");
        else
            Console.WriteLine($"\u274c O poema '{title}' n\u00e3o foi decifrado sob a condi\u00e7\u00e3o '{condition}'");
    }

    public static void PrintAllPoems()
    {
        foreach (var s in Secrets)
        {
            Console.WriteLine($"\n\ud83d\udcd6 {s.Title} | Forma de ativa\u00e7\u00e3o: {s.UnlockForm} | Criado por: {s.Creator}");
        }
    }
}
