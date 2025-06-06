using System;
using UltraWorldAI.EventSourcing;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;

namespace UltraWorldAI
{


    /// <summary>
    /// Stores and manages a collection of <see cref="Memory"/> instances.
    /// </summary>
    public partial class MemorySystem
    {
        /// <summary>
        /// List of all memories known by the agent, ordered from newest to oldest.
        /// </summary>
        [JsonInclude]
        public List<Memory> Memories { get; private set; } = new List<Memory>();

        private readonly Dictionary<string, List<Memory>> _keywordCache = new();
        private readonly Dictionary<string, List<Memory>> _emotionCache = new();

        private void ClearCache()
        {
            _keywordCache.Clear();
            _emotionCache.Clear();
        }

        /// <summary>
        /// Records a new memory. When the configured maximum is reached the least
        /// important entry will be discarded.
        /// </summary>
        /// <param name="summary">Short description of the experience.</param>
        /// <param name="intensity">Importance on a 0-1 scale.</param>
        /// <param name="emotionalCharge">Associated emotional valence.</param>
        /// <param name="keywords">Optional keywords for retrieval.</param>
        /// <param name="source">Source of the experience.</param>
        /// <param name="isFalse">Marks the memory as fabricated.</param>
        public virtual void AddMemory(string summary, float intensity = 0.5f, float emotionalCharge = 0.0f, List<string>? keywords = null, string source = "self", string emotion = "", bool isFalse = false)
        {
            ClearCache();
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
                Emotion = emotion,
                IsFalse = isFalse
            });
            AISettings.EventStore?.Record(new EventSourcing.EventRecord("MemoryAdded", summary, DateTime.Now));
            Memories = Memories.OrderByDescending(m => m.Date).ToList();
        }

        private void ForgetLeastImportantMemory()
        {
            ClearCache();
            Memories.RemoveAll(m => m.Intensity < AISettings.ForgottenMemoryThreshold || (DateTime.Now - m.Date).TotalDays > 365);
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
        public virtual void UpdateMemoryDecay()
        {
            ClearCache();
            var threshold = AISettings.ForgottenMemoryThreshold;
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
            SaveMemoriesAsync(path, beliefs, personality).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Asynchronously writes the persisted state to disk.
        /// </summary>
        public async Task SaveMemoriesAsync(string path, BeliefSystem? beliefs = null,
            PersonalitySystem? personality = null, CancellationToken cancellationToken = default)
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

            if (path.EndsWith(".gz", StringComparison.OrdinalIgnoreCase))
            {
                try
                {
                    await using var fs = File.Create(path);
                    await using var gz = new System.IO.Compression.GZipStream(fs, System.IO.Compression.CompressionLevel.Optimal);
                    await JsonSerializer.SerializeAsync(gz, state, MemorySystemJsonContext.Default.PersistedState, cancellationToken);
                    return;
                }
                catch (IOException ex)
                {
                    Logger.LogError($"Failed to save memories to {path}", ex);
                    return;
                }
            }
            try
            {
                await using var fs = File.Create(path);
                await JsonSerializer.SerializeAsync(fs, state, MemorySystemJsonContext.Default.PersistedState, cancellationToken);
            }
            catch (IOException ex)
            {
                Logger.LogError($"Failed to save memories to {path}", ex);
            }
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
            if (path.EndsWith(".gz", StringComparison.OrdinalIgnoreCase))
            {
                LoadMemoriesAsync(path, beliefs, personality).GetAwaiter().GetResult();
                return;
            }

            if (!File.Exists(path)) return;
            PersistedState? state = null;
            try
            {
                var json = File.ReadAllText(path);
                state = JsonSerializer.Deserialize(json, MemorySystemJsonContext.Default.PersistedState);
            }
            catch (IOException ex)
            {
                Logger.LogError($"Failed to load memories from {path}", ex);
            }
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
        public async Task LoadMemoriesAsync(string path, BeliefSystem? beliefs = null,
            PersonalitySystem? personality = null, CancellationToken cancellationToken = default)
        {
            if (path.EndsWith(".db", StringComparison.OrdinalIgnoreCase))
            {
                if (File.Exists(path))
                    Memories = Persistence.MemoryDatabase.Load(path);
                return;
            }

            if (!File.Exists(path)) return;
            PersistedState? state = null;
            try
            {
                if (path.EndsWith(".gz", StringComparison.OrdinalIgnoreCase))
                {
                    await using var fs = File.OpenRead(path);
                    await using var gz = new System.IO.Compression.GZipStream(fs, System.IO.Compression.CompressionMode.Decompress);
                    state = await JsonSerializer.DeserializeAsync(gz, MemorySystemJsonContext.Default.PersistedState, cancellationToken);
                }
                else
                {
                    var json = await File.ReadAllTextAsync(path, cancellationToken);
                    state = JsonSerializer.Deserialize(json, MemorySystemJsonContext.Default.PersistedState);
                }
            }
            catch (IOException ex)
            {
                Logger.LogError($"Failed to load memories from {path}", ex);
            }
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
        /// Quickly checks if a persisted state file can be deserialized.
        /// </summary>
        public bool ValidateSaveFile(string path)
        {
            try
            {
                if (path.EndsWith(".db", StringComparison.OrdinalIgnoreCase))
                {
                    return File.Exists(path);
                }

                if (!File.Exists(path)) return false;

                if (path.EndsWith(".gz", StringComparison.OrdinalIgnoreCase))
                {
                    using var fs = File.OpenRead(path);
                    using var gz = new System.IO.Compression.GZipStream(fs, System.IO.Compression.CompressionMode.Decompress);
                    var state = JsonSerializer.Deserialize<PersistedState>(gz, MemorySystemJsonContext.Default.PersistedState);
                    return state != null;
                }
                else
                {
                    var json = File.ReadAllText(path);
                    var state = JsonSerializer.Deserialize<PersistedState>(json, MemorySystemJsonContext.Default.PersistedState);
                    return state != null;
                }
            }
            catch
            {
                return false;
            }
        }

        internal class PersistedState
        {
            public List<Memory> Memories { get; set; } = new();
            public Dictionary<string, float>? Beliefs { get; set; }
            public Dictionary<string, float>? Traits { get; set; }
        }
    }
}
