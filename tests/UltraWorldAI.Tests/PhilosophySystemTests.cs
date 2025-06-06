using UltraWorldAI;
using Xunit;

public class PhilosophySystemTests
{
    [Fact]
    public void UpdateSetsCorePhilosophy()
    {
        var person = new Person("Philo");
        person.Mind.BrainMap.Connect("happiness", "nature", 0.8f);
        person.Mind.Emotions.SetEmotion("happiness", 0.9f);
        person.Mind.Intuition.GenerateInsight(person.Mind);
        person.Mind.Philosophy.Update(person.Mind);

        Assert.NotNull(person.Mind.Philosophy.CorePhilosophy);
        Assert.True(person.Mind.Philosophy.Doctrines.Count >= 2);
    }

    [Fact]
    public void ConsistencyDropsWithContradictoryGoal()
    {
        var person = new Person("Philo");
        person.Mind.BrainMap.Connect("happiness", "nature", 0.8f);
        person.Mind.Emotions.SetEmotion("happiness", 0.9f);
        person.Mind.Intuition.GenerateInsight(person.Mind);
        person.Mind.Philosophy.Update(person.Mind);

        var initialScore = person.Mind.Philosophy.ConsistencyScore;
        person.Mind.Goals.AddGoal("questionar a voz dominante", 0.5f);
        person.Mind.Philosophy.Update(person.Mind);

        Assert.True(person.Mind.Philosophy.ConsistencyScore < initialScore);
        Assert.True(person.Mind.Conflict.HasActiveContradictions());
    }
    [Fact]
    public void ContradictoryMemoryReducesConsistency()
    {
        var person = new Person("Memor");
        person.Mind.BrainMap.Connect("happiness", "natureza", 0.8f);
        person.Mind.Emotions.SetEmotion("happiness", 0.9f);
        person.Mind.Intuition.GenerateInsight(person.Mind);
        person.Mind.Philosophy.Update(person.Mind);
        var initial = person.Mind.Philosophy.ConsistencyScore;

        person.AddExperience("questionar a voz dominante", 0.6f);
        person.Mind.Philosophy.Update(person.Mind);

        Assert.True(person.Mind.Philosophy.ConsistencyScore < initial);
        Assert.True(person.Mind.Conflict.HasActiveContradictions());
    }
}
