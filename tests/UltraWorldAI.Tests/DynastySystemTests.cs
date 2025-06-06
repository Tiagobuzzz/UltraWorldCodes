using System.Linq;
using UltraWorldAI.Politics;
using Xunit;

public class DynastySystemTests
{
    [Fact]
    public void RegistersRoyalMember()
    {
        DynastySystem.Members.Clear();
        DynastySystem.RegisterMember("Kael", "Umbra", "Rei", "Tharion", "Elria", true);
        Assert.Contains(DynastySystem.Members, m => m.Name == "Kael" && m.IsLegitimate);
    }
}
