using UltraWorldAI.Module15;
using Xunit;

public class SacredAestheticSystemTests
{
    [Fact]
    public void AddSacredAestheticRegistersForm()
    {
        SacredAestheticSystem.SacredStyles.Clear();
        SacredAestheticSystem.AddSacredAesthetic("Tribo", "Ouro", "Ritual");
        Assert.Contains(SacredAestheticSystem.SacredStyles, s => s.Culture == "Tribo" && s.SacredStyle == "Ouro" && s.Function == "Ritual");
    }
}
