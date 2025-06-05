using UltraWorldAI.Religion;
using Xunit;

public class ProphecySystemTests
{
    [Fact]
    public void CreateAddsProphecyToList()
    {
        var prophecy = ProphecySystem.Create("Queda do Sol", "Oraculo", "sonho", "Eclipse total", "Sol desaparecera");

        Assert.Contains(prophecy, ProphecySystem.AllProphecies);
        Assert.Equal("Queda do Sol", prophecy.Title);
    }

    [Fact]
    public void FulfillMarksProphecy()
    {
        var prophecy = ProphecySystem.Create("Chuva Vermelha", "Sacerdotisa", "sangue", "Lua cheia", "Chovera sangue");

        ProphecySystem.Fulfill("Chuva Vermelha");

        Assert.True(prophecy.IsFulfilled);
    }

    [Fact]
    public void CorruptMarksProphecy()
    {
        var prophecy = ProphecySystem.Create("Mentira", "Culto", "sussurro", "Sinal", "Nada ocorre");

        ProphecySystem.Corrupt("Mentira");

        Assert.True(prophecy.IsCorrupted);
    }
}
