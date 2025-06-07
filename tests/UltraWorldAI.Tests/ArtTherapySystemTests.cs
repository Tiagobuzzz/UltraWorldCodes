using UltraWorldAI.Psychology;
using UltraWorldAI;
using Xunit;

public class ArtTherapySystemTests
{
    [Fact]
    public void HealRemovesEmotionBlock()
    {
        var defenses = new DefenseMechanismSystem();
        defenses.ActiveDefenses.Add("anestesia emocional");
        ArtTherapySystem.Sessions.Clear();
        ArtTherapySystem.Heal(defenses, "AI", "sorrow", "Obra");
        Assert.False(defenses.IsEmotionBlocked("sorrow"));
        Assert.Contains(ArtTherapySystem.Sessions, s => s.AIName == "AI" && s.ArtTitle == "Obra" && s.Emotion == "sorrow");
    }
}
