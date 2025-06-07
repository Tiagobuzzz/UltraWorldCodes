using UltraWorldAI.Magic;
using UltraWorldAI.Module16;
using Xunit;

public class PsychicMagicSystemTests
{
    [Fact]
    public void ChannelNoiseAddsChanneler()
    {
        PsychicMagicSystem.Channelers.Clear();
        MentalNoiseSystem.ThoughtStream.Clear();
        MentalNoiseSystem.EmitThought("Elira", "Culpa", 10f, "Cidade");

        PsychicMagicSystem.ChannelNoise("Elira", "Cidade", "Visão Ressonante");

        Assert.Contains(PsychicMagicSystem.Channelers, c => c.Name == "Elira");
        MentalNoiseSystem.ThoughtStream.Clear();
    }

    [Fact]
    public void CastMentalSpellConsumesPower()
    {
        PsychicMagicSystem.Channelers.Clear();
        var chan = new PsychicChanneler { Name = "Elira", Region = "Cidade", StoredPower = 10f, Style = "Visão" };
        PsychicMagicSystem.Channelers.Add(chan);

        PsychicMagicSystem.CastMentalSpell("Elira", "Explosão");

        Assert.Equal(5f, chan.StoredPower);
    }
}
