using System.Collections.Generic;
using UltraWorldAI.Territory;

namespace UltraWorldAI
{
    public enum DivineDomain
    {
        Morte,
        Memoria,
        Fogo,
        Silencio,
        Sangue,
        Fertilidade,
        Tempo,
        Loucura,
        Reflexo
    }

    public enum DivineTemperament
    {
        Benevolente,
        Caotico,
        Vingativo,
        Silencioso,
        Dual
    }

    public class DivineBeing
    {
        public string Name { get; set; } = string.Empty;
        public DivineDomain Domain { get; set; } = DivineDomain.Fertilidade;
        public DivineTemperament Temperament { get; set; } = DivineTemperament.Benevolente;
        public string Appearance { get; set; } = string.Empty;
        public string SacredSymbol { get; set; } = string.Empty;
        public string Agenda { get; set; } = string.Empty;
        public Dictionary<string, float> Traits { get; } = new();
        public List<string> Demands { get; } = new();
        public List<string> Miracles { get; } = new();
        public bool IsActive { get; set; } = true;

        public void Inspire(Mind mind)
        {
            mind.Beliefs.UpdateBelief($"fé em {Name}", 0.2f);
            mind.Memory.AddMemory($"Sentiu a presença de {Name}", 0.6f, 0.9f, new() { "religião" }, "divino");
        }

        public void BlessRegion(string regionName)
        {
            SacredSpace.SanctifyRegion(regionName);
        }

        public string Describe()
        {
            return $"{Name}, deus(a) do {Domain} – {Temperament}.\n" +
                   $"Aparência: {Appearance}. Símbolo: {SacredSymbol}.\n" +
                   $"Exige: {string.Join(", ", Demands)}\n" +
                   $"Milagres conhecidos: {string.Join(", ", Miracles)}";
        }
    }

    public static class GodFactory
    {
        public static DivineBeing CreateGod(string name, DivineDomain domain, DivineTemperament temperament)
        {
            var god = new DivineBeing
            {
                Name = name,
                Domain = domain,
                Temperament = temperament,
                Appearance = GenerateAppearance(domain, temperament),
                SacredSymbol = GenerateSymbol(domain)
            };

            god.Demands.AddRange(GenerateDemands(domain, temperament));
            return god;
        }

        private static string GenerateAppearance(DivineDomain domain, DivineTemperament temp)
        {
            if (domain == DivineDomain.Silencio) return "Um vulto sem boca com olhos de pedra.";
            if (domain == DivineDomain.Fogo && temp == DivineTemperament.Vingativo) return "Figura flamejante com olhos vazios.";
            if (domain == DivineDomain.Reflexo) return "Espelho líquido com braços que somem.";
            return "Forma mutável e incompreensível.";
        }

        private static string GenerateSymbol(DivineDomain domain)
        {
            return domain switch
            {
                DivineDomain.Morte => "Caveira invertida",
                DivineDomain.Memoria => "Olho costurado",
                DivineDomain.Sangue => "Círculo quebrado",
                _ => "Símbolo abstrato e ritualístico"
            };
        }

        private static List<string> GenerateDemands(DivineDomain domain, DivineTemperament temp)
        {
            var list = new List<string>();
            if (domain == DivineDomain.Sangue) list.Add("Sacrifício simbólico semanal");
            if (domain == DivineDomain.Silencio) list.Add("Um minuto de silêncio absoluto por dia");
            if (temp == DivineTemperament.Dual) list.Add("Honrar opostos simultaneamente");

            return list;
        }
    }
}
