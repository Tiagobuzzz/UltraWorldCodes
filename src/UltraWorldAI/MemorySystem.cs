using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace UltraWorldAI
{
    /// <summary>
    /// Represents a single remembered experience.
    /// </summary>
    public class Memory
    {
        /// <summary>
        /// Short description of the event.
        /// </summary>
        public string Summary { get; set; } = string.Empty;

        /// <summary>
        /// Time when the memory occurred.
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Importance of the memory on a 0-1 scale.
        /// </summary>
        public float Intensity { get; set; }

        /// <summary>
        /// Emotional valence associated with the memory.
        /// </summary>
        public float EmotionalCharge { get; set; }

        /// <summary>
        /// Optional label describing the dominant emotion.
        /// </summary>
        public string Emotion { get; set; } = string.Empty;

        /// <summary>
        /// Keywords that help relate this memory to other concepts.
        /// </summary>
        public List<string> Keywords { get; set; }

        /// <summary>
        /// Source of the memory (e.g., self or external).
        /// </summary>
        public string Source { get; set; } = string.Empty;

        public Memory()
        {
            Keywords = new List<string>();
        }
    }

    /// <summary>
    /// Stores and manages a collection of <see cref="Memory"/> instances.
    /// </summary>
    public class MemorySystem
    {
        private static readonly JsonSerializerOptions _options = new()
        {
            WriteIndented = false,
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault
        };
        /// <summary>
        /// List of all memories known by the agent, ordered from newest to oldest.
        /// </summary>
        [System.Text.Json.Serialization.JsonInclude]
        public List<Memory> Memories { get; private set; } = new List<Memory>();

        /// <summary>
        /// Records a new memory. When the configured maximum is reached the least
        /// important entry will be discarded.
        /// </summary>
        /// <param name="summary">Short description of the experience.</param>
        /// <param name="intensity">Importance on a 0-1 scale.</param>
        /// <param name="emotionalCharge">Associated emotional valence.</param>
        /// <param name="keywords">Optional keywords for retrieval.</param>
        /// <param name="source">Source of the experience.</param>
        public void AddMemory(string summary, float intensity = 0.5f, float emotionalCharge = 0.0f, List<string>? keywords = null, string source = "self", string emotion = "")
        {
            if (Memories.Count >= AISettings.MaxMemories)
            {
                ForgetLeastImportantMemory();
            }
            Memories.Add(new Memory
            {
                Summary = summary,
                Date = DateTime.Now,
                Intensity = Math.Clamp(intensity, 0f, 1f),
                EmotionalCharge = Math.Clamp(emotionalCharge, -1f, 1f),
                Keywords = keywords ?? new List<string>(),
                Source = source,
                Emotion = emotion
            });
            Memories = Memories.OrderByDescending(m => m.Date).ToList();
        }

        private void ForgetLeastImportantMemory()
        {
            Memories.RemoveAll(m => m.Intensity < AIConfig.ForgottenMemoryThreshold || (DateTime.Now - m.Date).TotalDays > 365);
            if (Memories.Count >= AISettings.MaxMemories)
            {
                var leastImportant = Memories.OrderBy(m => m.Intensity).ThenBy(m => m.Date).FirstOrDefault();
                if (leastImportant != null)
                {
                    Memories.Remove(leastImportant);
                }
            }
        }

        /// <summary>
        /// Applies decay to all memories and removes those that fall below the
        /// configured threshold.
        /// </summary>
        public void UpdateMemoryDecay()
        {
            for (int i = Memories.Count - 1; i >= 0; i--)
            {
                var mem = Memories[i];
                mem.Intensity = Math.Max(0, mem.Intensity - AISettings.MemoryDecayRate);
                if (mem.Intensity <= AIConfig.ForgottenMemoryThreshold)
                {
                    Memories.RemoveAt(i);
                }
            }
        }

        /// <summary>
        /// Persists memories and optional state to disk.
        /// </summary>
        /// <param name="path">Destination file path.</param>
        /// <param name="beliefs">Current belief values to store.</param>
        /// <param name="personality">Current personality traits to store.</param>
        public void SaveMemories(string path, BeliefSystem? beliefs = null, PersonalitySystem? personality = null)
        {
            var state = new PersistedState
            {
                Memories = Memories,
                Beliefs = beliefs?.Beliefs,
                Traits = personality?.Traits
            };
            var bytes = JsonSerializer.SerializeToUtf8Bytes(state, _options);
            File.WriteAllBytes(path, bytes);
        }

        /// <summary>
        /// Asynchronously writes the persisted state to disk.
        /// </summary>
        public async Task SaveMemoriesAsync(string path, BeliefSystem? beliefs = null, PersonalitySystem? personality = null)
        {
            var state = new PersistedState
            {
                Memories = Memories,
                Beliefs = beliefs?.Beliefs,
                Traits = personality?.Traits
            };
            var bytes = JsonSerializer.SerializeToUtf8Bytes(state, _options);
            await File.WriteAllBytesAsync(path, bytes);
        }

        /// <summary>
        /// Loads memories and optional agent state from disk.
        /// </summary>
        public void LoadMemories(string path, BeliefSystem? beliefs = null, PersonalitySystem? personality = null)
        {
            if (!File.Exists(path)) return;
            var bytes = File.ReadAllBytes(path);
            var state = JsonSerializer.Deserialize<PersistedState>(bytes, _options);
            if (state == null) return;
            if (state.Memories != null) Memories = state.Memories;
            if (state.Beliefs != null && beliefs != null)
            {
                foreach (var kv in state.Beliefs)
                {
                    beliefs.UpdateBelief(kv.Key, kv.Value - (beliefs.Beliefs.ContainsKey(kv.Key) ? beliefs.Beliefs[kv.Key] : 0f));
                }
            }
            if (state.Traits != null && personality != null)
            {
                foreach (var kv in state.Traits)
                {
                    personality.SetTrait(kv.Key, kv.Value);
                }
            }
        }

        /// <summary>
        /// Asynchronously loads persisted memories from disk.
        /// </summary>
        public async Task LoadMemoriesAsync(string path, BeliefSystem? beliefs = null, PersonalitySystem? personality = null)
        {
            if (!File.Exists(path)) return;
            var bytes = await File.ReadAllBytesAsync(path);
            var state = JsonSerializer.Deserialize<PersistedState>(bytes, _options);
            if (state == null) return;
            if (state.Memories != null) Memories = state.Memories;
            if (state.Beliefs != null && beliefs != null)
            {
                foreach (var kv in state.Beliefs)
                {
                    beliefs.UpdateBelief(kv.Key, kv.Value - (beliefs.Beliefs.ContainsKey(kv.Key) ? beliefs.Beliefs[kv.Key] : 0f));
                }
            }
            if (state.Traits != null && personality != null)
            {
                foreach (var kv in state.Traits)
                {
                    personality.SetTrait(kv.Key, kv.Value);
                }
            }
        }

        private class PersistedState
        {
            public List<Memory> Memories { get; set; } = new();
            public Dictionary<string, float>? Beliefs { get; set; }
            public Dictionary<string, float>? Traits { get; set; }
        }

        /// <summary>
        /// Retrieves a ranked list of memories matching the provided keyword.
        /// The act of retrieval slightly refreshes their intensity.
        /// </summary>
        /// <param name="keyword">Keyword to search for. If empty all memories are considered.</param>
        /// <param name="count">Maximum number of memories to return.</param>
        public List<Memory> RetrieveMemories(string keyword, int count = 5)
        {
            var now = DateTime.Now;
            string lower = keyword.ToLowerInvariant();
            var results = Memories
                .Where(m => string.IsNullOrWhiteSpace(lower) ||
                             m.Keywords.Any(k => k.ToLowerInvariant().Contains(lower)) ||
                             m.Summary.ToLowerInvariant().Contains(lower))
                .OrderByDescending(m =>
                    (m.Intensity * 0.6f) +
                    (Math.Abs(m.EmotionalCharge) * 0.3f) +
                    (float)(1.0 / (1.0 + (now - m.Date).TotalDays)))
                .Take(count)
                .ToList();

            foreach (var mem in results)
            {
                mem.Intensity = Math.Min(1f, mem.Intensity + 0.05f);
            }

            return results;
        }

        /// <summary>
        /// Retrieves memories tagged with a specific emotion label.
        /// </summary>
        public List<Memory> RetrieveMemoriesByEmotion(string emotion, int count = 5)
        {
            var results = Memories
                .Where(m => string.Equals(m.Emotion, emotion, StringComparison.OrdinalIgnoreCase))
                .OrderByDescending(m => m.Intensity)
                .Take(count)
                .ToList();

            foreach (var mem in results)
            {
                mem.Intensity = Math.Min(1f, mem.Intensity + 0.05f);
            }

            return results;
        }

        /// <summary>
        /// Returns the most intense memory or null if none exist.
        /// </summary>
        public Memory? GetMostIntenseMemory()
        {
            return Memories.OrderByDescending(m => m.Intensity).FirstOrDefault();
        }

        /// <summary>
        /// Removes memories containing the specified keyword.
        /// </summary>
        public void RemoveMemoriesByKeyword(string keyword)
        {
            Memories.RemoveAll(m => m.Keywords.Any(k => k.Contains(keyword, StringComparison.OrdinalIgnoreCase)) ||
                                   m.Summary.Contains(keyword, StringComparison.OrdinalIgnoreCase));
        }
    }
}
