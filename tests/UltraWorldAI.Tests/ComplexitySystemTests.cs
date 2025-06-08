using UltraWorldAI;
using Xunit;

public class ComplexitySystemTests
{
    [Fact]
    public void ComplexityScoreUpdatesBasedOnState()
    {
        var person = new Person("Complex");
        person.AddExperience("evento", 0.8f, 0.7f);
        person.Mind.Beliefs.UpdateBelief("Nova crença", 0.6f);
        person.Mind.Complexity.Update(person.Mind);

        Assert.InRange(person.Mind.Complexity.ComplexityScore, 0.1f, 1f);
    }

    [Fact]
    public void ComplexityScoreStaysWithinBounds()
    {
        var person = new Person("Bounds");
        for (int i = 0; i < 200; i++)
        {
            person.AddExperience($"exp{i}", 1f, 1f);
            person.Mind.Beliefs.UpdateBelief($"crenca{i}", 1f);
        }
        person.Mind.Complexity.Update(person.Mind);

        Assert.InRange(person.Mind.Complexity.ComplexityScore, 0f, 1f);
    }
}
