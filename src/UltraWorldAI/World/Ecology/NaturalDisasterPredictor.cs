using System;

namespace UltraWorldAI.World.Ecology;

/// <summary>
/// Minimal logistic regression model to estimate probability of natural disasters.
/// Features might be simplified weather metrics.
/// </summary>
public class NaturalDisasterPredictor
{
    private readonly float[] _weights;
    private float _bias;
    private readonly float _learningRate;

    public NaturalDisasterPredictor(int featureCount = 3, float learningRate = 0.05f)
    {
        _weights = new float[featureCount];
        _bias = 0f;
        _learningRate = learningRate;
    }

    private static float Sigmoid(float x) => 1f / (1f + MathF.Exp(-x));

    public float Predict(ReadOnlySpan<float> features)
    {
        float z = _bias;
        for (int i = 0; i < _weights.Length && i < features.Length; i++)
            z += _weights[i] * features[i];
        return Sigmoid(z);
    }

    public void Train(ReadOnlySpan<float> features, float label)
    {
        var prediction = Predict(features);
        var error = label - prediction;
        for (int i = 0; i < _weights.Length && i < features.Length; i++)
            _weights[i] += _learningRate * error * features[i];
        _bias += _learningRate * error;
    }
}
