using System.Collections.Generic;
using UltraWorldAI.Discovery;
using Xunit;

public class TechIntentSystemTests
{
    [Fact]
    public void InferPurposeRecognizesArt()
    {
        var concepts = new List<string> { "imagem", "som" };
        var intent = TechIntentSystem.InferPurpose(concepts, "", "");
        Assert.Equal("Expressar arte ou registrar", intent);
    }
}
