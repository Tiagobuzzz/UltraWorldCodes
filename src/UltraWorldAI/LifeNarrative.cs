using System.Collections.Generic;
using System.Linq;

namespace UltraWorldAI.Thoughts
{
    public class LifeNarrative
    {
        private readonly IdeaEngine _engine;
        private readonly List<string> _narrativeFragments = new();

        public string CorePurpose { get; private set; } = "Desconhecido";
        public string SelfNarrative => string.Join(" ", _narrativeFragments);

        public LifeNarrative(IdeaEngine ideaEngine)
        {
            _engine = ideaEngine;
        }

        public void UpdateNarrative()
        {
            _narrativeFragments.Clear();
            var keyIdeas = _engine.GeneratedIdeas
                .Where(i => i.IsExpressed && (i.SymbolicPower + i.EmotionalCharge) > 1.0f)
                .OrderByDescending(i => i.SymbolicPower + i.EmotionalCharge)
                .Take(5)
                .ToList();

            foreach (var idea in keyIdeas)
            {
                _narrativeFragments.Add($"\"{idea.Title}\" moldou meu caminho.");
            }

            CorePurpose = keyIdeas.Count > 0
                ? $"Manter vivo o valor de \"{keyIdeas.First().Title}\"."
                : "Buscar sentido.";
        }
    }
}
