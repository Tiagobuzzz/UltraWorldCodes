using UltraWorldAI.Economy;
using Xunit;

public class BlockchainLedgerTests
{
    [Fact]
    public void AddBlockAppendsChain()
    {
        BlockchainLedger.Initialize();
        int before = BlockchainLedger.Chain.Count;
        BlockchainLedger.AddBlock("evento");
        Assert.Equal(before + 1, BlockchainLedger.Chain.Count);
        Assert.Equal("evento", BlockchainLedger.Chain[^1].Data);
    }
}
