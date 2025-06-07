using UltraWorldAI.Module15;
using Xunit;

public class DynamicMusicSystemTests
{
    [Fact]
    public void CreateSongAddsSong()
    {
        DynamicMusicSystem.Songs.Clear();
        DynamicMusicSystem.CreateSong("Melodia", "Ana", "Feliz", 0.8f, 0.9f);
        Assert.Contains(DynamicMusicSystem.Songs, s => s.Title == "Melodia" && s.Composer == "Ana" && s.EmotionalState == "Feliz");
    }
}
