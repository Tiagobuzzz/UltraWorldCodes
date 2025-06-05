using System;
using System.Collections.Generic;

namespace UltraWorldAI;

public enum CalendarType
{
    Lunar,
    Solar,
    Ritmico,
    Emocional,
    Profetico
}

public class Calendar
{
    public CalendarType Type { get; }
    public List<string> Months { get; set; } = new();
    public Dictionary<int, string> NamedDays { get; } = new();

    public Calendar(CalendarType type)
    {
        Type = type;
        GenerateNamedDays();
    }

    private void GenerateNamedDays()
    {
        string prefix = Type switch
        {
            CalendarType.Lunar => "Lua de",
            CalendarType.Solar => "Sol de",
            CalendarType.Ritmico => "Pulso de",
            CalendarType.Emocional => "Sentimento de",
            CalendarType.Profetico => "Visao de",
            _ => "Dia de"
        };

        for (int i = 1; i <= 30; i++)
        {
            NamedDays[i] = $"{prefix} {GetSymbolicWord(i)}";
        }
    }

    private static string GetSymbolicWord(int seed)
    {
        string[] words =
        {
            "Cinzas", "Memoria", "Esquecimento", "Chama", "Raiz",
            "Silencio", "Eco", "Sombra", "Voz", "Ruptura",
            "Luz", "Grito", "Sopro", "Alvorada", "Queda",
            "Vento", "Sombras", "Olhar", "Ferida", "Caminho",
            "Chuva", "Lamento", "Danca", "Misterio", "Rastro",
            "Lamento", "Reflexo", "Clamor", "Fenda", "Abraco"
        };
        return words[seed % words.Length];
    }
}
