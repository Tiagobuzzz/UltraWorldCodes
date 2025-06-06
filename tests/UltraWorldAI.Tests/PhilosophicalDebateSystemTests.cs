using UltraWorldAI.Education;
using Xunit;

public class PhilosophicalDebateSystemTests
{
    [Fact]
    public void HostDebateRegistersEntry()
    {
        PhilosophicalDebateSystem.Debates.Clear();
        PhilosophicalDebateSystem.HostDebate("Salão", "A", "B", "lucro", "Vitória A", "");
        Assert.Single(PhilosophicalDebateSystem.Debates);
    }
}
