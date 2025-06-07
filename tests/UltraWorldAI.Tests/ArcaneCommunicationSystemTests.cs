using UltraWorldAI.Magic;
using Xunit;

public class ArcaneCommunicationSystemTests
{
    [Fact]
    public void SendAddsMessage()
    {
        ArcaneCommunicationSystem.Messages.Clear();
        ArcaneCommunicationSystem.Send("A", "B", "msg");
        Assert.Single(ArcaneCommunicationSystem.Messages);
    }

    [Fact]
    public void SendPropheticVisionSetsFlag()
    {
        ArcaneCommunicationSystem.Messages.Clear();
        ArcaneCommunicationSystem.SendPropheticVision("A", "B", "vision");
        var message = Assert.Single(ArcaneCommunicationSystem.Messages);
        Assert.True(message.IsProphetic);
    }
}
