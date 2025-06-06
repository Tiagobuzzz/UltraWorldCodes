using UltraWorldAI.World.Ecology;
using Xunit;

public class NaturalDisasterPredictorTests
{
    [Fact]
    public void TrainingImprovesPrediction()
    {
        var p = new NaturalDisasterPredictor();
        var feats = new float[]{1f,1f,1f};
        for(int i=0;i<50;i++) p.Train(feats, 1f);
        Assert.True(p.Predict(feats) > 0.6f);
    }
}
