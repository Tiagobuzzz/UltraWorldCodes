using System;
using UltraWorldAI.Biology;
using UltraWorldAI.Politics;
using UltraWorldAI.Religion;
using Xunit;

namespace UltraWorldAI.Tests
{
    public class IntegrationSmokeTests
    {
        [Fact]
        public void FaunaEvolutionAndGovernance()
        {
            FaunaEvolutionSystem.RegisterSpecies("Lobo", 5);
            FaunaEvolutionSystem.Evolve("Lobo");
            var pop = FaunaEvolutionSystem.GetPopulation("Lobo");

            var demo = new DemocraticGovernanceSystem();
            demo.RegisterCitizen("Ana");
            demo.ProposeLaw("Paz");
            demo.Vote("Paz", "Ana", true);

            Assert.True(pop >= 0);
            Assert.Contains("Paz", demo.GetApprovedLaws());
        }

        [Fact]
        public void DoctrineCreationPersistsTexts()
        {
            var doc = DoctrineEngine.CreateDoctrine(new DivineBeing { Name = "Sol", Domain = DivineDomain.Luz });
            DoctrineEngine.AddSacredText(doc, SacredTextType.Scroll);
            DoctrineEngine.AddSacredText(doc, SacredTextType.Hologram);

            Assert.Contains(SacredTextType.Scroll, doc.SacredTexts);
            Assert.Contains(SacredTextType.Hologram, doc.SacredTexts);
        }
    }
}
