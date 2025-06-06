using System.Collections.Generic;
using System.Linq;

namespace UltraWorldAI.Thoughts
{
    public class EthicalJudgment
    {
        private readonly IdeaEngine _engine;
        private readonly float _moralSensitivity;

        public EthicalJudgment(IdeaEngine ideaEngine, float sensitivity = 0.5f)
        {
            _engine = ideaEngine;
            _moralSensitivity = sensitivity;
        }

        public string JudgeAction(string actionSymbol, List<string> involvedIdeas)
        {
            float support = 0f;
            float opposition = 0f;

            foreach (var idea in _engine.GeneratedIdeas)
            {
                if (involvedIdeas.Contains(idea.Title))
                {
                    if (idea.EmotionalCharge >= _moralSensitivity)
                        support += idea.SymbolicPower;
                    else
                        opposition += idea.SymbolicPower;
                }
            }

            if (support - opposition > 0.3f)
                return $"Ação '{actionSymbol}' julgada como ÉTICA.";
            if (opposition - support > 0.3f)
                return $"Ação '{actionSymbol}' julgada como IMORAL.";
            return $"Ação '{actionSymbol}' julgada como AMBÍGUA.";
        }

        public float EvaluateMorality(string statement)
        {
            var result = JudgeAction(statement, new() { statement });
            if (result.Contains("ÉTICA")) return 1f;
            if (result.Contains("IMORAL")) return 0f;
            return 0.5f;
        }
    }
}
