using System.Collections.Generic;

namespace UltraWorldAI.Economy;

public class BlackMarketOffer
{
    public string Item { get; set; } = string.Empty;
    public int Price { get; set; }
}

public static class BlackMarketSystem
{
    private static readonly List<BlackMarketOffer> _offers = new();

    public static void AddOffer(string item, int price)
    {
        _offers.Add(new BlackMarketOffer { Item = item, Price = price });
    }

    public static List<BlackMarketOffer> ListOffers() => new(_offers);
}
