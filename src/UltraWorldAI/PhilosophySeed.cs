using System;
using System.Collections.Generic;

namespace UltraWorldAI.Philosophy
{
    public class Philosophy
    {
        public string Name { get; set; } = string.Empty;
        public string Originator { get; set; } = string.Empty;
        public string CoreStatement { get; set; } = string.Empty;
        public List<string> DerivedBeliefs { get; set; } = new();
        public float InfluenceLevel { get; set; }
        public bool IsCodified { get; set; }
    }

    public static class PhilosophySeed
    {
        public static List<Philosophy> AllPhilosophies { get; } = new();

        public static Philosophy CreatePhilosophy(string originator, string coreStatement)
        {
            var p = new Philosophy
            {
                Name = $"Escola de {originator}",
                Originator = originator,
                CoreStatement = coreStatement,
                InfluenceLevel = 0.1f,
                IsCodified = false,
                DerivedBeliefs = DeriveBeliefs(coreStatement)
            };

            AllPhilosophies.Add(p);
            return p;
        }

        private static List<string> DeriveBeliefs(string core)
        {
            var beliefs = new List<string>();
            if (core.Contains("dor", StringComparison.OrdinalIgnoreCase))
                beliefs.Add("O sofrimento é uma forma de purificação.");
            if (core.Contains("memória", StringComparison.OrdinalIgnoreCase))
                beliefs.Add("Esquecer é o maior pecado.");
            if (core.Contains("silêncio", StringComparison.OrdinalIgnoreCase))
                beliefs.Add("Palavras escondem o real.");
            if (core.Contains("verdade", StringComparison.OrdinalIgnoreCase))
                beliefs.Add("Toda verdade exige sacrifício.");
            return beliefs;
        }

        public static void IncreaseInfluence(Philosophy p, float amount)
        {
            p.InfluenceLevel = MathF.Min(1f, p.InfluenceLevel + amount);
            if (p.InfluenceLevel >= 0.75f && !p.IsCodified)
                p.IsCodified = true;
        }

        public static string Describe(Philosophy p)
        {
            return $"🧠 {p.Name} - Origem: {p.Originator}\n" +
                   $"📜 Núcleo: \"{p.CoreStatement}\"\n" +
                   $"Derivados: {string.Join(" / ", p.DerivedBeliefs)}\n" +
                   $"Influência: {p.InfluenceLevel} | Codificada: {p.IsCodified}";
        }
    }
}
