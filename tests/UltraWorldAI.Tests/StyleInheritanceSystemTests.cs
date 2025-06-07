using UltraWorldAI.Module15;
using Xunit;

public class StyleInheritanceSystemTests
{
    [Fact]
    public void InheritStyleReturnsCombinedName()
    {
        var style = StyleInheritanceSystem.InheritStyle("Clássico", "TriboA");
        Assert.Equal("Clássico (TriboA)", style);
    }
}
