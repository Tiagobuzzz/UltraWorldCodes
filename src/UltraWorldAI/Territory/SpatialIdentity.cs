namespace UltraWorldAI.Territory;

public class SpatialIdentity
{
    public string RegionName { get; private set; }
    public float X { get; private set; }
    public float Y { get; private set; }
    public bool IsSacredGround { get; private set; }
    public bool IsHostile { get; private set; }

    public SpatialIdentity(string region, float x, float y, bool sacred = false, bool hostile = false)
    {
        RegionName = region;
        X = x;
        Y = y;
        IsSacredGround = sacred;
        IsHostile = hostile;
    }

    public void MoveTo(string newRegion, float newX, float newY)
    {
        RegionName = newRegion;
        X = newX;
        Y = newY;
    }

    public override string ToString() =>
        $"Está em {RegionName} ({X},{Y}) - Sagrado: {IsSacredGround} | Hostil: {IsHostile}";
}
