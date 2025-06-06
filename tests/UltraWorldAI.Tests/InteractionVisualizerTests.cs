using UltraWorldAI;
using UltraWorldAI.Visualization;
using Xunit;

public class InteractionVisualizerTests
{
    [Fact]
    public void ExchangeCreatesLogEntry()
    {
        InteractionVisualizer.Log.Clear();
        var a = new Person("A");
        var b = new Person("B");
        InteractionSystem.Exchange(a, b, "hello");
        Assert.Single(InteractionVisualizer.Log);
        Assert.Contains("A -> B", InteractionVisualizer.Log[0]);
    }
}
