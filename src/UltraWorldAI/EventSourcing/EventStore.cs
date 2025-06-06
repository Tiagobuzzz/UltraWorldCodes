using System.Collections.Generic;
using System.Linq;
namespace UltraWorldAI.EventSourcing;

public record EventRecord(string Type, string Data, DateTime Timestamp);

public interface IEventStore
{
    void Record(EventRecord evt);
    IReadOnlyList<EventRecord> GetEvents(string? type = null);
}

public class InMemoryEventStore : IEventStore
{
    private readonly List<EventRecord> _events = new();

    public void Record(EventRecord evt)
    {
        _events.Add(evt);
    }

    public IReadOnlyList<EventRecord> GetEvents(string? type = null)
    {
        return type == null ? _events : _events.Where(e => e.Type == type).ToList();
    }
}
