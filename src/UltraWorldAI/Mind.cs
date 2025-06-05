using System;

namespace UltraWorldAI
{
    public class Mind
    {
        public Person PersonReference { get; private set; }
        public MemorySystem Memory { get; private set; }
        public BeliefSystem Beliefs { get; private set; }
        public PersonalitySystem Personality { get; private set; }
        public EmotionSystem Emotions { get; private set; }
        public MetacognitionSystem Meta { get; private set; }
        public ConflictSystem Conflict { get; private set; }
        public NarrativeEngine Narrative { get; private set; }
        public StressSystem Stress { get; private set; }
        public SelfNarrativeSystem SelfNarrative { get; private set; }
        public SemanticMemory Knowledge { get; private set; }
        public BehaviorSystem Behavior { get; private set; }

        public Mind(Person person)
        {
            PersonReference = person;
            Memory = new MemorySystem();
            Beliefs = new BeliefSystem();
            Personality = new PersonalitySystem();
            Emotions = new EmotionSystem();
            Meta = new MetacognitionSystem(person);
            Conflict = new ConflictSystem(person);
            Stress = new StressSystem(person);
            SelfNarrative = new SelfNarrativeSystem(person);
            Knowledge = new SemanticMemory();
            Behavior = new BehaviorSystem(person);
            Narrative = new NarrativeEngine(person);
        }

        public void Update()
        {
            Memory.UpdateMemoryDecay();
            Emotions.UpdateEmotionsDecay();
            Knowledge.DecayFacts();
            Stress.UpdateStressDecay();
        }
    }
}
