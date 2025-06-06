using UltraWorldAI.Language;
using Xunit;

public class NeuralLanguageLearnerTests
{
    [Fact]
    public void TrainingImprovesPrediction()
    {
        var nn = new NeuralLanguageLearner();
        var sample = new float[] { 1f, 0f, 1f, 0f, 1f };
        var initial = nn.Predict(sample);
        for (int i = 0; i < 100; i++)
            nn.Train(sample, 1f);
        var trained = nn.Predict(sample);
        Assert.True(trained > initial);
    }
}
