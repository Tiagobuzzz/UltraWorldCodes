using System;
using System.Collections.Generic;

namespace UltraWorldAI.Module13;

public class LivingMedicalDevice
{
    public string Name = string.Empty;
    public string Function = string.Empty; // "Regenera\u00e7\u00e3o", "Filtragem de veneno"
    public string Form = string.Empty; // "Vermes curativos", "L\u00edquido simb\u00f3tico"
    public bool Sentient;
}

public static class LivingMedicalTechSystem
{
    public static List<LivingMedicalDevice> Devices { get; } = new();

    public static void AddDevice(string name, string function, string form, bool sentient)
    {
        Devices.Add(new LivingMedicalDevice
        {
            Name = name,
            Function = function,
            Form = form,
            Sentient = sentient
        });

        Console.WriteLine($"\uD83E\uDDA7 Tecnologia viva: {name} | Fun\u00e7\u00e3o: {function} | Forma: {form} | Consciente? {sentient}");
    }

    public static void PrintDevices()
    {
        foreach (var d in Devices)
            Console.WriteLine($"\uD83E\uDDE2 {d.Name} | Fun\u00e7\u00e3o: {d.Function} | Forma: {d.Form} | Consciente: {d.Sentient}");
    }
}
