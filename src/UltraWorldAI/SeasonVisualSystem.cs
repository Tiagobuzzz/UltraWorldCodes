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
}
