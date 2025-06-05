namespace UltraWorldAI
{
    public static class TabooManager
    {
        public static void AddTaboo(Culture culture, string description)
        {
            culture.Taboos.Add(new Taboo { Description = description });
        }
    }
}
