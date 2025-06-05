using System;

namespace UltraWorldAI
{
    public class Mind
    {
        public Person PersonReference { get; private set; }
        public MemorySystem Memory { get; private set; }
        public BeliefSystem Beliefs { get; private set; }
        public BeliefArchitecture DynamicBeliefs { get; private set; }
        public PersonalitySystem Personality { get; private set; }
        public EmotionSystem Emotions { get; private set; }
        public MetacognitionSystem Meta { get; private set; }
        public ConflictSystem Conflict { get; private set; }
        public NarrativeEngine Narrative { get; private set; }
        public StressSystem Stress { get; private set; }
        public SelfNarrativeSystem SelfNarrative { get; private set; }
        public InternalNarrativeSystem InternalNarrative { get; private set; }
        public SemanticMemory Knowledge { get; private set; }
        public IdeaNetwork IdeaNet { get; private set; }
        public ThoughtSystem ThoughtEngine { get; private set; }
        public BrainwireSystem BrainMap { get; private set; }
        public IntuitionSystem Intuition { get; private set; }
        public GoalSystem Goals { get; private set; }
        public SimulationSystem Simulation { get; private set; }
        public SubpersonalitySystem Subvoices { get; private set; }
        public SocialSystem Social { get; private set; }
        public ReputationSystem Reputation { get; private set; }
        public RitualSystem Rituals { get; private set; }
        public ExternalSupportSystem ExternalSupport { get; private set; }
        public PhilosophySystem Philosophy { get; private set; }

        public Mind(Person person)
        {
            PersonReference = person;
            Memory = new MemorySystem();
            Beliefs = new BeliefSystem();
            DynamicBeliefs = new BeliefArchitecture();
            Personality = new PersonalitySystem();
            Emotions = new EmotionSystem();
            Meta = new MetacognitionSystem(person);
            Conflict = new ConflictSystem(person);
            Stress = new StressSystem(person);
            SelfNarrative = new SelfNarrativeSystem(person);
            InternalNarrative = new InternalNarrativeSystem();
            Knowledge = new SemanticMemory();
            Narrative = new NarrativeEngine(person);
            IdeaNet = new IdeaNetwork();
            ThoughtEngine = new ThoughtSystem();
            BrainMap = new BrainwireSystem();
            Intuition = new IntuitionSystem();
            Goals = new GoalSystem();
            Simulation = new SimulationSystem();
            Subvoices = new SubpersonalitySystem();
            Social = new SocialSystem();
            Reputation = new ReputationSystem();
            Rituals = new RitualSystem();
            ExternalSupport = new ExternalSupportSystem();
            Philosophy = new PhilosophySystem();
        }

        public void Update()
        {
            ExternalSupport.EvaluateInfluences(PersonReference);
            Memory.UpdateMemoryDecay();
            Emotions.UpdateEmotionsDecay();
            Knowledge.DecayFacts();
            Stress.UpdateStressDecay();
            IdeaNet.GenerateNewIdea("conflito", Emotions, Memory, Beliefs);
            Simulation.Simulate(Emotions, Goals, Memory);
            Subvoices.UpdateInfluences();
            ThoughtEngine.GenerateThought(this);
            ThoughtEngine.DecayThoughts();
            BrainMap.Decay();
            Intuition.GenerateInsight(this);
            DynamicBeliefs.ResolveContradictions(Conflict, Emotions);
            Philosophy.Update(this);
            InternalNarrative.GenerateReflection(this);
            InternalNarrative.InteractWithSubvoices(Subvoices);
        }
    }
}

