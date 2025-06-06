using System;

namespace UltraWorldAI
{
    public class StressSystem
    {
        public float CurrentStressLevel { get; private set; }
        private readonly Person _person;

        public StressSystem(Person person)
        {
            _person = person;
            CurrentStressLevel = AIConfig.MinStress;
        }

        public void AddStress(float amount)
        {
            CurrentStressLevel = Math.Min(AIConfig.MaxStress, CurrentStressLevel + amount);
        }

        public void ReduceStress(float amount)
        {
            CurrentStressLevel = Math.Max(AIConfig.MinStress, CurrentStressLevel - amount);
        }

        public void UpdateStressDecay()
        {
            ReduceStress(AISettings.StressDecayRate);
        }

        public bool IsStressed()
        {
            return CurrentStressLevel > 0.5f;
        }
    }

    public static class PopulationStressEvaluator
    {
        public static string? CheckForUprising(Politics.PowerStructure gov, System.Collections.Generic.List<Person> population, string rebelLeader)
        {
            if (population.Count == 0) return null;
            float avg = 0f;
            foreach (var p in population)
                avg += p.Mind.Stress.CurrentStressLevel;
            avg /= population.Count;
            return avg > 0.8f ? Politics.RevoltSystem.TriggerRevolt(gov, rebelLeader) : null;
        }
    }
}
