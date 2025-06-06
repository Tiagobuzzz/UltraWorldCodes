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
        public bool HasPhotographicMemory { get; }
        public Inventory Inventory { get; } = new();
        public LifeStage CurrentLifeStage { get; set; } = LifeStage.Adulto;
        public SpatialIdentity Location { get; private set; }
        public Genome Genome { get; set; } = new();
        public int Age { get; set; }
        public DateTime BirthDate { get; }
        public DateTime? DeathDate { get; private set; }
        public bool IsAlive => DeathDate == null;

        public Person(string name, string bloodline = "", DateTime? birthDate = null, bool photographicMemory = false)
        {
            Name = name;
            Bloodline = bloodline;
            Mind = new Mind(this, photographicMemory ? new PhotographicMemorySystem() : null);
            HasPhotographicMemory = photographicMemory;
            Location = new SpatialIdentity("Origem", 0, 0);
            BirthDate = birthDate ?? DateTime.Now;
            Age = 0;
            Religion.RelicSystem.ApplyRelics(this);
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

        public void Die()
        {
            if (DeathDate != null) return;
            DeathDate = DateTime.Now;
            Mind.History.RegisterEvent("Morreu");
        }

        public void Update()
        {
            Mind.Update();
            LifeCycleSystem.Advance(this);
            PersonalityLifeAdjuster.Apply(this);
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
