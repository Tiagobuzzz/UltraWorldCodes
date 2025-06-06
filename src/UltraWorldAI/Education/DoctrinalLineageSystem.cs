using System.Collections.Generic;
using System.Linq;

namespace UltraWorldAI.Education;

public class DoctrinalLine
{
    public string Teacher { get; set; } = string.Empty;
    public string Student { get; set; } = string.Empty;
    public string Divergence { get; set; } = string.Empty;
}

public static class DoctrinalLineageSystem
{
    public static List<DoctrinalLine> Lineages { get; } = new();

    public static void AddLineage(string teacher, string student, string divergence)
    {
        Lineages.Add(new DoctrinalLine
        {
            Teacher = teacher,
            Student = student,
            Divergence = divergence
        });
    }

    public static IEnumerable<string> GetSuccessors(string teacher) =>
        Lineages.Where(l => l.Teacher == teacher).Select(l => l.Student);
}
