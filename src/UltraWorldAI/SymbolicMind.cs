using System;
using System.Collections.Generic;

namespace UltraWorldAI
{
    public class MentalSymbol
    {
        public string Archetype { get; set; } = string.Empty;
        public string Meaning { get; set; } = string.Empty;
        public string EmotionLinked { get; set; } = string.Empty;
        public float Intensity { get; set; }
        public DateTime CreatedAt { get; set; }
    }

    public class SymbolicMind
    {
        public List<MentalSymbol> ActiveSymbols { get; } = new();

        public void GenerateFromEmotion(EmotionSystem emotions)
        {
            var dominant = emotions.GetDominantEmotion();
            var symbol = PickSymbolForEmotion(dominant);
            var meaning = MapEmotionToMeaning(dominant);

            ActiveSymbols.Add(new MentalSymbol
            {
                Archetype = symbol,
                Meaning = meaning,
                EmotionLinked = dominant,
                Intensity = emotions.GetEmotion(dominant),
                CreatedAt = DateTime.Now
            });

            if (ActiveSymbols.Count > 10)
                ActiveSymbols.RemoveAt(0);
        }

        public void IntegrateSymbolicMeaning(BeliefArchitecture beliefs)
        {
            foreach (var symbol in ActiveSymbols)
            {
                if (symbol.Intensity > 0.6f)
                {
                    beliefs.AddBelief($"A vida é como um(a) {symbol.Archetype}",
                        0.4f, "metáfora interna", symbol.EmotionLinked);
                }
            }
        }

        public void DecaySymbols()
        {
            foreach (var sym in ActiveSymbols)
                sym.Intensity *= 0.99f;

            ActiveSymbols.RemoveAll(s => s.Intensity < 0.1f);
        }

        /// <summary>
        /// Converts active symbols to a simple procedural representation.
        /// </summary>
        /// <returns>A multi-line string describing each symbol.</returns>
        public string ToProceduralScript()
        {
            var lines = new List<string>();
            foreach (var symbol in ActiveSymbols)
            {
                lines.Add($"SYMBOL {symbol.Archetype.ToUpperInvariant()} MEANS {symbol.Meaning.ToUpperInvariant()};");
            }
            return string.Join("\n", lines);
        }

        private static string PickSymbolForEmotion(string emotion)
        {
            return emotion switch
            {
                "sorrow" => "chuva",
                "anger" => "fogo",
                "fear" => "abismo",
                "love" => "luz",
                "happiness" => "jardim",
                _ => "neblina"
            };
        }

        private static string MapEmotionToMeaning(string emotion)
        {
            return emotion switch
            {
                "sorrow" => "perda",
                "anger" => "violacao",
                "fear" => "desconhecido",
                "love" => "conexao",
                "happiness" => "plenitude",
                _ => "confusao"
            };
        }
    }
}
