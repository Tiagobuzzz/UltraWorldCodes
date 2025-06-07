using UltraWorldAI.Magic;
using Xunit;

public class CurseAndPactSystemTests
{
    [Fact]
    public void CreateCurseAddsEntry()
    {
        CurseAndPactSystem.Curses.Clear();
        CurseAndPactSystem.CreateCurse("Silencio", "Falar", "Mudo", true);
        Assert.Contains(CurseAndPactSystem.Curses, c => c.Name == "Silencio");
    }

    [Fact]
    public void CreatePactAddsEntry()
    {
        CurseAndPactSystem.Pacts.Clear();
        CurseAndPactSystem.CreatePact("Demo", "Servir", "Poder", true);
        Assert.Contains(CurseAndPactSystem.Pacts, p => p.EntityName == "Demo");
    }
}
