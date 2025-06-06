using UltraWorldAI;
using Xunit;

public class MachineLearningAdaptationTests
{
    [Fact]
    public void TrainingImprovesPrediction()
    {
        var ml = new MachineLearningAdaptation();
        var features = new float[] { 1f, 1f };
        for (int i = 0; i < 50; i++)
        {
            ml.Train(features, 1f);
        }
        Assert.True(ml.Predict(features) > 0.6f);
    }

    [Fact]
    public void AdaptPersonalityChangesTrait()
    {
        var ml = new MachineLearningAdaptation();
        var person = new Person("Tester");
        var memory = new Memory
        {
            Summary = "test",
            Date = System.DateTime.Now,
            Intensity = 0.8f,
            EmotionalCharge = 0.8f,
            Keywords = new()
        };
        var before = person.Mind.Personality.GetTrait("Abertura");
        ml.AdaptPersonality(person, memory, "Abertura");
        var after = person.Mind.Personality.GetTrait("Abertura");
        Assert.NotEqual(before, after);
    }
}
