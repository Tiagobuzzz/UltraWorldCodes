using UltraWorldAI.Politics;
using Xunit;

public class ChivalricOrderSystemTests
{
    [Fact]
    public void CreateOrderAddsEntry()
    {
        ChivalricOrderSystem.Orders.Clear();
        ChivalricOrderSystem.CreateOrder("Lanças da Aurora", "Kael", "Proteger");
        Assert.Single(ChivalricOrderSystem.Orders);
    }

    [Fact]
    public void AddMemberAppendsToOrder()
    {
        ChivalricOrderSystem.Orders.Clear();
        ChivalricOrderSystem.CreateOrder("Lanças", "Kael", "Proteger");
        ChivalricOrderSystem.AddMember("Lanças", "Tharon");
        Assert.Contains("Tharon", ChivalricOrderSystem.Orders[0].Members);
    }
}
