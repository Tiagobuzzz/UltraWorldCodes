using UltraWorldAI.Economy;
using Xunit;

public class TradeAndLootSystemTests
{
    [Fact]
    public void MakeTradeRecordsTransaction()
    {
        TradeAndLootSystem.Transactions.Clear();
        TradeAndLootSystem.MakeTrade("A", "B", "Ferro", 5, "Moeda", true);
        Assert.Single(TradeAndLootSystem.Transactions);
        var t = TradeAndLootSystem.Transactions[0];
        Assert.Equal("A", t.From);
        Assert.True(t.WasFair);
    }
}
