using System.Threading.Tasks;
using UltraWorldAI.Dialogue;
using Xunit;

public class AIDialogueSystemTests
{
    [Fact]
    public async Task GenerateDialogueReturnsText()
    {
        var text = await AIDialogueSystem.GenerateDialogueAsync("Ola");
        Assert.False(string.IsNullOrWhiteSpace(text));
    }
}
