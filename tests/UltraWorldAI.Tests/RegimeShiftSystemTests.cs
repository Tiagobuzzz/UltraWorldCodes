using UltraWorldAI.Politics;
using Xunit;

public class RegimeShiftSystemTests
{
    [Fact]
    public void AddEventStoresHistory()
    {
        RegimeShiftSystem.History.Clear();
        RegimeShiftSystem.AddEvent(2024, "A", "Monarchy", "Republic");
        Assert.Single(RegimeShiftSystem.History);
    }
}
