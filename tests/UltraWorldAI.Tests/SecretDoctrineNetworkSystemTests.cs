using System.Collections.Generic;
using UltraWorldAI.Doctrine;
using UltraWorldAI.Politics;
using Xunit;

public class SecretDoctrineNetworkSystemTests
{
    [Fact]
    public void CreateOrderStoresOrder()
    {
        SecretDoctrineNetworkSystem.Orders.Clear();
        SecretDoctrineNetworkSystem.CreateOrder(
            "Circulo", "Doutrina", "Fundador", "Cidade",
            new List<string> { "Objetivo" });

        Assert.Single(SecretDoctrineNetworkSystem.Orders);
    }

    [Fact]
    public void OrchestrateCoupAddsRegimeShift()
    {
        SecretDoctrineNetworkSystem.Orders.Clear();
        RegimeShiftSystem.History.Clear();
        SecretDoctrineNetworkSystem.CreateOrder(
            "Circulo", "Doutrina", "Fundador", "Cidade",
            new List<string> { "Objetivo" });

        SecretDoctrineNetworkSystem.OrchestrateCoup("Circulo", 1500, "Regiao", "A", "B");
        Assert.Single(RegimeShiftSystem.History);
    }

    [Fact]
    public void InciteRevolutionAddsEvent()
    {
        SecretDoctrineNetworkSystem.Orders.Clear();
        RevolutionPatternDetector.History.Clear();
        SecretDoctrineNetworkSystem.CreateOrder(
            "Circulo", "Doutrina", "Fundador", "Cidade",
            new List<string> { "Objetivo" });

        SecretDoctrineNetworkSystem.InciteRevolution("Circulo", 1500, "opressao");
        Assert.Single(RevolutionPatternDetector.History);
    }
}
