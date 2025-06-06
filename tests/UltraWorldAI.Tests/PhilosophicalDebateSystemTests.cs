using UltraWorldAI.Economy;
using Xunit;

public class PhilosophicalDebateSystemTests
{
    [Fact]
    public void HostDebateAddsDebate()
    {
        PhilosophicalDebateSystem.Debates.Clear();
        PhilosophicalDebateSystem.HostDebate(
            "Salão das Vozes",
            "Kael",
            "Zor'mak",
            "Lucro e Moral",
            "Vitória A",
            "Conversão parcial");

        Assert.Single(PhilosophicalDebateSystem.Debates);
        var debate = PhilosophicalDebateSystem.Debates[0];
        Assert.Equal("Lucro e Moral", debate.Topic);
        Assert.Equal("Vitória A", debate.Outcome);
    }
}
