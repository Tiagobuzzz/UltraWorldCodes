using System;
using System.Collections.Generic;
using System.Linq;

namespace UltraWorldAI
{
    public class PersonalSymbol
    {
        public string Motif { get; set; } = string.Empty;
        public string Meaning { get; set; } = string.Empty;
        public string Origin { get; set; } = string.Empty;
    }

    public class SymbolicExpressionSystem
    {
        private static readonly Random _random = new();
        private static readonly string[] BaseMotifs =
            { "fogo", "espelho", "água", "caverna", "asas", "chave", "máscara", "sombra" };

        public List<PersonalSymbol> Symbols { get; } = new();

        public void GenerateSymbolFromExperience(Person person)
        {
            var dominantEmotion = person.Mind.Emotions.GetDominantEmotion();
            var dominantSub = person.Mind.Subvoices.GetDominantVoice().Name;
            var recentExperiences = person.Mind.Memory.Memories
                .OrderByDescending(m => m.Date)
                .Take(3)
                .Select(m => m.Summary)
                .ToList();

            string motif = BaseMotifs[_random.Next(BaseMotifs.Length)];
            string meaning = $"Representa {dominantEmotion}, influência de {dominantSub}, " +
                             $"eco de vivências como {string.Join(", ", recentExperiences)}";

            Symbols.Add(new PersonalSymbol
            {
                Motif = motif,
                Meaning = meaning,
                Origin = $"Criado por {person.Name} após autorreflexão"
            });

            person.Mind.Memory.AddMemory($"Criou símbolo: {motif}", 0.3f, 0f,
                new() { "SímboloPessoal" }, "self");
        }

        public List<string> GetSymbolicLexicon()
        {
            return Symbols.Select(s => $"{s.Motif}: {s.Meaning}").ToList();
        }
    }
}
