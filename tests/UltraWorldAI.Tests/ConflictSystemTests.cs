using UltraWorldAI;
using Xunit;

public class ConflictSystemTests
{
    [Fact]
    public void DetectsAndResolvesContradiction()
    {
        var person = new Person("Test");
        person.Mind.Conflict.TriggerContradiction("aspecto", "acao");
        Assert.True(person.Mind.Conflict.HasActiveContradictions());
        person.Mind.Conflict.ResolveContradiction("aspecto");
        Assert.False(person.Mind.Conflict.HasActiveContradictions());
    }
}
