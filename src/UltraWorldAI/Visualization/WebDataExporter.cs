using System.Linq;
using UnityEngine;

namespace UltraWorldAI.Visualization;

public static class WebDataExporter
{
    public static string ExportPerson(Person person)
    {
        var data = new
        {
            name = person.Name,
            stress = person.Mind.Stress.CurrentStressLevel,
            memories = person.Mind.Memory.Memories
                .Select(m => new { m.Date, m.Summary, m.Intensity })
                .ToList()
        };
        return JsonUtility.ToJson(data);
    }
}
