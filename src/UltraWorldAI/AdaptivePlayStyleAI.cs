using System.Collections.Generic;
using UltraWorldAI.Game;

namespace UltraWorldAI;

/// <summary>
/// Very simple adaptive system that trains on player moves
/// using MachineLearningAdaptation.
/// </summary>
public static class AdaptivePlayStyleAI
{
    private static readonly MachineLearningAdaptation Model = new();
    private static readonly List<string> History = new();

    public static void RecordMove(string move)
    {
        History.Add(move);
        var features = new float[] { move.Length % 5, History.Count % 10 };
        Model.Train(features, 1f);
    }

    public static float PredictAggression()
    {
        var features = new float[] { 1f, History.Count % 10 };
        return Model.Predict(features);
    }
}
