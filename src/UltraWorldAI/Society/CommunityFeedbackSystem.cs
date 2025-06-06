using System.Collections.Generic;
using System.Linq;

namespace UltraWorldAI.Society;

/// <summary>
/// Collects community feedback and computes aggregate scores for balancing.
/// </summary>
public class CommunityFeedbackSystem
{
    private readonly Dictionary<string, List<int>> _feedback = new();

    public void Submit(string feature, int score)
    {
        if (!_feedback.TryGetValue(feature, out var list))
        {
            list = new List<int>();
            _feedback[feature] = list;
        }
        list.Add(score);
    }

    public double GetAverage(string feature)
    {
        return _feedback.TryGetValue(feature, out var list) && list.Count > 0
            ? list.Average()
            : 0.0;
    }
}
