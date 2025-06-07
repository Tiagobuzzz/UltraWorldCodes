using System;
using System.Collections.Generic;
using System.Linq;

namespace UltraWorldAI.Knowledge;

public record MasterLink(
    string Master,
    string Student,
    string School,
    bool Heresy,
    int Year);

public static class MasterLineageSystem
{
    public static List<MasterLink> Links { get; } = new();

    public static MasterLink AddLink(
        string master,
        string student,
        string school,
        bool heresy,
        int year)
    {
        var link = new MasterLink(master, student, school, heresy, year);
        Links.Add(link);
        Console.WriteLine($"\uD83E\uDDE0 {master} \u2192 {student} ({school}) | Heresia: {heresy}");
        return link;
    }

    public static IEnumerable<MasterLink> GetStudents(string master) =>
        Links.Where(l => l.Master == master);
}
