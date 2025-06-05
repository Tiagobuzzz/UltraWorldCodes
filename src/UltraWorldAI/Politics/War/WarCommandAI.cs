using System;

namespace UltraWorldAI.Politics.War;

public enum Formation
{
    Linha,
    Coluna,
    Cercar,
    Emboscada,
    DefesaCircular
}

public static class WarCommandAI
{
    public static string Command(Army army, string terrainType)
    {
        var formation = ChooseFormation(army.CultureStyle, terrainType);
        var action = ChooseAction();
        Console.WriteLine($"\U0001F9E0 Exército de {army.Settlement} forma {formation} e decide: {action}");
        return action;
    }

    private static Formation ChooseFormation(string culture, string terrain)
    {
        return terrain switch
        {
            "Floresta" => Formation.Emboscada,
            "Montanha" => Formation.DefesaCircular,
            "Planície" when culture.Contains("Brutal") => Formation.Coluna,
            "Deserto" => Formation.Linha,
            _ => Formation.Cercar
        };
    }

    private static string ChooseAction()
    {
        var r = new Random().NextDouble();
        if (r < 0.3) return "Avançar com força total";
        if (r < 0.6) return "Posicionar e observar";
        return "Fingir retirada e emboscar";
    }
}
