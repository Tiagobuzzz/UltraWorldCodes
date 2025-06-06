using UltraWorldAI.Language;
using Xunit;

public class LinguisticCreativitySystemTests
{
    [Fact]
    public void InventWordAddsToList()
    {
        LinguisticCreativitySystem.Creations.Clear();
        LinguisticCreativitySystem.RegisterCreator("AI", "Neo");
        LinguisticCreativitySystem.InventWord("AI", "nova");
        var creator = LinguisticCreativitySystem.Creations.Find(c => c.IAName == "AI");
        Assert.Contains("nova", creator!.NewWords);
    }
}
