using UltraWorldAI;
using Xunit;

public class StressSystemTests
{
    [Fact]
    public void AddStressIncreasesLevel()
    {
        var person = new Person("Stressed");
        person.Mind.Stress.AddStress(0.3f);
        Assert.True(person.Mind.Stress.CurrentStressLevel >= 0.3f);
    }

    [Fact]
    public void ReduceStressLowersLevel()
    {
        var person = new Person("Calm");
        person.Mind.Stress.AddStress(0.6f);
        person.Mind.Stress.ReduceStress(0.2f);
        Assert.InRange(person.Mind.Stress.CurrentStressLevel, 0.3f, 0.5f);
    }

    [Fact]
    public void UpdateStressDecayReducesBySettings()
    {
        var person = new Person("Decay");
        person.Mind.Stress.AddStress(0.2f);
        person.Mind.Stress.UpdateStressDecay();
        var expected = 0.2f - AISettings.StressDecayRate;
        Assert.InRange(person.Mind.Stress.CurrentStressLevel, expected - 0.001f, expected + 0.001f);
    }

    [Fact]
    public void IsStressedReflectsThreshold()
    {
        var person = new Person("Check");
        person.Mind.Stress.AddStress(0.6f);
        Assert.True(person.Mind.Stress.IsStressed());
    }
}
