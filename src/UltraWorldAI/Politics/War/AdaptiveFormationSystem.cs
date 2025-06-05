using System;

namespace UltraWorldAI.Politics.War;

public static class AdaptiveFormationSystem
{
    public static string UpdateFormation(Army army, ArmyStatus status, string terrain)
    {
        if (status == null || army == null) return "Formação Desconhecida";

        if (status.Morale < 30 || status.Supplies < 30)
            return "Formação de Retirada";

        if (terrain == "Floresta" && army.Strategy.Contains("Emboscada", StringComparison.OrdinalIgnoreCase))
            return "Formação Dispersa de Camuflagem";

        if (terrain == "Montanha")
            return "Formação em Escalada Defensiva";

        if (army.Size > 1000)
            return "Formação de Cerco Total";

        return "Formação Flexível com Reconhecimento";
    }
}
