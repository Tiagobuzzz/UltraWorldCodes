namespace UltraWorldAI.Politics.War;

public static class ArmyMobilizer
{
    public static int MobilizeArmy(int population)
    {
        return (int)(population * 0.2);
    }
}
