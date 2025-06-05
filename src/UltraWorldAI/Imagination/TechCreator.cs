using System;
using System.Collections.Generic;
using System.Linq;

namespace UltraWorldAI.Discovery
{
    public static class TechCreator
    {
        public static List<ConceptualTech> TechPool { get; } = new();

        public static ConceptualTech CreateTech(string creator, List<string> concepts, string emotion = "", string philosophy = "")
        {
            var combined = string.Join("-", concepts.OrderBy(c => c));
            string name = $"Tec-{Math.Abs(combined.GetHashCode() % 99999)}";
            string function = DeriveFunction(concepts);
            string category = ClassifyCategory(concepts);
            string complexity = ClassifyComplexity(concepts);
            string intent = TechIntentSystem.InferPurpose(concepts, emotion, philosophy);

            var tech = new ConceptualTech
            {
                Name = name,
                CreatedBy = creator,
                CombinedConcepts = concepts,
                HypotheticalFunction = $"{function} (Intenção: {intent})",
                IsFunctional = new Random().NextDouble() > 0.15,
                Complexity = complexity,
                Category = category
            };

            TechPool.Add(tech);
            return tech;
        }

        private static string DeriveFunction(List<string> concepts)
        {
            if (concepts.Contains("som") && concepts.Contains("memória"))
                return "Armazena vozes perdidas em pedra.";
            if (concepts.Contains("fogo") && concepts.Contains("ponta"))
                return "Cria luz cortante para abrir caminho.";
            if (concepts.Contains("tempo") && concepts.Contains("sombra"))
                return "Marca a passagem dos dias em forma viva.";
            return $"Combinação criativa: {string.Join(" + ", concepts)}";
        }

        private static string ClassifyComplexity(List<string> concepts)
        {
            return concepts.Count switch
            {
                <= 2 => "Simples",
                3 => "Média",
                4 => "Avançada",
                _ => "Alienígena"
            };
        }

        private static string ClassifyCategory(List<string> concepts)
        {
            if (concepts.Contains("som") || concepts.Contains("imagem")) return "Objeto Simbólico";
            if (concepts.Contains("fogo") || concepts.Contains("metal")) return "Ferramenta";
            if (concepts.Contains("tempo") || concepts.Contains("memória")) return "Estrutura";
            return "Invenção Desconhecida";
        }

        public static string Describe(ConceptualTech t)
        {
            return $"🛠️ {t.Name} ({t.Category}, {t.Complexity})\nPor: {t.CreatedBy}\n" +
                   $"Conceitos: {string.Join(", ", t.CombinedConcepts)}\nFunção: {t.HypotheticalFunction}\n" +
                   $"Estado: {(t.IsFunctional ? "✅ Funciona" : "❌ Não funcional")}";
        }

        public static string ListAll()
        {
            if (TechPool.Count == 0) return "Nenhuma tecnologia criada ainda.";
            return string.Join("\n\n", TechPool.ConvertAll(Describe));
        }
    }
}
