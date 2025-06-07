using UltraWorldAI.Module15;
using Xunit;

public class DynamicMusicSystemTests
{
    [Fact]
    public void ComposeSongAddsSong()
    {
        DynamicMusicSystem.Songs.Clear();
        DynamicMusicSystem.ComposeSong("Ana", "Melodia", "Feliz", 0.9f);
        Assert.Contains(DynamicMusicSystem.Songs, s => s.Title == "Melodia" && s.Composer == "Ana");
    }
}
