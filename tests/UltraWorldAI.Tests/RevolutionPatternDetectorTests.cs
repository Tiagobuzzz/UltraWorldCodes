using UltraWorldAI.Politics;
using Xunit;

public class RevolutionPatternDetectorTests
{
    [Fact]
    public void DetectsCommonCauses()
    {
        RevolutionPatternDetector.History.Clear();
        RevolutionPatternDetector.AddEvent(1000, "opressao");
        RevolutionPatternDetector.AddEvent(1010, "opressao");
        var causes = RevolutionPatternDetector.GetCommonCauses();
        Assert.Contains("opressao", causes);
    }
}
