using UltraWorldAI.Module15;
using Xunit;

public class ForbiddenArtSystemTests
{
    [Fact]
    public void AddForbiddenWorkRegistersWork()
    {
        ForbiddenArtSystem.Works.Clear();
        ForbiddenArtSystem.AddForbiddenWork("Eco", "Anon", "Perigosa", true, "Ruínas");
        Assert.Contains(ForbiddenArtSystem.Works, w => w.Title == "Eco" && w.Creator == "Anon" && w.Reason == "Perigosa" && w.StillExists && w.Location == "Ruínas");
    }
}
