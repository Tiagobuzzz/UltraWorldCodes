using UltraWorldAI;
using Xunit;

public class LifeStageRitualTests
{
    [Fact]
    public void PerformLifeStageRitualAddsMemory()
    {
        var person = new Person("RiteTest");
        person.CurrentLifeStage = LifeStage.Adulto;
        var traditions = person.Mind.Traditions;
        traditions.AddLifeStageRitual(LifeStage.Adulto, "Iniciação Adulta");

        traditions.PerformLifeStageRitual(person);

        Assert.Contains(person.Mind.Memory.Memories, m => m.Summary.Contains("Iniciação Adulta"));
        Assert.Contains(traditions.RitualHistory, r => r.Name == "Iniciação Adulta" && r.Type == "transicao");
    }
}
