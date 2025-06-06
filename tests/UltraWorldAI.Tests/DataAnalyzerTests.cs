using System.Collections.Generic;
using UltraWorldAI.Research;
using Xunit;

public class DataAnalyzerTests
{
    [Fact]
    public void AnalyzeReturnsSummary()
    {
        var result = DataAnalyzer.Analyze(new List<double> { 1.0, 2.0, 3.0 });
        Assert.Contains("avg", result);
    }
}
