using System;
using System.Collections.Generic;

namespace UltraWorldAI.Literature;

public class Book
{
    public string Title = string.Empty;
    public string Author = string.Empty;
    public string Type = string.Empty; // "Livro científico", "Grimório", "Manuscrito filosófico"
    public List<string> Topics = new();
    public bool IsCursed;
    public string OriginPlace = string.Empty;
    public bool SelfWriting;
    public bool BurnsOnRead;
}

public static class BookCreationSystem
{
    public static List<Book> Library { get; } = new();

    public static void WriteBook(
        string title,
        string author,
        string type,
        List<string> topics,
        bool cursed,
        string origin,
        bool selfWriting = false,
        bool burnsOnRead = false)
    {
        Library.Add(new Book
        {
            Title = title,
            Author = author,
            Type = type,
            Topics = topics,
            IsCursed = cursed,
            OriginPlace = origin,
            SelfWriting = selfWriting,
            BurnsOnRead = burnsOnRead
        });

        Console.WriteLine($"\ud83d\udcd6 Livro criado: '{title}' por {author} | Tipo: {type} | Amaldiçoado? {cursed}");
    }

    public static void ReadBook(string title)
    {
        var book = Library.Find(b => b.Title == title);
        if (book == null) return;

        if (book.SelfWriting)
            Console.WriteLine($"\ud83d\udcdd O livro '{title}' continua se escrevendo sozinho...");

        if (book.BurnsOnRead)
        {
            Console.WriteLine($"\ud83d\udd25 O livro '{title}' queimou ao ser lido!");
            Library.Remove(book);
            return;
        }

        if (book.IsCursed)
            Console.WriteLine($"\u2620\ufe0f Você foi amaldiçoado ao ler '{title}'!");
    }
}
