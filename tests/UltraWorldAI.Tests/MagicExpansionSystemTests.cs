using UltraWorldAI.Magic;
using Xunit;
using System.Collections.Generic;

public class MagicExpansionSystemTests
{
    [Fact]
    public void RegisterRitualStoresRitual()
    {
        RitualMagicSystem.Rituals.Clear();
        RitualMagicSystem.RegisterRitual("Evocacao", new List<string> { "Sangue" }, "Espiral", "Invocar");
        Assert.Contains(RitualMagicSystem.Rituals, r => r.Name == "Evocacao");
    }

    [Fact]
    public void CreateEmotionSpellAddsSpell()
    {
        EmotionalMagicSystem.Spells.Clear();
        EmotionalMagicSystem.CreateEmotionSpell("Raiva", "Fogo", "Explosao");
        Assert.Contains(EmotionalMagicSystem.Spells, s => s.Emotion == "Raiva");
    }

    [Fact]
    public void RegisterBloodlineAddsBloodline()
    {
        ArcaneBloodlineSystem.Bloodlines.Clear();
        ArcaneBloodlineSystem.RegisterBloodline("Solar", "Sol", new List<string> { "Luz" }, 80);
        Assert.Contains(ArcaneBloodlineSystem.Bloodlines, b => b.Name == "Solar");
    }

    [Fact]
    public void CreateGrimoireStoresGrimoire()
    {
        LivingGrimoireSystem.Grimoires.Clear();
        LivingGrimoireSystem.CreateGrimoire("Codex", true, new List<string> { "Noct" }, "Sussurra");
        Assert.Contains(LivingGrimoireSystem.Grimoires, g => g.Title == "Codex");
    }
}
