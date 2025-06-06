using UltraWorldAI;
using UltraWorldAI.Territory;
using Xunit;

public class HabitatMemoryTests
{
    [Fact]
    public void TagPlaceAddsMemory()
    {
        var mem = new HabitatMemory();
        mem.TagPlace("caverna", "medo", "quase morri", 0.8f, "hostil");

        Assert.Single(mem.TaggedPlaces);
        Assert.Equal("caverna", mem.TaggedPlaces[0].RegionName);
    }

    [Fact]
    public void AddExperienceWithEmotionTagsPlace()
    {
        var person = new Person("Tester");
        person.AddExperience("enfrentou um monstro", 0.7f, 0.9f);

        Assert.Single(person.Mind.HabitatMemory.TaggedPlaces);
        Assert.Equal("Origem", person.Mind.HabitatMemory.TaggedPlaces[0].RegionName);
        Assert.Equal("neutral", person.Mind.HabitatMemory.TaggedPlaces[0].Environment);
    }
}
