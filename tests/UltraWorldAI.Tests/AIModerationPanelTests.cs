using UltraWorldAI;
using UltraWorldAI.Interface;
using Xunit;

public class AIModerationPanelTests
{
    [Fact]
    public void BlockPreventsActiveStatus()
    {
        var panel = new AIModerationPanel();
        var p = new Person("Test");
        panel.Register(p);
        panel.Block("Test");

        Assert.Empty(panel.ActiveAIs);
        Assert.True(panel.IsBlocked("Test"));
    }
}

