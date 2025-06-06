using System;

namespace UltraWorldAI.Language;

/// <summary>
/// Minimal feed-forward neural network for language learning experiments.
/// </summary>
public class NeuralLanguageLearner
{
    private readonly int _inputSize;
    private readonly int _hiddenSize;
    private readonly float[,] _w1;
    private readonly float[] _w2;
    private readonly float _learningRate;
    private readonly Random _rand = new();

    public NeuralLanguageLearner(int inputSize = 5, int hiddenSize = 3, float learningRate = 0.1f)
    {
        _inputSize = inputSize;
        _hiddenSize = hiddenSize;
        _learningRate = learningRate;
        _w1 = new float[inputSize, hiddenSize];
        _w2 = new float[hiddenSize];
        for (int i = 0; i < inputSize; i++)
            for (int j = 0; j < hiddenSize; j++)
                _w1[i, j] = (float)(_rand.NextDouble() - 0.5);
        for (int j = 0; j < hiddenSize; j++)
            _w2[j] = (float)(_rand.NextDouble() - 0.5);
    }

    private static float Sigmoid(float x) => 1f / (1f + MathF.Exp(-x));

    public float Predict(ReadOnlySpan<float> input)
    {
        Span<float> hidden = stackalloc float[_hiddenSize];
        for (int j = 0; j < _hiddenSize; j++)
        {
            float sum = 0f;
            for (int i = 0; i < _inputSize && i < input.Length; i++)
                sum += input[i] * _w1[i, j];
            hidden[j] = Sigmoid(sum);
        }
        float output = 0f;
        for (int j = 0; j < _hiddenSize; j++)
            output += hidden[j] * _w2[j];
        return Sigmoid(output);
    }

    public void Train(ReadOnlySpan<float> input, float label)
    {
        Span<float> hidden = stackalloc float[_hiddenSize];
        for (int j = 0; j < _hiddenSize; j++)
        {
            float sum = 0f;
            for (int i = 0; i < _inputSize && i < input.Length; i++)
                sum += input[i] * _w1[i, j];
            hidden[j] = Sigmoid(sum);
        }
        float output = 0f;
        for (int j = 0; j < _hiddenSize; j++)
            output += hidden[j] * _w2[j];
        float prediction = Sigmoid(output);
        float error = label - prediction;

        for (int j = 0; j < _hiddenSize; j++)
        {
            float dw2 = error * hidden[j];
            _w2[j] += _learningRate * dw2;
        }

        for (int i = 0; i < _inputSize && i < input.Length; i++)
        {
            for (int j = 0; j < _hiddenSize; j++)
            {
                float activation = hidden[j] * (1 - hidden[j]);
                float dw1 = error * _w2[j] * activation * input[i];
                _w1[i, j] += _learningRate * dw1;
            }
        }
    }
}

