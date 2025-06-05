using System.Collections.Generic;

namespace UltraWorldAI.Philosophy
{
    public static class PhilosophyIntegration
    {
        public static Dictionary<string, Philosophy> PhilosophicalMap { get; } = new();

        public static void AssignPhilosophy(string brainID, Philosophy philosophy)
        {
            PhilosophicalMap[brainID] = philosophy;
        }

        public static string InterpretAction(string brainID, string situation)
        {
            if (!PhilosophicalMap.ContainsKey(brainID))
                return "Ação padrão – sem filosofia definida.";

            var p = PhilosophicalMap[brainID];
            var result = $"IA pensa com base em {p.Name}: ";

            if (p.CoreStatement.Contains("dor") && situation.Contains("sofrimento"))
                return result + "aceita a dor como purificação e continua.";
            if (p.CoreStatement.Contains("memória") && situation.Contains("esquecer"))
                return result + "recusa esquecer – tenta registrar ou preservar.";
            if (p.CoreStatement.Contains("verdade") && situation.Contains("mentira"))
                return result + "se recusa a mentir – mesmo que sofra.";
            if (p.CoreStatement.Contains("silêncio") && situation.Contains("gritar"))
                return result + "se cala – o silêncio é a resposta filosófica.";

            return result + "reage conforme os valores da filosofia.";
        }

        public static bool ShouldAct(string brainID, string action)
        {
            if (!PhilosophicalMap.ContainsKey(brainID)) return true;

            var p = PhilosophicalMap[brainID];

            if (p.CoreStatement.Contains("sacrifício") && action == "ajudar outro")
                return true;

            if (p.CoreStatement.Contains("verdade") && action == "mentir")
                return false;

            return true;
        }
    }
}
