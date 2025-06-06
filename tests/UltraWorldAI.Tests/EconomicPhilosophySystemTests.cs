using System.Collections.Generic;
using UltraWorldAI.Economy;
using Xunit;

public class EconomicPhilosophySystemTests
{
    [Fact]
    public void CreateSchoolAddsSchool()
    {
        EconomicPhilosophySystem.Schools.Clear();
        EconomicPhilosophySystem.CreateSchool(
            "Troca Justa",
            "Kael",
            "Aurora",
            1235,
            new List<string> { "Valor reflete esforço" },
            new List<string> { "Regular preços" });

        Assert.Single(EconomicPhilosophySystem.Schools);
        var school = EconomicPhilosophySystem.Schools[0];
        Assert.Equal("Troca Justa", school.Name);
        Assert.Contains("Regular preços", school.PreferredActions);
    }

    [Fact]
    public void GetSuggestionsReturnsPreferredActions()
    {
        EconomicPhilosophySystem.Schools.Clear();
        EconomicPhilosophySystem.CreateSchool(
            "Acumulação Sagrada",
            "Zor'mak",
            "Umbra",
            1241,
            new List<string> { "Riqueza é sinal divino" },
            new List<string> { "Tributar templos rivais" });

        var suggestions = EconomicPhilosophySystem.GetSuggestionsForAI("Acumulação Sagrada");
        Assert.Contains("Tributar templos rivais", suggestions);
    }
}
