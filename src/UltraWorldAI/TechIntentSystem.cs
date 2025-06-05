using System.Collections.Generic;

namespace UltraWorldAI.Discovery;

public static class TechIntentSystem
{
    public static string InferPurpose(List<string> concepts, string emotion, string philosophy)
    {
        if (emotion.Contains("dor")) return "Causar dor ou marcar trauma";
        if (emotion.Contains("compaixao")) return "Curar ou preservar";
        if (philosophy.Contains("controle")) return "Dominar fenomenos ou mentes";
        if (concepts.Contains("imagem") || concepts.Contains("som")) return "Expressar arte ou registrar";
        if (concepts.Contains("sangue") && emotion.Contains("furia")) return "Destruicao ritual";
        return "Proposito emergente";
    }
}
