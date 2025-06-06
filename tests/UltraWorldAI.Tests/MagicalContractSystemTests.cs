using UltraWorldAI.Language;
using Xunit;

public class MagicalContractSystemTests
{
    [Fact]
    public void CreateContractAddsEntry()
    {
        MagicalContractSystem.Contracts.Clear();
        MagicalContractSystem.CreateContract("AI","Contrato","Protecao");
        Assert.Single(MagicalContractSystem.Contracts);
        Assert.Equal("Protecao", MagicalContractSystem.Contracts[0].Effect);
    }
}
