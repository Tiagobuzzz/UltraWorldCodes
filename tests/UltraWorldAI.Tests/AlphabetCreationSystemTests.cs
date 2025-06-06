using UltraWorldAI.Language;
using Xunit;

public class AlphabetCreationSystemTests
{
    [Fact]
    public void InventAddsAlphabet()
    {
        AlphabetCreationSystem.Alphabets.Clear();
        AlphabetCreationSystem.Invent("AI","Runica","Curvas","Magico");
        Assert.Single(AlphabetCreationSystem.Alphabets);
        Assert.Equal("Magico", AlphabetCreationSystem.Alphabets[0].Value);
    }
}
