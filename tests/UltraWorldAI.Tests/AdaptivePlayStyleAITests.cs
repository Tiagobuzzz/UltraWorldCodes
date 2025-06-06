using UltraWorldAI;
using Xunit;

public class AdaptivePlayStyleAITests
{
    [Fact]
    public void PredictAggressionIncreasesWithMoves()
    {
        AdaptivePlayStyleAI.RecordMove("atk");
        var first = AdaptivePlayStyleAI.PredictAggression();
        AdaptivePlayStyleAI.RecordMove("atk");
        AdaptivePlayStyleAI.RecordMove("atk");
        var second = AdaptivePlayStyleAI.PredictAggression();
        Assert.True(second >= first);
    }
}
