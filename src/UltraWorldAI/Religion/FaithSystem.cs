using System;
using System.Collections.Generic;

namespace UltraWorldAI.Religion
{
    public class FaithStatus
    {
        public DivineBeing God { get; set; } = new();
        public float DevotionLevel { get; set; } = 0.5f; // 0 = cético, 1 = fanático
        public bool IsHeretical { get; set; }
        public List<string> PersonalInterpretations { get; } = new();
    }

    public class FaithSystem
    {
        private readonly Dictionary<string, FaithStatus> _faithMap = new();

        public void FollowGod(string brainID, DivineBeing god)
        {
            if (!_faithMap.ContainsKey(brainID))
            {
                var status = new FaithStatus { God = god };
                status.PersonalInterpretations.Add($"O deus {god.Name} fala comigo em sonho.");
                _faithMap[brainID] = status;
            }
        }

        public void IncreaseFaith(string brainID, float amount = 0.1f)
        {
            if (_faithMap.TryGetValue(brainID, out var status))
            {
                status.DevotionLevel = Math.Clamp(status.DevotionLevel + amount, 0f, 1f);
            }
        }

        public void LoseFaith(string brainID, string reason)
        {
            if (_faithMap.TryGetValue(brainID, out var status))
            {
                status.DevotionLevel = Math.Clamp(status.DevotionLevel - 0.2f, 0f, 1f);
                status.PersonalInterpretations.Add($"Dúvida surgiu: {reason}");

                if (status.DevotionLevel <= 0.1f)
                {
                    status.IsHeretical = true;
                    status.PersonalInterpretations.Add("Rompeu com o culto oficial.");
                }
            }
        }

        public FaithStatus? GetFaithStatus(string brainID)
        {
            return _faithMap.TryGetValue(brainID, out var status) ? status : null;
        }

        public string DescribeFaith(string brainID)
        {
            var status = GetFaithStatus(brainID);
            if (status == null) return "Sem fé registrada.";

            return $"Fé em {status.God.Name} (Domínio: {status.God.Domain})\n" +
                   $"Nível de devoção: {status.DevotionLevel}\n" +
                   $"Estado herético: {status.IsHeretical}\n" +
                   $"Interpretações: {string.Join(" / ", status.PersonalInterpretations)}";
        }
    }
}
