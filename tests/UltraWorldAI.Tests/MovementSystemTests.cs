using UltraWorldAI;
using UltraWorldAI.Territory;
using Xunit;

public class MovementSystemTests
{
    [Fact]
    public void MoveUpdatesLocationAndCreatesMemory()
    {
        var person = new Person("Traveler");
        var before = person.Mind.Memory.Memories.Count;

        MovementSystem.Move(person, 1f, 1f);

        Assert.Equal("Planícies do Norte", person.Location.RegionName);
        Assert.True(person.Mind.Memory.Memories.Count > before);
    }
}
