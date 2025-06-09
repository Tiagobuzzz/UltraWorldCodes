using System;
using System.Collections.Generic;
using System.Linq;

namespace UltraWorldAI.Collections;

internal class PriorityQueue<TElement, TPriority> where TPriority : IComparable<TPriority>
{
    private readonly SortedDictionary<TPriority, Queue<TElement>> _dict = new();

    public int Count { get; private set; }

    public void Enqueue(TElement element, TPriority priority)
    {
        if (!_dict.TryGetValue(priority, out var queue))
        {
            queue = new Queue<TElement>();
            _dict.Add(priority, queue);
        }
        queue.Enqueue(element);
        Count++;
    }

    public TElement Dequeue()
    {
        var first = _dict.First();
        var element = first.Value.Dequeue();
        if (first.Value.Count == 0)
            _dict.Remove(first.Key);
        Count--;
        return element;
    }
}
