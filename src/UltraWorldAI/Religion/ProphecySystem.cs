using System.Collections.Generic;

namespace UltraWorldAI.Religion
{
    public class Prophecy
    {
        public string Title { get; set; } = string.Empty;
        public string Trigger { get; set; } = string.Empty;
        public string PredictedEvent { get; set; } = string.Empty;
        public bool IsFulfilled { get; set; }
        public bool IsCorrupted { get; set; }
        public string Origin { get; set; } = string.Empty;
        public string Transmission { get; set; } = string.Empty;

        public string Describe()
        {
            var status = IsFulfilled ? "Cumprida" : IsCorrupted ? "Corrompida" : "Em aberto";
            return $"\uD83D\uDD2E Profecia: {Title}\n" +
                   $"Origem: {Origin} / Via: {Transmission}\n" +
                   $"Gatilho: {Trigger}\n" +
                   $"Evento previsto: {PredictedEvent}\n" +
                   $"Status: {status}";
        }
    }

    public static class ProphecySystem
    {
        private static readonly List<Prophecy> _prophecies = new();
        public static IReadOnlyList<Prophecy> AllProphecies => _prophecies;

        public static Prophecy Create(string title, string origin, string transmission, string trigger, string prediction)
        {
            var prophecy = new Prophecy
            {
                Title = title,
                Origin = origin,
                Transmission = transmission,
                Trigger = trigger,
                PredictedEvent = prediction
            };

            _prophecies.Add(prophecy);
            return prophecy;
        }

        public static void Fulfill(string title)
        {
            var p = _prophecies.Find(prophecy => prophecy.Title == title);
            if (p != null) p.IsFulfilled = true;
        }

        public static void Corrupt(string title)
        {
            var p = _prophecies.Find(prophecy => prophecy.Title == title);
            if (p != null) p.IsCorrupted = true;
        }

        public static string DescribeAll()
        {
            if (_prophecies.Count == 0) return "Nenhuma profecia conhecida.";
            return string.Join("\n\n", _prophecies.ConvertAll(p => p.Describe()));
        }

        public static void ApplySelfFulfillment(Mind mind)
        {
            foreach (var p in _prophecies)
            {
                if (p.IsFulfilled || p.IsCorrupted) continue;
                if (mind.Memory.Memories.Exists(m => m.Summary.Contains(p.PredictedEvent)))
                {
                    p.IsFulfilled = true;
                    continue;
                }
                if (mind.Beliefs.Beliefs.ContainsKey(p.PredictedEvent) || mind.DynamicBeliefs.Beliefs.Exists(b => b.Statement.Contains(p.PredictedEvent)))
                {
                    mind.Memory.AddMemory(p.PredictedEvent, 0.3f, 0.1f, new() { "Profecia" }, "profecia");
                    p.IsFulfilled = true;
                }
            }
        }
    }
}
