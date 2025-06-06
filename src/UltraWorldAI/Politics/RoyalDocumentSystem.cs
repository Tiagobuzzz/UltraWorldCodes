using System;
using System.Collections.Generic;

namespace UltraWorldAI.Politics;

public class RoyalDocument
{
    public string Title { get; set; } = string.Empty;
    public string Issuer { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public bool IsForged { get; set; }
}

public static class RoyalDocumentSystem
{
    public static List<RoyalDocument> Documents { get; } = new();

    public static void IssueDocument(string title, string issuer, string type, string content, bool forged = false)
    {
        Documents.Add(new RoyalDocument
        {
            Title = title,
            Issuer = issuer,
            Type = type,
            Content = content,
            IsForged = forged
        });

        Console.WriteLine(forged
            ? $"\U0001F575️ Documento falsificado criado: {title} por {issuer} | Tipo: {type}"
            : $"\U0001F4DC Documento oficial criado: {title} por {issuer} | Tipo: {type}");
    }

    public static void PrintDocuments()
    {
        foreach (var d in Documents)
            Console.WriteLine($"\n\U0001F4C4 {d.Type}: {d.Title} | Emitido por: {d.Issuer} | Falsificado? {d.IsForged} \n→ {d.Content}");
    }
}
