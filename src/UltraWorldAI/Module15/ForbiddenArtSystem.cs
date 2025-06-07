using System;
using System.Collections.Generic;

namespace UltraWorldAI.Module15;

public class ForbiddenWork
{
    public string Title = string.Empty;
    public string Creator = string.Empty;
    public string Reason = string.Empty; // "Perigosa", "Blasfema", "Mágica demais", "Traiçoeira"
    public bool StillExists;
    public string Location = string.Empty; // "Ruínas", "Caverna Selada", "Santuário Secreto"
}

public static class ForbiddenArtSystem
{
    public static List<ForbiddenWork> Works { get; } = new();

    public static void AddForbiddenWork(string title, string creator, string reason, bool exists, string location)
    {
        Works.Add(new ForbiddenWork
        {
            Title = title,
            Creator = creator,
            Reason = reason,
            StillExists = exists,
            Location = location
        });

        Console.WriteLine($"\uD83D\uDD11 Obra proibida: {title} | Razão: {reason} | Onde está? {location} | Existe? {exists}");
    }
}
