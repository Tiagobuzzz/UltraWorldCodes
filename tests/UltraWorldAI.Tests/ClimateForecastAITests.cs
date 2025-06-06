using UltraWorldAI.World.Ecology;
using Xunit;

public class ClimateForecastAITests
{
    [Fact]
    public void PredictProbabilitiesReturnsValues()
    {
        ClimateForecastAI.RecordEvent(new ClimateEvent { Region = "R", Type = "Chuva" });
        ClimateForecastAI.RecordEvent(new ClimateEvent { Region = "R", Type = "Seca" });
        var probs = ClimateForecastAI.PredictProbabilities("R");
        Assert.True(probs.Count >= 2);
        Assert.InRange(probs["Chuva"], 0, 1);
    }
}

