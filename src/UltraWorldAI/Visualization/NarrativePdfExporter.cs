using System.IO;
using System.Text;

namespace UltraWorldAI.Visualization;

public static class NarrativePdfExporter
{
    public static void Export(string narrative, string path)
    {
        var sb = new StringBuilder();
        sb.AppendLine("%PDF-1.4");
        sb.AppendLine("1 0 obj <</Type /Catalog /Pages 2 0 R>> endobj");
        sb.AppendLine("2 0 obj <</Type /Pages /Kids [3 0 R] /Count 1>> endobj");
        sb.AppendLine("3 0 obj <</Type /Page /Parent 2 0 R /MediaBox [0 0 612 792] /Contents 4 0 R /Resources <<>> >> endobj");
        var text = narrative.Replace("(", "\\(").Replace(")", "\\)");
        var stream = $"BT /F1 12 Tf 50 750 Td ({text}) Tj ET";
        sb.AppendLine($"4 0 obj <</Length {stream.Length}>> stream");
        sb.AppendLine(stream);
        sb.AppendLine("endstream endobj");
        sb.AppendLine("trailer <</Root 1 0 R>>");
        sb.AppendLine("%%EOF");
        File.WriteAllText(path, sb.ToString());
    }
}
