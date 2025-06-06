using System.Collections.Generic;

namespace UltraWorldAI.Game;

public class Inventory
{
    private readonly List<Item> _items = new();
    public IReadOnlyList<Item> Items => _items;

    public void Add(Item item) => _items.Add(item);
    public bool Remove(Item item) => _items.Remove(item);
}
