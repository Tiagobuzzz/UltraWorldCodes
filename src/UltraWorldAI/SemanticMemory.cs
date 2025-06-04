using System;
using System.Collections.Generic;
using System.Linq;

namespace UltraWorldAI
{
    // Semantic memory stores durable knowledge and abstracted facts
    public class SemanticMemory
    {
        public Dictionary<string, SemanticFact> Facts { get; private set; }

        public SemanticMemory()
        {
            Facts = new Dictionary<string, SemanticFact>();
        }

        public void LearnFact(string key, string content, float confidence)
        {
            if (Facts.ContainsKey(key))
            {
                Facts[key].Reinforce(content, confidence);
            }
            else
            {
                Facts[key] = new SemanticFact(key, content, confidence);
            }
        }

        public void DecayFacts()
        {
            foreach (var fact in Facts.Values)
            {
                fact.Decay();
            }

            var forgotten = Facts.Where(f => f.Value.Confidence < 0.1f).Select(f => f.Key).ToList();
            foreach (var key in forgotten) Facts.Remove(key);
        }

        public string? Recall(string key)
        {
            return Facts.ContainsKey(key) ? Facts[key].Content : null;
        }

        public List<SemanticFact> GetStrongBeliefs(float minConfidence = 0.6f)
        {
            return Facts.Values.Where(f => f.Confidence >= minConfidence).ToList();
        }
    }

    public class SemanticFact
    {
        public string Key { get; private set; }
        public string Content { get; private set; }
        public float Confidence { get; private set; }

        public SemanticFact(string key, string content, float confidence)
        {
            Key = key;
            Content = content;
            Confidence = confidence;
        }

        public void Reinforce(string content, float confidence)
        {
            if (Content != content)
                Content = Merge(Content, content);

            Confidence = Math.Min(1f, Confidence + confidence * 0.5f);
        }

        public void Decay()
        {
            Confidence *= 0.995f;
        }

        private string Merge(string a, string b)
        {
            return a == b ? a : $"{a} / {b}";
        }
    }
}
