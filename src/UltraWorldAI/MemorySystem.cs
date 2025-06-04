using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace UltraWorldAI
{
    public class Memory
    {
        public string Summary { get; set; }
        public DateTime Date { get; set; }
        public float Intensity { get; set; }
        public float EmotionalCharge { get; set; }
        public List<string> Keywords { get; set; }
        public string Source { get; set; }

        public Memory()
        {
            Keywords = new List<string>();
        }
    }

    public class MemorySystem
    {
        public List<Memory> Memories { get; private set; } = new List<Memory>();

        public void AddMemory(string summary, float intensity = 0.5f, float emotionalCharge = 0.0f, List<string>? keywords = null, string source = "self")
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
                Source = source
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

        public void UpdateMemoryDecay()
        {
            foreach (var mem in Memories)
            {
                mem.Intensity = Math.Max(0, mem.Intensity - AIConfig.MemoryDecayRate);
            }
            Memories.RemoveAll(m => m.Intensity <= AIConfig.ForgottenMemoryThreshold);
        }

        public void SaveMemories(string path)
        {
            var json = JsonSerializer.Serialize(Memories);
            File.WriteAllText(path, json);
        }

        public void LoadMemories(string path)
        {
            if (!File.Exists(path)) return;
            var json = File.ReadAllText(path);
            var mems = JsonSerializer.Deserialize<List<Memory>>(json);
            if (mems != null) Memories = mems;
        }

        public List<Memory> RetrieveMemories(string keyword, int count = 5)
        {
            return Memories.Where(m => m.Keywords.Contains(keyword) || m.Summary.Contains(keyword))
                            .OrderByDescending(m => m.Intensity)
                            .Take(count)
                            .ToList();
        }
    }
}
