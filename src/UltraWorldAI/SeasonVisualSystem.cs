namespace UltraWorldAI;

/// <summary>
/// Handles basic season transitions for visuals.
/// </summary>
public class SeasonVisualSystem
{
    public string CurrentSeason { get; private set; } = "Spring";

    public void AdvanceSeason()
    {
        CurrentSeason = CurrentSeason switch
        {
            "Spring" => "Summer",
            "Summer" => "Autumn",
            "Autumn" => "Winter",
            _ => "Spring"
        };
    }

    public string GetVisualCue()
    {
        return CurrentSeason switch
        {
            "Spring" => "\uD83C\uDF31",
            "Summer" => "\u2600\uFE0F",
            "Autumn" => "\uD83C\uDF42",
            _ => "\u2744\uFE0F"
        };
    }
}
