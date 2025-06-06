using System.Collections.Generic;
using System.IO;
using UltraWorldAI;
using UltraWorldAI.Civilization;
using Xunit;

public class CulturePersistenceTests
{
    [Fact]
    public void SaveAndLoadCulturesRoundTrip()
    {
        var system = new CultureSystem();
        var culture = system.CreateCultureFromIdea("Sabedoria", new List<string> { "Conhecimento" });
        system.AddCollectiveMemory(culture.Name, "memoria", 0.4f);

        var path = Path.GetTempFileName();
        CulturePersistence.Save(path, system.Cultures);
        var loaded = CulturePersistence.Load(path);

        Assert.Single(loaded);
        Assert.Equal(culture.Name, loaded[0].Name);
        Assert.Single(loaded[0].CollectiveMemory.Memories);
    }
}
