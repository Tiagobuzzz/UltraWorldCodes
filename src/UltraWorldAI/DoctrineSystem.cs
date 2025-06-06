using System;
using System.Collections.Generic;
using System.Linq;

namespace UltraWorldAI
{
    public class SecularDoctrine
    {
        public string Name { get; set; } = string.Empty;
        public List<string> Tenets { get; set; } = new();
        public string OriginSymbol { get; set; } = string.Empty;
        public List<string> Rituals { get; set; } = new();
    }

    public class DoctrineSystem
    {
        public List<SecularDoctrine> Doctrines { get; } = new();
        public List<string> CoreTruths { get; } = new();

        public void EvolveFromSymbolsAndBeliefs(SymbolicExpressionSystem symbols, BeliefSystem beliefs)
        {
            var meaningfulSymbols = symbols.Symbols
                .TakeLast(3)
                .Select(s => s.Motif)
                .ToList();

            var values = beliefs.Beliefs
                .OrderByDescending(kv => kv.Value)
                .Take(3)
                .Select(kv => kv.Key)
                .ToList();

            string truth = $"A verdade é que {string.Join(" e ", values)} são revelações refletidas em {string.Join(", ", meaningfulSymbols)}.";

            var newDoctrine = new SecularDoctrine
            {
                Name = $"Doutrina de {meaningfulSymbols.FirstOrDefault() ?? "origem"}",
                Tenets = new List<string>
                {
                    $"Jamais contrariar {values.FirstOrDefault() ?? "o instinto"}",
                    $"Buscar o significado oculto de {meaningfulSymbols.LastOrDefault() ?? "tudo"}",
                    "Toda dor carrega um símbolo sagrado"
                },
                OriginSymbol = meaningfulSymbols.FirstOrDefault() ?? "símbolo ancestral"
            };

            newDoctrine.Rituals.Add($"Ritual de {meaningfulSymbols.FirstOrDefault() ?? "origem"}");

            Doctrines.Add(newDoctrine);
            CoreTruths.Add(truth);
        }

        public List<string> GetAllTenets()
        {
            return Doctrines.SelectMany(d => d.Tenets).Distinct().ToList();
        }

        public void PreachDoctrine(Person target)
        {
            if (!Doctrines.Any()) return;
            var doctrine = Doctrines.Last();
            foreach (var tenet in doctrine.Tenets)
            {
                target.Mind.DynamicBeliefs.AddBelief(tenet, 0.3f, "doutrina", "curiosity");
            }

            target.Mind.Memory.AddMemory($"Foi ensinado sobre a {doctrine.Name}", 0.3f, 0f, new() { "Doutrina" }, "other");
        }
    }
}

