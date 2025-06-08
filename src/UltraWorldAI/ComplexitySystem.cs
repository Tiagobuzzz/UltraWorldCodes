using System;
using System.Linq;

namespace UltraWorldAI
{
    /// <summary>
    /// Evaluates a simple complexity score for the current mental state.
    /// </summary>
    public class ComplexitySystem
    {
        public float ComplexityScore { get; private set; }

        /// <summary>
        /// Updates the <see cref="ComplexityScore"/> based on memory count,
        /// average emotion intensity and number of beliefs.
        /// </summary>
        public void Update(Mind mind)
        {
            float memoryFactor = mind.Memory.Memories.Count / (float)AISettings.MaxMemories;
            float emotionFactor = mind.Emotions.Emotions.Any()
                ? mind.Emotions.Emotions.Values.Select(Math.Abs).Average()
                : 0f;
            float beliefFactor = mind.Beliefs.Beliefs.Count / 10f;

            ComplexityScore = Math.Clamp((memoryFactor + emotionFactor + beliefFactor) / 3f, 0f, 1f);
        }
    }
}
