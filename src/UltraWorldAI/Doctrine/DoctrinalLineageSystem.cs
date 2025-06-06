namespace UltraWorldAI.Doctrine;

public record DoctrineNode(
    string Philosopher,
    string School,
    string Type,
    string Successor,
    int Year);

public static class DoctrinalLineageSystem
{
    public static List<DoctrineNode> Lineage { get; } = new();

    public static DoctrineNode AddNode(
        string philosopher,
        string school,
        string type,
        string successor,
        int year)
    {
        var node = new DoctrineNode(philosopher, school, type, successor, year);
        Lineage.Add(node);
        Console.WriteLine($"\uD83D\uDCD8 {philosopher} ({type}) \u2192 {successor} ({school}) – Ano {year}");
        return node;
    }

    public static IEnumerable<DoctrineNode> GetSuccessors(string philosopher) =>
        Lineage.Where(n => n.Philosopher == philosopher);

    public static void PrintLineage(string root)
    {
        Console.WriteLine($"\n\uD83C\uDF32 Linhagem doutrinária de {root}:\n");
        Traverse(root, 0);
    }

    private static void Traverse(string current, int indent)
    {
        foreach (var node in GetSuccessors(current))
        {
            Console.WriteLine($"{new string(' ', indent * 2)}→ {node.Successor} ({node.Type}, {node.School}, {node.Year})");
            Traverse(node.Successor, indent + 1);
        }
    }
}

