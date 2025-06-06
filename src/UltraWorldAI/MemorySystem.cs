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
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
        };
        /// <summary>
        /// List of all memories known by the agent, ordered from newest to oldest.
        /// </summary>
        [JsonInclude]
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
            var threshold = AIConfig.ForgottenMemoryThreshold;
            foreach (var mem in Memories)
            {
                mem.Intensity = Math.Max(0, mem.Intensity - AISettings.MemoryDecayRate);
            }
            Memories.RemoveAll(m => m.Intensity <= threshold);
        }

        /// <summary>
        /// Persists memories and optional state to disk.
        /// </summary>
        /// <param name="path">Destination file path.</param>
        /// <param name="beliefs">Current belief values to store.</param>
        /// <param name="personality">Current personality traits to store.</param>
        public void SaveMemories(string path, BeliefSystem? beliefs = null, PersonalitySystem? personality = null)
        {
            if (path.EndsWith(".db", StringComparison.OrdinalIgnoreCase))
            {
                Persistence.MemoryDatabase.Save(path, Memories);
                return;
            }

            var state = new PersistedState
            {
                Memories = Memories,
                Beliefs = beliefs?.Beliefs,
                Traits = personality?.Traits
            };
            var json = JsonSerializer.Serialize(state, _options);
            File.WriteAllText(path, json);
        }

        /// <summary>
        /// Asynchronously writes the persisted state to disk.
        /// </summary>
        public async Task SaveMemoriesAsync(string path, BeliefSystem? beliefs = null, PersonalitySystem? personality = null)
        {
            if (path.EndsWith(".db", StringComparison.OrdinalIgnoreCase))
            {
                Persistence.MemoryDatabase.Save(path, Memories);
                return;
            }

            var state = new PersistedState
            {
                Memories = Memories,
                Beliefs = beliefs?.Beliefs,
                Traits = personality?.Traits
            };
            await using var fs = File.Create(path);
            await JsonSerializer.SerializeAsync(fs, state, _options);
        }

        /// <summary>
        /// Loads memories and optional agent state from disk.
        /// </summary>
        public void LoadMemories(string path, BeliefSystem? beliefs = null, PersonalitySystem? personality = null)
        {
            if (path.EndsWith(".db", StringComparison.OrdinalIgnoreCase))
            {
                if (File.Exists(path))
                    Memories = Persistence.MemoryDatabase.Load(path);
                return;
            }

            if (!File.Exists(path)) return;
            var json = File.ReadAllText(path);
            var state = JsonSerializer.Deserialize<PersistedState>(json, _options);
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
            if (path.EndsWith(".db", StringComparison.OrdinalIgnoreCase))
            {
                if (File.Exists(path))
                    Memories = Persistence.MemoryDatabase.Load(path);
                return;
            }

            if (!File.Exists(path)) return;
            var json = await File.ReadAllTextAsync(path);
            var state = JsonSerializer.Deserialize<PersistedState>(json, _options);
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
            var lower = keyword?.Trim().ToLowerInvariant();
            var results = new List<(Memory mem, float weight)>();

            foreach (var m in Memories)
            {
                bool matches = string.IsNullOrWhiteSpace(lower);
                if (!matches)
                {
                    foreach (var k in m.Keywords)
                    {
                        if (k.Contains(lower!, StringComparison.OrdinalIgnoreCase))
                        {
                            matches = true;
                            break;
                        }
                    }

                    if (!matches && m.Summary.Contains(lower!, StringComparison.OrdinalIgnoreCase))
                        matches = true;
                }

                if (matches)
                {
                    float weight = (m.Intensity * 0.6f) +
                                   (Math.Abs(m.EmotionalCharge) * 0.3f) +
                                   (float)(1.0 / (1.0 + (now - m.Date).TotalDays));
                    results.Add((m, weight));
                }
            }

            var sorted = results
                .OrderByDescending(r => r.weight)
                .Take(count)
                .Select(r => r.mem)
                .ToList();

            foreach (var mem in sorted)
            {
                mem.Intensity = Math.Min(1f, mem.Intensity + 0.05f);
            }

            return sorted;
        }

        /// <summary>
        /// Retrieves memories tagged with a specific emotion label.
        /// </summary>
        public List<Memory> RetrieveMemoriesByEmotion(string emotion, int count = 5)
        {
            var lower = emotion.ToLowerInvariant();
            var matches = new List<Memory>();
            foreach (var m in Memories)
            {
                if (string.Equals(m.Emotion, lower, StringComparison.OrdinalIgnoreCase))
                    matches.Add(m);
            }

            var results = matches
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
            var lower = keyword.ToLowerInvariant();
            Memories.RemoveAll(m =>
            {
                foreach (var k in m.Keywords)
                {
                    if (k.Contains(lower, StringComparison.OrdinalIgnoreCase))
                        return true;
                }
                return m.Summary.Contains(lower, StringComparison.OrdinalIgnoreCase);
            });
        }
    }
}
