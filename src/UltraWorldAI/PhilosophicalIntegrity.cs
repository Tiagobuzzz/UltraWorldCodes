using System;
using System.Collections.Generic;
using System.Linq;

namespace UltraWorldAI.Thoughts
{
    public class PhilosophicalIntegrity
    {
        private readonly IdeaEngine _engine;

        public PhilosophicalIntegrity(IdeaEngine ideaEngine)
        {
            _engine = ideaEngine;
        }

        public float EvaluateConsistency()
        {
            float totalConflict = 0f;
            int pairs = 0;

            foreach (var wire in _engine.BrainConnections)
            {
                var ideaA = _engine.GeneratedIdeas.FirstOrDefault(i => i.Title == wire.IdeaA);
                var ideaB = _engine.GeneratedIdeas.FirstOrDefault(i => i.Title == wire.IdeaB);

                if (ideaA != null && ideaB != null)
                {
                    float logicConflict = Math.Abs(ideaA.SymbolicPower - ideaB.SymbolicPower);
                    float emotionGap = Math.Abs(ideaA.EmotionalCharge - ideaB.EmotionalCharge);
                    float contradictionWeight = (logicConflict + emotionGap) * (1f - wire.Strength);

                    wire.ConflictLevel = contradictionWeight;
                    totalConflict += contradictionWeight;
                    pairs++;
                }
            }

            return pairs == 0 ? 0f : 1f - (totalConflict / pairs);
        }

        public bool IsConsistent(float threshold = 0.8f)
        {
            return EvaluateConsistency() >= threshold;
        }

        public List<Idea> GetContradictoryIdeas(float threshold = 0.5f)
        {
            return _engine.BrainConnections
                .Where(w => w.ConflictLevel > threshold)
                .SelectMany(w => new[]
                {
                    _engine.GeneratedIdeas.FirstOrDefault(i => i.Title == w.IdeaA),
                    _engine.GeneratedIdeas.FirstOrDefault(i => i.Title == w.IdeaB)
                })
                .Where(i => i != null)
                .Distinct()
                .ToList()!;
        }
    }
}
