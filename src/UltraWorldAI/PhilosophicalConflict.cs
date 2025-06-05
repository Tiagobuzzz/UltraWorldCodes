using System.Collections.Generic;

namespace UltraWorldAI.Philosophy
{
    public class PhilosophicalClash
    {
        public Philosophy A { get; set; } = null!;
        public Philosophy B { get; set; } = null!;
        public string Reason { get; set; } = string.Empty;
        public string Outcome { get; set; } = string.Empty;
        public bool IsResolved { get; set; }
    }

    public static class PhilosophicalConflict
    {
        public static List<PhilosophicalClash> Clashes { get; } = new();

        public static PhilosophicalClash StartClash(Philosophy a, Philosophy b, string reason)
        {
            var clash = new PhilosophicalClash
            {
                A = a,
                B = b,
                Reason = reason,
                IsResolved = false
            };

            Clashes.Add(clash);
            return clash;
        }

        public static void ResolveClash(PhilosophicalClash clash)
        {
            if (clash.A.InfluenceLevel > clash.B.InfluenceLevel)
            {
                clash.Outcome = $"{clash.A.Name} prevaleceu sobre {clash.B.Name}.";
                clash.B.InfluenceLevel -= 0.2f;
            }
            else if (clash.B.InfluenceLevel > clash.A.InfluenceLevel)
            {
                clash.Outcome = $"{clash.B.Name} eclipsou {clash.A.Name}.";
                clash.A.InfluenceLevel -= 0.2f;
            }
            else
            {
                clash.Outcome = "O conflito gerou uma fusão filosófica.";
                clash.A.DerivedBeliefs.AddRange(clash.B.DerivedBeliefs);
                clash.B.DerivedBeliefs.AddRange(clash.A.DerivedBeliefs);
            }

            clash.IsResolved = true;
        }

        public static string DescribeClash(PhilosophicalClash clash)
        {
            return $"⚖️ Conflito: {clash.A.Name} vs {clash.B.Name}\n" +
                   $"Motivo: {clash.Reason}\n" +
                   $"Resultado: {(clash.IsResolved ? clash.Outcome : "Ainda em tensão...")}";
        }

        public static string ListAll()
        {
            return Clashes.Count == 0
                ? "Nenhum conflito filosófico registrado."
                : string.Join("\n\n", Clashes.ConvertAll(DescribeClash));
        }
    }
}
