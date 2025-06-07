using System;
using System.Collections.Generic;
using System.Linq;

namespace UltraWorldAI
{
    public enum EventMemoryState
    {
        Past,
        Present,
        Mythic
    }

    public class HistoricalEvent
    {
        public string EventName { get; set; } = string.Empty;
        public string Symbol { get; set; } = string.Empty;
        public List<string> AffectedCivilizations { get; set; } = new();
        public string CulturalImpact { get; set; } = string.Empty;
        public EventMemoryState MemoryState { get; set; }
        public DateTime Timestamp { get; set; }
        public string OriginEmotion { get; set; } = string.Empty;
        public string RecordForm { get; set; } = "oral";
    }

    public static class HistorySystem
    {
        public static List<HistoricalEvent> Events { get; } = new();

        public static void RegisterEvent(HistoricalEvent e)
        {
            Events.Add(e);
        }

        public static void LogEvent(string description)
        {
            RegisterEvent(new HistoricalEvent
            {
                EventName = description,
                Symbol = description,
                AffectedCivilizations = new() { "geral" },
                CulturalImpact = "registro",
                MemoryState = EventMemoryState.Present,
                Timestamp = DateTime.Now,
                OriginEmotion = string.Empty,
                RecordForm = "texto"
            });
        }

        public static List<HistoricalEvent> GetEventsForCivilization(string civ)
        {
            return Events.Where(ev => ev.AffectedCivilizations.Contains(civ)).ToList();
        }
    }

    public class CultureLawSystem
    {
        public List<string> Laws { get; } = new();
        public List<string> Taboos { get; } = new();

        public void RegisterLaw(string law) => Laws.Add(law);
        public void RegisterTaboo(string taboo) => Taboos.Add(taboo);
    }

    public static class IAWorldLink
    {
        public static void RegisterActionAsHistoricalEvent(Mind mind, string actionSymbol)
        {
            var e = new HistoricalEvent
            {
                EventName = $"{mind.PersonReference.Name} fez {actionSymbol}",
                Symbol = actionSymbol,
                AffectedCivilizations = new() { "geral" },
                CulturalImpact = "Ideia expressa pela IA",
                MemoryState = EventMemoryState.Present,
                Timestamp = DateTime.Now,
                OriginEmotion = mind.Emotions.GetDominantEmotion(),
                RecordForm = "oral"
            };

            HistorySystem.RegisterEvent(e);
        }

        public static void UpdateNarrativeFromWorldEvent(Mind mind, HistoricalEvent e)
        {
            if (e.CulturalImpact.Contains("trauma", StringComparison.OrdinalIgnoreCase))
            {
                mind.IdeaEngine.GenerateIdea("Evento traumático externo",
                    new() { e.EventName }, mind.Emotions);
            }

            if (e.CulturalImpact.Contains("milagre", StringComparison.OrdinalIgnoreCase))
            {
                mind.IdeaEngine.GenerateIdea("Presença Divina?",
                    new() { e.EventName }, mind.Emotions);
            }
        }

        public static void SimulateCycle(Mind mind, HistoricalEvent worldEvent)
        {
            HistorySystem.RegisterEvent(worldEvent);
            UpdateNarrativeFromWorldEvent(mind, worldEvent);

            if (mind.IdeaEngine.GeneratedIdeas.Any())
            {
                var lastIdea = mind.IdeaEngine.GeneratedIdeas.Last();
                mind.IdeaEngine.ExpressIdea(lastIdea.Title, mind);
                RegisterActionAsHistoricalEvent(mind, lastIdea.Title);
            }
        }
    }
}
