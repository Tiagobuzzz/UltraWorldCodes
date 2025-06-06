using System.Collections.Generic;

namespace UltraWorldAI.Game;

public sealed class Inventory
{
    private readonly List<Item> _items = new();
    public IReadOnlyList<Item> Items => _items;

    public void Add(Item item) => _items.Add(item);
    public bool Remove(Item item) => _items.Remove(item);

    public bool Contains(string itemName)
        => _items.Exists(i => i.Name == itemName);

    public bool RemoveByName(string itemName)
    {
        var index = _items.FindIndex(i => i.Name == itemName);
        if (index >= 0)
        {
            _items.RemoveAt(index);
            return true;
        }
        return false;
    }
}
