using UltraWorldAI;
using UltraWorldAI.Game;
using Xunit;

public class InventoryTests
{
    [Fact]
    public void AddItemStoresInInventory()
    {
        var person = new Person("Collector");
        var item = new Item("Coin");
        person.Inventory.Add(item);
        Assert.Contains(item, person.Inventory.Items);
    }
}
