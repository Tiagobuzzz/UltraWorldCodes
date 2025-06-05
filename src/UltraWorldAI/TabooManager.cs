namespace UltraWorldAI
{
    public static class TabooManager
    {
        public static void AddTaboo(Culture culture, string taboo)
        {
            if (!culture.Taboos.Contains(taboo))
                culture.Taboos.Add(taboo);
        }

        public static void MutateTaboos(Culture culture)
        {
            for (int i = 0; i < culture.Taboos.Count; i++)
            {
                var original = culture.Taboos[i];
                if (original.Contains("nome"))
                {
                    culture.Taboos[i] = original.Replace("nome", "eco de identidade");
                }
            }

            if (!culture.Taboos.Contains("Tocar o silêncio ritual"))
                culture.Taboos.Add("Tocar o silêncio ritual");
        }

        public static string DescribeTaboos(Culture culture)
        {
            return $"A cultura {culture.Name} considera tabus: {string.Join(", ", culture.Taboos)}";
        }
    }
}
