namespace UltraWorldAI
{
    public static class TraditionEngine
    {
        public static Tradition CreateBasicTradition(string inspiration)
        {
            return new Tradition
            {
                Name = $"Tradicao {inspiration}",
                Purpose = "coesao",
                OriginStory = inspiration
            };
        }
    }
}
