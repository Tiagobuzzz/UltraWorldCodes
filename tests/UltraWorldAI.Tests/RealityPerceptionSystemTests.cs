using System.Collections.Generic;
using UltraWorldAI.Module14;
using Xunit;

public class RealityPerceptionSystemTests
{
    [Fact]
    public void RegisterPerceptionAddsProfile()
    {
        SubjectivePerceptionSystem.Perceptions.Clear();
        SubjectivePerceptionSystem.RegisterPerception(
            "Kael",
            "Desconfiado",
            "O mundo é uma ilusão",
            new Dictionary<string, string> { { "Água", "Espelho falso" } });
        Assert.Contains(SubjectivePerceptionSystem.Perceptions, p => p.Name == "Kael");
    }

    [Fact]
    public void CreateWorldStoresWorld()
    {
        InternalWorldSystem.Worlds.Clear();
        InternalWorldSystem.CreateWorld(
            "Kael",
            new List<string> { "Caverna do Medo" },
            "Olho",
            new Dictionary<string, string> { { "Sombra", "Guardião" } });
        Assert.Contains(InternalWorldSystem.Worlds, w => w.Owner == "Kael");
    }

    [Fact]
    public void RegisterVisionStoresVision()
    {
        HallucinationAndVisionSystem.Visions.Clear();
        HallucinationAndVisionSystem.RegisterVision(
            "Kael",
            "Febre",
            "Viu a morte chamando seu nome",
            true);
        Assert.Contains(HallucinationAndVisionSystem.Visions, v => v.Subject == "Kael");
    }
}
