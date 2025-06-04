using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text.Json;

namespace UltraWorldAI
{
    public class ConflictSystem
    {
        private readonly Person _person;
        public List<string> ActiveContradictions { get; private set; } = new List<string>();

        public event Action<string>? ContradictionDetected;
        public event Action<string>? ContradictionResolved;

        public ConflictSystem(Person person)
        {
            _person = person;
        }

        public void TriggerContradiction(string selfAspect, string actionOrEmotion, string context = null)
        {
            string contradiction = $"Contradiction detected: Self-image '{selfAspect}' vs. '{actionOrEmotion}'";
            if (context != null)
            {
                contradiction += $" (Context: '{context}')";
            }
            if (!ActiveContradictions.Contains(contradiction))
            {
                ActiveContradictions.Add(contradiction);
                Logger.Log($"[Conflict] {_person.Name} is experiencing: {contradiction}");
                ContradictionDetected?.Invoke(contradiction);
                _person.Mind.Stress.AddStress(AIConfig.StressIncreasePerContradiction);
            }
        }

        public void ResolveContradiction(string contradictionIdentifier)
        {
            var resolved = ActiveContradictions.RemoveAll(c => c.Contains(contradictionIdentifier));
            if (resolved > 0)
            {
                ContradictionResolved?.Invoke(contradictionIdentifier);
                Logger.Log($"[Conflict] {_person.Name} has resolved/mitigated contradiction.");
                _person.Mind.Stress.ReduceStress(AIConfig.StressReductionPerDefense * resolved);
            }
        }

        public bool HasActiveContradictions()
        {
            return ActiveContradictions.Any();
        }
    }
}
