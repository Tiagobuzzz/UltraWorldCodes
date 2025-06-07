using System;
using System.Collections.Generic;

namespace UltraWorldAI.Module15;

public class ReligiousArt
{
    public string Title = string.Empty;
    public string Creator = string.Empty;
    public string AssociatedFaith = string.Empty; // "Culto do Vazio", "Doutrina da Chama"
    public string Type = string.Empty; // "Ícone", "Mural", "Estátua", "Poesia sagrada"
    public string DoctrinalMessage = string.Empty; // "A carne é passageira", "O silêncio é pureza"
}

public static class ReligiousArtSystem
{
    public static List<ReligiousArt> Works { get; } = new();

    public static void AddReligiousArt(string title, string creator, string faith, string type, string message)
    {
        Works.Add(new ReligiousArt
        {
            Title = title,
            Creator = creator,
            AssociatedFaith = faith,
            Type = type,
            DoctrinalMessage = message
        });

        Console.WriteLine($"\uD83D\uDD4A\uFE0F Arte doutrin\u00E1ria: {title} | F\u00E9: {faith} | Mensagem: {message}");
    }
}
