using UltraWorldAI.Relationships;
using Xunit;

public class LoveImpactSystemTests
{
    [Fact]
    public void ApplyEffectAddsEffect()
    {
        LoveImpactSystem.Effects.Clear();
        LoveImpactSystem.ApplyEffect("Kael", "Saren", 0.7f, 0.3f, 0.0f, "Paixão correspondida");

        Assert.Contains(LoveImpactSystem.Effects,
            e => e.Lover == "Kael" && e.Target == "Saren" && e.Reason == "Paixão correspondida");
    }
}
