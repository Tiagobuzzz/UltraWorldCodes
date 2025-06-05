using UltraWorldAI;
using Xunit;

public class ContradictionSystemTests
{
    [Fact]
    public void EvaluateDetectsInternalConflict()
    {
        var person = new Person("Tester");
        person.Mind.Goals.AddGoal("confrontar inimigo", 0.9f);
        foreach (var sub in person.Mind.Subvoices.Subpersonalities)
            sub.CurrentInfluence = sub.Name == "Filósofo" ? 0.9f : 0.1f;

        person.Mind.Contradictions.EvaluateContradictions(
            person.Mind.Goals,
            person.Mind.Emotions,
            person.Mind.Subvoices);

        Assert.Contains("Deseja confrontar, mas sente que deveria refletir.",
            person.Mind.Contradictions.Contradictions);
    }

    [Fact]
    public void TriggerSelfSabotageClearsGoals()
    {
        var person = new Person("Saboteur");
        person.Mind.Goals.AddGoal("confrontar adversidade", 0.9f);
        foreach (var sub in person.Mind.Subvoices.Subpersonalities)
            sub.CurrentInfluence = sub.Name == "Filósofo" ? 0.9f : 0.1f;
        person.Mind.Emotions.SetEmotion("love", 0.7f);
        person.Mind.Emotions.SetEmotion("fear", 0.7f);

        person.Mind.Contradictions.EvaluateContradictions(
            person.Mind.Goals,
            person.Mind.Emotions,
            person.Mind.Subvoices);
        person.Mind.Contradictions.TriggerSelfSabotage(person.Mind);

        Assert.Empty(person.Mind.Goals.ActiveGoals);
        Assert.Contains(person.Mind.Memory.Memories,
            m => m.Summary.Contains("Desistiu de um objetivo importante."));
    }
}
