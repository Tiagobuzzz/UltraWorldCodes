using System;

namespace UltraWorldAI
{
    /// <summary>
    /// Simple logistic regression to adapt AI parameters using
    /// memory features like intensity and emotional charge.
    /// </summary>
    public class MachineLearningAdaptation
    {
        private readonly float[] _weights;
        private float _bias;
        private readonly float _learningRate;

        public MachineLearningAdaptation(int featureCount = 2, float learningRate = 0.1f)
        {
            _weights = new float[featureCount];
            _bias = 0f;
            _learningRate = learningRate;
        }

        private static float Sigmoid(float x) => 1f / (1f + MathF.Exp(-x));

        /// <summary>
        /// Predicts a value between 0 and 1 for the given features.
        /// </summary>
        public float Predict(ReadOnlySpan<float> features)
        {
            float z = _bias;
            for (int i = 0; i < _weights.Length && i < features.Length; i++)
            {
                z += _weights[i] * features[i];
            }
            return Sigmoid(z);
        }

        /// <summary>
        /// Performs a single gradient descent update.
        /// </summary>
        public void Train(ReadOnlySpan<float> features, float label)
        {
            var prediction = Predict(features);
            var error = label - prediction;
            for (int i = 0; i < _weights.Length && i < features.Length; i++)
            {
                _weights[i] += _learningRate * error * features[i];
            }
            _bias += _learningRate * error;
        }

        /// <summary>
        /// Adjusts the specified personality trait based on memory features.
        /// </summary>
        public void AdaptPersonality(Person person, Memory memory, string trait)
        {
            var feats = new float[] { memory.Intensity, memory.EmotionalCharge };
            Train(feats, 1f);
            var result = Predict(feats);
            var delta = result - 0.5f;
            if (Math.Abs(delta) < 0.01f)
                delta = memory.EmotionalCharge * 0.02f;
            person.Mind.Personality.AdjustTrait(trait, delta * 0.1f);
        }
    }
}
