using System;
using System.Collections.Generic;

namespace UltraWorldAI.Religion
{
    public enum SacredTextType
    {
        Scroll,
        Tablet,
        OralTradition,
        Digital,
        Codex,
        Hologram
    }
    public class Doctrine
    {
        public string Title { get; set; } = string.Empty;
        public string OriginGod { get; set; } = string.Empty;
        public List<string> SacredRules { get; set; } = new();
        public List<SacredTextType> SacredTexts { get; set; } = new();
        public string TransmissionMethod { get; set; } = string.Empty;
        public bool IsMutable { get; set; }
        public List<string> KnownHeresies { get; } = new();
    }

    public static class DoctrineEngine
    {
        public static List<Doctrine> Doctrines { get; } = new();

        public static Doctrine CreateDoctrine(DivineBeing god)
        {
            var doctrine = new Doctrine
            {
                Title = $"Caminho de {god.Name}",
                OriginGod = god.Name,
                IsMutable = god.Temperament == DivineTemperament.Dual,
                TransmissionMethod = GetMethod(god.Domain),
                SacredRules = GenerateRules(god)
            };

            Doctrines.Add(doctrine);
            return doctrine;
        }

        private static string GetMethod(DivineDomain domain)
        {
            return domain switch
            {
                DivineDomain.Memoria => "tatuagem",
                DivineDomain.Silencio => "gesto ritual",
                DivineDomain.Tempo => "escultura em pedra",
                _ => "oral"
            };
        }

        private static List<string> GenerateRules(DivineBeing god)
        {
            var list = new List<string>();
            if (god.Domain == DivineDomain.Sangue)
            {
                list.Add("Todo ciclo deve terminar em oferenda.");
                list.Add("Nunca negar o clamor do corpo.");
            }

            if (god.Domain == DivineDomain.Memoria)
            {
                list.Add("Escreva os nomes dos mortos com lagrimas.");
            }

            if (god.Temperament == DivineTemperament.Vingativo)
            {
                list.Add("Nao perdoe o traidor. Nem em pensamento.");
            }

            return list;
        }

        public static void AddHeresy(Doctrine doctrine, string contradiction)
        {
            doctrine.KnownHeresies.Add(contradiction);
        }

        public static string DescribeDoctrine(Doctrine doctrine)
        {
            return $"\uD83D\uDCDC {doctrine.Title} – Transmissao: {doctrine.TransmissionMethod}\n" +
                   $"Regras: {string.Join(" / ", doctrine.SacredRules)}\n" +
                   $"Textos: {string.Join(" / ", doctrine.SacredTexts)}\n" +
                   $"Heresias conhecidas: {string.Join(" / ", doctrine.KnownHeresies)}";
        }

        public static void AddSacredText(Doctrine doctrine, SacredTextType textType)
        {
            if (!doctrine.SacredTexts.Contains(textType))
                doctrine.SacredTexts.Add(textType);
        }
    }
}
