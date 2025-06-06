using UltraWorldAI.Language;
using Xunit;

public class MagicAccessWordSystemTests
{
    [Fact]
    public void UseWordReturnsTrueWhenRegistered()
    {
        MagicAccessWordSystem.Words.Clear();
        MagicAccessWordSystem.RegisterWord("abra","porta");
        Assert.True(MagicAccessWordSystem.UseWord("abra","porta"));
    }
}
