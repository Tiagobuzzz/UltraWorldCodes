using System.Collections.Generic;
using UltraWorldAI.Literature;
using Xunit;

public class BookCreationSystemTests
{
    [Fact]
    public void WriteBookAddsToLibrary()
    {
        BookCreationSystem.Library.Clear();
        BookCreationSystem.WriteBook(
            "Codice",
            "Thalor",
            "Grimório",
            new List<string> { "Magia" },
            true,
            "Templo",
            selfWriting: true,
            burnsOnRead: false);

        Assert.Single(BookCreationSystem.Library);
    }

    [Fact]
    public void ReadBookBurnsWhenFlagged()
    {
        BookCreationSystem.Library.Clear();
        BookCreationSystem.WriteBook(
            "Fênix",
            "Autor",
            "Tratado",
            new List<string>(),
            false,
            "Fornalha",
            burnsOnRead: true);

        BookCreationSystem.ReadBook("Fênix");
        Assert.Empty(BookCreationSystem.Library);
    }
}

