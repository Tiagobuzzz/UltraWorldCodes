using System.Linq;
using UltraWorldAI;
using Xunit;

namespace UltraWorldAI.Tests
{
    public class MemorySystemTests
    {
        [Fact]
        public void AddMemory_IncreasesCount()
        {
            var mem = new MemorySystem();
            mem.AddMemory("teste");
            Assert.Equal(1, mem.Memories.Count);
        }

        [Fact]
        public void RetrieveMemories_ReturnsMostRelevant()
        {
            var mem = new MemorySystem();
            mem.AddMemory("algo sobre gatos", keywords: new System.Collections.Generic.List<string> { "gato" }, intensity: 0.8f);
            mem.AddMemory("cachorros sao legais", keywords: new System.Collections.Generic.List<string> { "cachorro" }, intensity: 0.2f);
            var result = mem.RetrieveMemories("gato").First();
            Assert.Contains("gatos", result.Summary);
        }
    }
}
