using System;
using System.Collections.Generic;

namespace UltraWorldAI.Civilization;

public static class RaceEvolutionSystem
{
    public static Dictionary<string, Func<int, string>> AgeStageMap { get; } = new()
    {
        { "Humanos", age => age < 12 ? "Criança" : age < 20 ? "Jovem" : age < 60 ? "Adulto" : "Idoso" },
        { "Elfos", age => age < 50 ? "Criança" : age < 150 ? "Jovem" : age < 900 ? "Adulto" : "Ancião" },
        { "Anões", age => age < 20 ? "Criança" : age < 60 ? "Adulto" : "Ancião" },
        { "Gigantes", age => age < 30 ? "Crescimento" : age < 80 ? "Força Máxima" : "Desgaste" },
        { "Tieflings", age => age < 15 ? "Infância Roubada" : age < 40 ? "Fluxo Instável" : "Colapso ou Transcendência" },
        { "Atlantes", age => age < 10 ? "Larva Mental" : age < 40 ? "Forma Estável" : "Silêncio Abissal" },
        { "Insectoides", age => age < 1 ? "Ninfa" : age < 3 ? "Obreiro" : "Resíduo Genético" }
    };

    public static string GetLifeStage(string race, int age)
    {
        return AgeStageMap.ContainsKey(race) ? AgeStageMap[race](age) : "Desconhecido";
    }
}
