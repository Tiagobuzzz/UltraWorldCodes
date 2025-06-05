using System;
using System.Linq;

namespace UltraWorldAI.Thoughts
{
    public class InternalDialectics
    {
        private readonly IdeaEngine _engine;

        public InternalDialectics(IdeaEngine ideaEngine)
        {
            _engine = ideaEngine;
        }

        public string EngageDebate(string ideaATitle, string ideaBTitle)
        {
            var ideaA = _engine.GeneratedIdeas.FirstOrDefault(i => i.Title == ideaATitle);
            var ideaB = _engine.GeneratedIdeas.FirstOrDefault(i => i.Title == ideaBTitle);
            if (ideaA == null || ideaB == null)
                return "Erro: uma das ideias não existe.";

            var powerA = ideaA.EmotionalCharge + ideaA.SymbolicPower;
            var powerB = ideaB.EmotionalCharge + ideaB.SymbolicPower;

            if (Math.Abs(powerA - powerB) < 0.3f)
            {
                var newIdea = new Idea
                {
                    Title = $"Síntese_{ideaA.Title}_{ideaB.Title}",
                    Description = $"Síntese entre '{ideaA.Title}' e '{ideaB.Title}'",
                    EmotionalCharge = (ideaA.EmotionalCharge + ideaB.EmotionalCharge) / 2f,
                    SymbolicPower = (ideaA.SymbolicPower + ideaB.SymbolicPower) / 2f
                };
                _engine.GeneratedIdeas.Add(newIdea);
                return $"Nova ideia criada como síntese: {newIdea.Title}";
            }

            var winner = powerA > powerB ? ideaA : ideaB;
            winner.SymbolicPower += 0.2f;
            winner.EmotionalCharge += 0.1f;
            return $"Ideia vencedora do embate: {winner.Title}";
        }
    }
}
