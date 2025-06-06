using System.Collections.Generic;
using System.Linq;

namespace UltraWorldAI.Health;

public static class PublicHealthAI
{
    public static List<Hospital> Hospitals { get; } = new();

    public static void RegisterHospital(string region, int capacity)
    {
        Hospitals.Add(new Hospital { Region = region, Capacity = capacity });
    }

    public static void Admit(string region, int patients)
    {
        var hospital = Hospitals.FirstOrDefault(h => h.Region == region);
        if (hospital == null) return;
        hospital.Patients = System.Math.Min(hospital.Capacity, hospital.Patients + patients);
    }

    public static int GetLoad(string region)
    {
        var hospital = Hospitals.FirstOrDefault(h => h.Region == region);
        return hospital?.Patients ?? 0;
    }
}
