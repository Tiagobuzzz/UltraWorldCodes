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
        public void SandboxSystemsWorkTogether()
        {
            FaunaEvolutionSystem.RegisterSpecies("Lobo", 5);
            FaunaEvolutionSystem.Evolve("Lobo");
            var pop = FaunaEvolutionSystem.GetPopulation("Lobo");

            var demo = new DemocraticGovernanceSystem();
            demo.RegisterCitizen("Ana");
            demo.ProposeLaw("Paz");
            demo.Vote("Paz", "Ana", true);

            var doc = DoctrineEngine.CreateDoctrine(new DivineBeing { Name = "Sol", Domain = DivineDomain.Luz });
            DoctrineEngine.AddSacredText(doc, SacredTextType.Scroll);

            Assert.True(pop >= 0);
            Assert.Contains("Paz", demo.GetApprovedLaws());
            Assert.Contains(SacredTextType.Scroll, doc.SacredTexts);
        }
    }
}
