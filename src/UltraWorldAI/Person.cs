using System;
using System.Collections.Generic;
using UltraWorldAI.Territory;
using UltraWorldAI.Game;
using UltraWorldAI.Biology;

namespace UltraWorldAI
{
    public class Person
    {
        public string Name { get; set; }
        public string Bloodline { get; set; } = string.Empty;
        public Mind Mind { get; private set; }
        public Inventory Inventory { get; } = new();
        public LifeStage CurrentLifeStage { get; set; } = LifeStage.Adulto;
        public SpatialIdentity Location { get; private set; }
        public Genome Genome { get; set; } = new();

        public Person(string name, string bloodline = "")
        {
            Name = name;
            Bloodline = bloodline;
            Mind = new Mind(this);
            Location = new SpatialIdentity("Origem", 0, 0);
        }

        public string ReflectOnSelf()
        {
            return Mind.Narrative.GenerateReflection();
        }

        public void AddExperience(string summary, float intensity = 0.5f, float emotionalCharge = 0.0f, List<string>? keywords = null, string source = "self")
        {
            Mind.Memory.AddMemory(summary, intensity, emotionalCharge, keywords, source);
            if (Math.Abs(emotionalCharge) >= 0.5f)
            {
                var emotion = Mind.Emotions.GetDominantEmotion();
                Mind.HabitatMemory.TagPlace(Location.RegionName, emotion, summary, Math.Abs(emotionalCharge));
            }
            Logger.Log($"\n[{Name} Experience] '{summary}' (Intensity: {intensity}, Emotion: {emotionalCharge})");
        }

        public void Interact(Person other, string information, float influence = 0.1f)
        {
            InteractionSystem.Exchange(this, other, information, influence);
        }

        public void MoveTo(string region, float x, float y)
        {
            Location.MoveTo(region, x, y);
        }

        public void Update()
        {
            Mind.Update();
        }

        public static Person CreateDescendant(Person parent, string name)
        {
            var child = new Person(name);
            parent.Mind.Legacy.DefineLegacyFromMind(parent.Mind);
            parent.Mind.Legacy.ApplyLegacyToNewPerson(child);
            child.Genome = Biology.GeneticReproduction.CrossGenomes(parent.Genome, child.Genome);
            return child;
        }
    }
}
