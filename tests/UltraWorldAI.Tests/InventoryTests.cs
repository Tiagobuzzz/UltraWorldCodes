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

    [Fact]
    public void ContainsFindsItemByName()
    {
        var inv = new Inventory();
        inv.Add(new Item("Stone"));
        Assert.True(inv.Contains("Stone"));
        Assert.False(inv.Contains("Wood"));
    }

    [Fact]
    public void RemoveByNameDeletesCorrectItem()
    {
        var inv = new Inventory();
        inv.Add(new Item("Apple"));
        inv.Add(new Item("Sword"));
        Assert.True(inv.RemoveByName("Apple"));
        Assert.False(inv.Contains("Apple"));
        Assert.True(inv.Contains("Sword"));
    }
}
