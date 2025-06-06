using UltraWorldAI.Morality;
using Xunit;

public class MoralSystemTests
{
    [Fact]
    public void UpdateValueClampsBetweenZeroAndOne()
    {
        var m = new MoralSystem();
        m.UpdateValue("honra", 0.8f);
        m.UpdateValue("honra", 0.5f);
        Assert.Equal(1f, m.GetValue("honra"));
    }
}
