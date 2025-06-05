using UltraWorldAI;
using Xunit;

public class DoctrineSystemTests
{
    [Fact]
    public void EvolveCreatesDoctrineAndTruth()
    {
        var person = new Person("Guru");
        person.Mind.Expressions.Symbols.Add(new PersonalSymbol { Motif = "fogo" });
        person.Mind.Expressions.Symbols.Add(new PersonalSymbol { Motif = "espelho" });
        person.Mind.Beliefs.UpdateBelief("Coragem", 0.9f);
        var system = new DoctrineSystem();

        system.EvolveFromSymbolsAndBeliefs(person.Mind.Expressions, person.Mind.Beliefs);

        Assert.Single(system.Doctrines);
        Assert.Single(system.CoreTruths);
    }

    [Fact]
    public void PreachDoctrineAddsBeliefToTarget()
    {
        var teacher = new Person("Mestre");
        teacher.Mind.Expressions.Symbols.Add(new PersonalSymbol { Motif = "fogo" });
        teacher.Mind.Beliefs.UpdateBelief("Sabedoria", 0.8f);
        var system = new DoctrineSystem();
        system.EvolveFromSymbolsAndBeliefs(teacher.Mind.Expressions, teacher.Mind.Beliefs);

        var follower = new Person("Disc\u00edpulo");
        system.PreachDoctrine(follower);

        Assert.NotEmpty(follower.Mind.DynamicBeliefs.Beliefs);
        Assert.Contains(follower.Mind.Memory.Memories, m => m.Summary.Contains("Foi ensinado"));
    }
}
