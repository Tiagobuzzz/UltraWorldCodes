using UltraWorldAI.Literature;
using Xunit;

public class LostLibrarySystemTests
{
    [Fact]
    public void MarkLostSetsFlag()
    {
        LostLibrarySystem.Libraries.Clear();
        LostLibrarySystem.AddLibrary("Arcana", true, "Runas");
        LostLibrarySystem.MarkLost("Arcana");
        Assert.True(LostLibrarySystem.Libraries[0].IsLost);
    }
}
