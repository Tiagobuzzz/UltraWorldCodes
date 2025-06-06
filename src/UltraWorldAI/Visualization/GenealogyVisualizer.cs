using System.Text;
using UltraWorldAI.Civilization;

namespace UltraWorldAI.Visualization;

/// <summary>
/// Helper for printing genealogy trees.
/// </summary>
public static class GenealogyVisualizer
{
    public static string Render(GenealogyNode root)
    {
        var sb = new StringBuilder();
        Traverse(root, 0, sb);
        return sb.ToString();
    }

    private static void Traverse(GenealogyNode node, int indent, StringBuilder sb)
    {
        sb.AppendLine($"{new string(' ', indent * 2)}- {node.Name}");
        foreach (var child in node.Descendants)
        {
            Traverse(child, indent + 1, sb);
        }
    }
}
