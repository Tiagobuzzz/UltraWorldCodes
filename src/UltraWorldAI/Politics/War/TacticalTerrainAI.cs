using System;
using UltraWorldAI.World;

namespace UltraWorldAI.Politics.War;

public static class TacticalTerrainAI
{
    public static string EvaluateStrategy(Army army, string terrainType, int enemySize)
    {
        string strategy = terrainType switch
        {
            "Floresta" => enemySize > army.Size ? "Emboscar e recuar" : "Atacar com cobertura",
            "Montanha" => "Defender posição elevada",
            "Planície" => army.Size > enemySize ? "Carga Frontal" : "Cercar pelas laterais",
            "Deserto" => "Ataque rápido e disperso",
            _ => "Aguardar oportunidade"
        };

        Console.WriteLine($"\U0001F9E0 Estratégia baseada no terreno ({terrainType}) e força inimiga: {strategy}");
        return strategy;
    }

    public static string EvaluateSiege(Army army, Settlement target)
    {
        return target.Population > army.Size ? "Manter cerco e cortar suprimentos" : "Invasão imediata";
    }
}
