using UltraWorldAI;
using Xunit;

public class LifeCycleSystemTests
{
    [Fact]
    public void PersonDiesAfterEightyYears()
    {
        var p = new Person("Idoso");
        p.Age = 79;
        LifeCycleSystem.Advance(p);
        Assert.True(p.IsAlive);
        LifeCycleSystem.Advance(p); // 80
        Assert.False(p.IsAlive);
        Assert.NotNull(p.DeathDate);
    }
}
