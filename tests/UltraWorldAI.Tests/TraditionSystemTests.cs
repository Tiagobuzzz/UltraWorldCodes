using UltraWorldAI;
using Xunit;

public class TraditionSystemTests
{
    [Fact]
    public void CreateTraditionStoresEntry()
    {
        var system = new TraditionSystem();
        system.CreateTradition("insp", "motivo", "origem");
        Assert.Single(system.Traditions);
        Assert.Equal("Tradicao de insp", system.Traditions[0].Name);
    }

    [Fact]
    public void PerformRitualAddsMemoryAndHistory()
    {
        var person = new Person("Sacerdote");
        var system = person.Mind.Traditions;
        system.CreateTradition("origem", "proposito", "historia");

        person.Mind.Emotions.SetEmotion("love", 0.8f);
        system.PerformRitual("celebracao", person, person.Mind.Emotions);

        Assert.Single(system.RitualHistory);
        Assert.Single(system.Traditions[0].Rituals);
        Assert.Contains(person.Mind.Memory.Memories, m => m.Summary.Contains("Participou do ritual"));
    }
}
