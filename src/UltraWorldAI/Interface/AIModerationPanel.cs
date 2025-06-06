namespace UltraWorldAI.Interface;

using System.Collections.Generic;
using System.Linq;

public class AIModerationPanel
{
    private readonly List<Person> _registered = new();
    private readonly HashSet<string> _blocked = new();

    public void Register(Person person)
    {
        if (!_registered.Contains(person))
            _registered.Add(person);
    }

    public void Block(string name) => _blocked.Add(name);

    public void Unblock(string name) => _blocked.Remove(name);

    public bool IsBlocked(string name) => _blocked.Contains(name);

    public IEnumerable<Person> ActiveAIs => _registered.Where(p => !_blocked.Contains(p.Name));
}

