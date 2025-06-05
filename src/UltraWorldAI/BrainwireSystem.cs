using System;
using System.Collections.Generic;
using System.Linq;

namespace UltraWorldAI
{
    public class BrainwireSystem
    {
        public Dictionary<string, BrainNode> Nodes { get; private set; } = new();
        public List<BrainwireConnection> Connections { get; private set; } = new();

        public void RegisterNode(string label, BrainNodeType type)
        {
            if (!Nodes.ContainsKey(label))
                Nodes[label] = new BrainNode(label, type);
        }

        public void Connect(string from, string to, float strength = 0.1f)
        {
            RegisterNode(from, BrainNodeType.Concept);
            RegisterNode(to, BrainNodeType.Concept);

            var wire = new BrainwireConnection(Nodes[from], Nodes[to], strength);
            Connections.Add(wire);
        }

        public void Strengthen(string from, string to, float amount = 0.05f)
        {
            var existing = Connections.FirstOrDefault(w =>
                w.From.Label == from && w.To.Label == to);

            if (existing != null)
                existing.Strength = Math.Min(1f, existing.Strength + amount);
        }

        public List<string> GetAssociatedIdeas(string seed, float minStrength = 0.1f)
        {
            return Connections
                .Where(w => w.From.Label == seed && w.Strength >= minStrength)
                .OrderByDescending(w => w.Strength)
                .Select(w => $"{w.To.Label} ({w.Strength:F2})")
                .ToList();
        }

        public void Decay()
        {
            foreach (var wire in Connections)
                wire.Strength *= 0.995f;

            Connections.RemoveAll(w => w.Strength < 0.01f);
        }
    }

    public class BrainNode
    {
        public string Label { get; set; }
        public BrainNodeType Type { get; set; }
        public DateTime CreatedAt { get; set; }

        public BrainNode(string label, BrainNodeType type)
        {
            Label = label;
            Type = type;
            CreatedAt = DateTime.Now;
        }
    }

    public enum BrainNodeType
    {
        Concept, Emotion, Memory, Belief, Symbol
    }

    public class BrainwireConnection
    {
        public BrainNode From { get; set; }
        public BrainNode To { get; set; }
        public float Strength { get; set; }
        public int Activations { get; private set; }

        public BrainwireConnection(BrainNode from, BrainNode to, float strength)
        {
            From = from;
            To = to;
            Strength = strength;
        }

        public void Activate()
        {
            Activations++;
            Strength = Math.Min(1f, Strength + 0.01f);
        }
    }
}
