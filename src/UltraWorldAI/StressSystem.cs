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
}
