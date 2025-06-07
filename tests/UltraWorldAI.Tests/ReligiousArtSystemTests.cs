using UltraWorldAI.Module15;
using Xunit;

public class ReligiousArtSystemTests
{
    [Fact]
    public void AddReligiousArtRegistersWork()
    {
        ReligiousArtSystem.Works.Clear();
        ReligiousArtSystem.AddReligiousArt("Olhos", "Kael", "Doutrina", "Ícone", "A voz é queda");
        Assert.Contains(ReligiousArtSystem.Works, w => w.Title == "Olhos" && w.Creator == "Kael" && w.AssociatedFaith == "Doutrina" && w.Type == "Ícone" && w.DoctrinalMessage == "A voz é queda");
    }
}
