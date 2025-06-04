using System;
using System.Collections.Generic;
using System.Linq;

namespace UltraWorldAI
{
    public class EmotionSystem
    {
        public Dictionary<string, float> Emotions { get; private set; } = new Dictionary<string, float>();

        public EmotionSystem()
        {
            Emotions.Add("happiness", 0.5f);
            Emotions.Add("fear", 0.2f);
            Emotions.Add("anger", 0.1f);
            Emotions.Add("love", 0.3f);
            Emotions.Add("sorrow", 0.1f);
            Emotions.Add("curiosity", 0.4f);
        }

        public string GetDominantEmotion()
        {
            if (!Emotions.Any()) return "neutral";
            return Emotions.OrderByDescending(e => e.Value).FirstOrDefault().Key;
        }

        public float GetEmotion(string emotionName)
        {
            return Emotions.TryGetValue(emotionName, out float value) ? value : 0f;
        }

        public void SetEmotion(string emotionName, float value)
        {
            Emotions[emotionName] = Math.Clamp(value, AIConfig.EmotionMin, AIConfig.EmotionMax);
        }

        public void UpdateEmotionsDecay()
        {
            foreach (var key in Emotions.Keys.ToList())
            {
                float decayRate = key switch
                {
                    "happiness" => AIConfig.EmotionDecayHappiness,
                    "fear" => AIConfig.EmotionDecayFear,
                    "anger" => AIConfig.EmotionDecayAnger,
                    "love" => AIConfig.EmotionDecayLove,
                    "sorrow" => AIConfig.EmotionDecaySorrow,
                    "curiosity" => AIConfig.EmotionDecayCuriosity,
                    _ => 0f
                };
                SetEmotion(key, Emotions[key] + decayRate);
            }
        }
    }
}
