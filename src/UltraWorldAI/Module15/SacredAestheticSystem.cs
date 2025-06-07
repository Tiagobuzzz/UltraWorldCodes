using System;
using System.Collections.Generic;

namespace UltraWorldAI.Module15;

public class SacredForm
{
    public string Culture = string.Empty;
    public string SacredStyle = string.Empty; // "Minimalismo lunar", "Ouro simbólico", "Cor apagada"
    public string Function = string.Empty; // "Ritual de passagem", "Arte devocional", "Meditação visual"
}

public static class SacredAestheticSystem
{
    public static List<SacredForm> SacredStyles { get; } = new();

    public static void AddSacredAesthetic(string culture, string style, string function)
    {
        SacredStyles.Add(new SacredForm
        {
            Culture = culture,
            SacredStyle = style,
            Function = function
        });

        Console.WriteLine($"\uD83D\uDD6F\uFE0F Estética sagrada de {culture} | Estilo: {style} | Função: {function}");
    }
}
