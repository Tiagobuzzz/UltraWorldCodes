using System.Collections.Generic;
using UltraWorldAI.Communication;
using Xunit;

public class CulturalCipherBookSystemTests
{
    [Fact]
    public void ReadBookReturnsDecodedForCorrectCulture()
    {
        CulturalCipherBookSystem.Books.Clear();
        var vocab = new Dictionary<string, string>
        {
            ["paz"] = "thakar",
            ["alian\u00e7a"] = "morn"
        };

        CulturalCipherBookSystem.AddBook("Codex", "Solarianos", vocab, "paz alian\u00e7a");
        var decoded = CulturalCipherBookSystem.ReadBook("Codex", "Solarianos");

        Assert.Equal("paz alian\u00e7a", decoded);
    }
}
