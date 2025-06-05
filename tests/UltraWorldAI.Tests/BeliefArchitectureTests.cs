using UltraWorldAI;
using Xunit;
using System.Linq;

public class BeliefArchitectureTests
{
    [Fact]
    public void AddBeliefCreatesOrUpdatesNode()
    {
        var arch = new BeliefArchitecture();
        arch.AddBelief("liberdade sempre", 0.7f, "memoria", "love");
        Assert.Single(arch.Beliefs);
        arch.AddBelief("liberdade sempre", 0.2f, "memoria", "love");
        Assert.InRange(arch.Beliefs.First().Conviction, 0.73f, 0.75f);
    }

    [Fact]
    public void ResolveContradictionsWeakensLowerConviction()
    {
        var person = new Person("Believer");
        var arch = person.Mind.DynamicBeliefs;
        arch.AddBelief("A liberdade sempre prevalece", 0.9f, "memoria", "love");
        arch.AddBelief("A liberdade nunca prevalece", 0.2f, "ensinamento", "fear");

        var weakBefore = arch.Beliefs.First(b => b.Statement.Contains("nunca")).Conviction;
        arch.ResolveContradictions(person.Mind.Conflict, person.Mind.Emotions);
        var node = arch.Beliefs.FirstOrDefault(b => b.Statement.Contains("nunca"));
        var weakened = node?.Conviction ?? 0f;

        Assert.True(weakened < weakBefore);
        Assert.True(person.Mind.Conflict.HasActiveContradictions());
    }
}
