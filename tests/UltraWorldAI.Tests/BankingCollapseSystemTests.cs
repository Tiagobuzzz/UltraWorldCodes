using System;
using System.IO;
using UltraWorldAI.Economy;
using Xunit;

public class BankingCollapseSystemTests
{
    [Fact]
    public void LoanAboveWealthTriggersFailure()
    {
        BankingCollapseSystem.Loans.Clear();
        BankingCollapseSystem.BankWealth.Clear();
        var original = Console.Out;
        using var writer = new StringWriter();
        Console.SetOut(writer);
        BankingCollapseSystem.GiveLoan("BancoA", "Carol", 2000, 5);
        Console.SetOut(original);
        Assert.Empty(BankingCollapseSystem.Loans);
        Assert.Equal(1000, BankingCollapseSystem.BankWealth["BancoA"]);
        Assert.Contains("quebrou", writer.ToString());
    }
}
