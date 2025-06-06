using System.Linq;
using UltraWorldAI.Politics;
using Xunit;

public class HiddenTitleSystemTests
{
    [Fact]
    public void GrantHiddenTitleAddsEntry()
    {
        HiddenTitleSystem.HiddenTitles.Clear();
        HiddenTitleSystem.GrantHiddenTitle("Rei Sob a Montanha", "Kael", "Profecia");
        Assert.Contains(HiddenTitleSystem.HiddenTitles, t => t.Holder == "Kael" && t.Title == "Rei Sob a Montanha");
    }

    [Fact]
    public void RevealTitleMarksRevealed()
    {
        HiddenTitleSystem.HiddenTitles.Clear();
        HiddenTitleSystem.GrantHiddenTitle("Rei Sob a Montanha", "Kael", "Profecia");
        HiddenTitleSystem.RevealTitle("Kael");
        Assert.True(HiddenTitleSystem.HiddenTitles.First().IsRevealed);
    }
}
