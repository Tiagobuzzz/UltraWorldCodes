using System;
using System.Collections.Generic;

namespace UltraWorldAI.Discovery
{
    public class DiscoveryEvent
    {
        public string DiscoveryName { get; set; } = string.Empty;
        public string CreatedBy { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public string OriginEmotion { get; set; } = string.Empty;
        public string Context { get; set; } = string.Empty;
        public DateTime Date { get; set; }
    }

    public static class DiscoveryHistory
    {
        public static List<DiscoveryEvent> Log { get; } = new();

        public static void Register(string name, string by, string type, string emotion, string context)
        {
            Log.Add(new DiscoveryEvent
            {
                DiscoveryName = name,
                CreatedBy = by,
                Type = type,
                OriginEmotion = emotion,
                Context = context,
                Date = DateTime.Now
            });
        }

        public static string DescribeAll()
        {
            if (Log.Count == 0) return "Nada foi registrado na história do saber.";
            return string.Join("\n\n", Log.ConvertAll(e =>
                $"📚 {e.DiscoveryName} ({e.Type})\nPor: {e.CreatedBy} em {e.Date.ToShortDateString()}\n" +
                $"Motivo emocional: {e.OriginEmotion}\nContexto: {e.Context}"));
        }
    }
}
