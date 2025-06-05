using UltraWorldAI;
using Xunit;

namespace UltraWorldAI.Tests
{
    public class IdeaNetworkTests
    {
        [Fact]
        public void GenerateNewIdea_AddsIdea()
        {
            var net = new IdeaNetwork();
            var emotions = new EmotionSystem();
            var memory = new MemorySystem();
            var beliefs = new BeliefSystem();
            memory.AddMemory("um conflito ocorreu", keywords: new System.Collections.Generic.List<string>{"conflito"});
            net.GenerateNewIdea("conflito", emotions, memory, beliefs);
            Assert.True(net.Ideas.Count > 0);
            Assert.True(net.Brainwires.Count > 0);
        }
    }
}
