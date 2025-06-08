using System;
using System.Collections.Generic;

namespace UltraWorldAI.Religion;

public enum ProphetStatus
{
    Vivo,
    Martir,
    Venerado,
    Santo
}

public class Prophet
{
    public string Name = string.Empty;
    public string Culture = string.Empty;
    public ProphetStatus Status = ProphetStatus.Vivo;
    public int MiraclesPerformed;
    public int PersecutionLevel;
}

public static class ProphetSystem
{
    public static readonly List<Prophet> AllProphets = new();

    public static void RegisterProphet(string name, string culture)
    {
        AllProphets.Add(new Prophet { Name = name, Culture = culture });
    }

    public static void UpdateProphetStatus(Prophet prophet)
    {
        if (prophet.Status == ProphetStatus.Martir && prophet.MiraclesPerformed >= 3)
        {
            prophet.Status = ProphetStatus.Venerado;
        }
        else if (prophet.MiraclesPerformed >= 6)
        {
            prophet.Status = ProphetStatus.Santo;
        }
        else if (prophet.PersecutionLevel > 5)
        {
            prophet.Status = ProphetStatus.Martir;
        }

        Console.WriteLine($"\uD83D\uDD2E {prophet.Name} agora \u00e9 reconhecido como: {prophet.Status}");
    }
}
