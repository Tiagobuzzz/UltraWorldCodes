using System.Collections.Generic;

namespace UltraWorldAI
{
    public static class InteractionSystem
    {
        public static void Exchange(Person from, Person to, string information, float influence = 0.1f)
        {
            to.AddExperience($"{from.Name} disse: {information}", 0.4f, 0f, new List<string> { from.Name }, from.Name);
            to.Mind.Beliefs.UpdateBelief(information, influence);
            var curiosity = to.Mind.Emotions.GetEmotion("curiosity");
            to.Mind.Emotions.SetEmotion("curiosity", curiosity + influence);
            to.Mind.IdeaNet.GenerateNewIdea(from.Name, to.Mind.Emotions, to.Mind.Memory, to.Mind.Beliefs);
        }

        public static void ComplexDialogue(Person a, Person b, List<string> lines)
        {
            for (int i = 0; i < lines.Count; i++)
            {
                var speaker = i % 2 == 0 ? a : b;
                var listener = i % 2 == 0 ? b : a;
                Exchange(speaker, listener, lines[i], 0.2f);
                DecisionLogger.LogDecision(speaker.Name, $"Spoke: '{lines[i]}'");
            }
        }

        public static void BranchingDialogue(Person a, Person b,
            Dictionary<int, List<string>> branches, System.Func<Person, int, int> selector)
        {
            int branch = 0;
            while (branches.ContainsKey(branch))
            {
                var lines = branches[branch];
                ComplexDialogue(a, b, lines);
                branch = selector(a, branch);
            }
        }
    }
}
