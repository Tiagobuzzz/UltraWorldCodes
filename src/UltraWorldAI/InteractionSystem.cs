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
    }
}
