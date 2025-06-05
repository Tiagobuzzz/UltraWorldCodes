using UltraWorldAI;
using Xunit;

public class DefenseMechanismSystemTests
{
    [Fact]
    public void HighFearActivatesAnesthesia()
    {
        var person = new Person("Fearful");
        person.Mind.Emotions.SetEmotion("fear", 0.9f);
        person.Mind.Defenses.EvaluateDefenses(person.Mind.Conflict, person.Mind.Emotions, person.Mind.DynamicBeliefs);

        Assert.Contains("anestesia emocional", person.Mind.Defenses.ActiveDefenses);
        Assert.True(person.Mind.Defenses.IsEmotionBlocked("sorrow"));
    }

    [Fact]
    public void DefenseIntensityAccumulates()
    {
        var person = new Person("Cautious");
        person.Mind.Emotions.SetEmotion("fear", 0.9f);

        person.Mind.Defenses.EvaluateDefenses(person.Mind.Conflict, person.Mind.Emotions, person.Mind.DynamicBeliefs);
        var first = person.Mind.Defenses.GetDefenseIntensity("anestesia emocional");
        person.Mind.Defenses.EvaluateDefenses(person.Mind.Conflict, person.Mind.Emotions, person.Mind.DynamicBeliefs);
        var second = person.Mind.Defenses.GetDefenseIntensity("anestesia emocional");

        Assert.True(second > first);
    }
}
