using System;
using System.Collections.Generic;

namespace UltraWorldAI
{
    public class Person
    {
        public string Name { get; set; }
        public Mind Mind { get; private set; }
        public LifeStage CurrentLifeStage { get; set; } = LifeStage.Adult;

        public Person(string name)
        {
            Name = name;
            Mind = new Mind(this);
        }

        public string ReflectOnSelf()
        {
            return Mind.Narrative.GenerateReflection();
        }

        public void AddExperience(string summary, float intensity = 0.5f, float emotionalCharge = 0.0f, List<string>? keywords = null, string source = "self")
        {
            Mind.Memory.AddMemory(summary, intensity, emotionalCharge, keywords, source);
            Logger.Log($"\n[{Name} Experience] '{summary}' (Intensity: {intensity}, Emotion: {emotionalCharge})");
        }

        public string DecideNextAction()
        {
            return Mind.Behavior.DecideNextAction();
        }

        public void Update()
        {
            Mind.Update();
        }
    }
}
