using UltraWorldAI.Religion;
using Xunit;

public class PsychicCultSystemTests
{
    [Fact]
    public void CreateCultAddsCult()
    {
        PsychicCultSystem.Cults.Clear();
        var cult = PsychicCultSystem.CreateCult("Eco", "Iluminação do Vazio");

        Assert.Single(PsychicCultSystem.Cults);
        Assert.Equal("Ordem de Eco", cult.Name);
        PsychicCultSystem.Cults.Clear();
    }

    [Fact]
    public void JoinAndLeaveCultUpdatesFollowers()
    {
        PsychicCultSystem.Cults.Clear();
        PsychicCultSystem.CreateCult("Eco", "Silêncio Mental");
        PsychicCultSystem.JoinCult("Thalor", "Eco");
        PsychicCultSystem.LeaveCult("Thalor", "Eco");

        var cult = PsychicCultSystem.Cults[0];
        Assert.Empty(cult.Followers);
        PsychicCultSystem.Cults.Clear();
    }
}
