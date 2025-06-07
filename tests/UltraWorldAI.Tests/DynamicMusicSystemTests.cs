using UltraWorldAI.Module15;
using UltraWorldAI.World;
using UltraWorldAI;
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

    [Fact]
    public void ApplySongChangesMoods()
    {
        DynamicMusicSystem.Songs.Clear();
        var song = new Song { Title = "Tristeza", Composer = "B", EmotionalState = "Triste" };
        DynamicMusicSystem.Songs.Add(song);
        var city = new UltraWorldAI.World.Settlement { Name = "Lira" };
        var god = new DivineBeing { Name = "Lumina" };

        DynamicMusicSystem.ApplyToCity(song, city);
        DynamicMusicSystem.ApplyToGod(song, god);

        Assert.Equal("Triste", city.Mood);
        Assert.Equal("Triste", god.Mood);
    }
}
