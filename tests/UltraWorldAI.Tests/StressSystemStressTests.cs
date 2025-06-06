using UltraWorldAI;
using Xunit;

public class StressSystemStressTests
{
    [Fact]
    public void StressDecayOverManyCycles()
    {
        var person = new Person("Stressful");
        person.Mind.Stress.AddStress(1f);
        for (int i = 0; i < 100; i++)
            person.Mind.Stress.UpdateStressDecay();
        Assert.InRange(person.Mind.Stress.CurrentStressLevel, 0f, 1f);
    }
}
