using System.Collections.Generic;
using UltraWorldAI.Patching;
using Xunit;

public class PatchGeneratorTests
{
    [Fact]
    public void GenerateCreatesPatchWithNotes()
    {
        var patch = PatchGenerator.Generate("1.0", "1.1", new List<string>{"fix"});
        Assert.Equal("1.0->1.1", patch.Version);
        Assert.Contains("fix", patch.Notes);
    }
}
