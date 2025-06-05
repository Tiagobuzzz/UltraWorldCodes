using System;
using System.Linq;
using UltraWorldAI.Religion;

namespace UltraWorldAI
{
    public class Mind
    {
        private static readonly Random _random = new();
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
        public IdeaEngine IdeaEngine { get; private set; }
        public ThoughtSystem ThoughtEngine { get; private set; }
        public BrainwireSystem BrainMap { get; private set; }
        public IntuitionSystem Intuition { get; private set; }
        public SymbolicMind Symbols { get; private set; }
        public SymbolicExpressionSystem Expressions { get; private set; }
        public GoalSystem Goals { get; private set; }
        public SimulationSystem Simulation { get; private set; }
        public SubpersonalitySystem Subvoices { get; private set; }
        public SocialSystem Social { get; private set; }
        public ReputationSystem Reputation { get; private set; }
        public RitualSystem Rituals { get; private set; }
        public TraditionSystem Traditions { get; private set; }
        public CultureSystem Cultures { get; private set; }
        public ExternalSupportSystem ExternalSupport { get; private set; }
        public PhilosophySystem Philosophy { get; private set; }
        public Thoughts.PhilosophicalIntegrity Integrity { get; private set; }
        public float PhilosophicalIntegrityScore { get; private set; }
        public ContradictionSystem Contradictions { get; private set; }
        public DefenseMechanismSystem Defenses { get; private set; }
        public IntrospectionSystem Introspection { get; private set; }
        public CognitiveFeedbackSystem CognitiveFeedback { get; private set; }
        public DoctrineSystem Doctrines { get; private set; }
        public FaithSystem Faith { get; private set; }
        public LegacySystem Legacy { get; private set; }
        public Thoughts.EthicalJudgment Ethics { get; private set; }
        public Thoughts.LifeNarrative LifeNarrative { get; private set; }
        public Thoughts.HistoricalIdentity History { get; private set; }

        public FrameworkSystem Framework { get; private set; }

        public Territory.HabitatMemory HabitatMemory { get; private set; }
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
            IdeaEngine = new IdeaEngine();
            Integrity = new Thoughts.PhilosophicalIntegrity(IdeaEngine);
            ThoughtEngine = new ThoughtSystem();
            BrainMap = new BrainwireSystem();
            Intuition = new IntuitionSystem();
            Symbols = new SymbolicMind();
            Expressions = new SymbolicExpressionSystem();
            Goals = new GoalSystem();
            Simulation = new SimulationSystem();
            Subvoices = new SubpersonalitySystem();
            Social = new SocialSystem();
            Reputation = new ReputationSystem();
            Rituals = new RitualSystem();
            Traditions = new TraditionSystem();
            Cultures = new CultureSystem();
            ExternalSupport = new ExternalSupportSystem();
            Philosophy = new PhilosophySystem();
            Contradictions = new ContradictionSystem();
            Defenses = new DefenseMechanismSystem();
            Introspection = new IntrospectionSystem();
            CognitiveFeedback = new CognitiveFeedbackSystem();
            Doctrines = new DoctrineSystem();
            Faith = new FaithSystem();
            Legacy = new LegacySystem();
            Ethics = new Thoughts.EthicalJudgment(IdeaEngine);
            LifeNarrative = new Thoughts.LifeNarrative(IdeaEngine);
            History = new Thoughts.HistoricalIdentity();
            HabitatMemory = new Territory.HabitatMemory();
            Framework = new FrameworkSystem(person);
        }

        /// <summary>
        /// Advances all mental subsystems by one simulation step.
        /// </summary>
        public void Update()
        {
            ExternalSupport.EvaluateInfluences(PersonReference);
            UpdateDecaySystems();
            HandleIdeas();
            HandleDefenses();
            UpdateCultureSystems();
        }

        private void UpdateDecaySystems()
        {
            Memory.UpdateMemoryDecay();
            Emotions.UpdateEmotionsDecay();
            Knowledge.DecayFacts();
            Stress.UpdateStressDecay();
            Simulation.Simulate(Emotions, Goals, Memory);
            Subvoices.UpdateInfluences();
            Contradictions.EvaluateContradictions(Goals, Emotions, Subvoices);
            Contradictions.TriggerSelfSabotage(this);
            ThoughtEngine.GenerateThought(this);
            ThoughtEngine.DecayThoughts();
            BrainMap.Decay();
            Intuition.GenerateInsight(this);
            Symbols.DecaySymbols();
            Symbols.GenerateFromEmotion(Emotions);
            Symbols.IntegrateSymbolicMeaning(DynamicBeliefs);
            DynamicBeliefs.ResolveContradictions(Conflict, Emotions);
            PhilosophicalIntegrityScore = Integrity.EvaluateConsistency();
            Philosophy.Update(this);
            InternalNarrative.GenerateReflection(this);
            InternalNarrative.InteractWithSubvoices(Subvoices);
            Introspection.Reflect(this);
            CognitiveFeedback.EvaluateTrajectory(this);
        }

        private void HandleIdeas()
        {
            IdeaNet.GenerateNewIdea("conflito", Emotions, Memory, Beliefs);
            var lastMem = Memory.Memories.LastOrDefault();
            if (lastMem != null && _random.NextDouble() < 0.05)
            {
                IdeaEngine.GenerateIdea(lastMem.Summary, lastMem.Keywords, Emotions);
            }
            if (IdeaEngine.GeneratedIdeas.Any() && _random.NextDouble() < 0.02)
            {
                IdeaEngine.ExpressIdea(IdeaEngine.GeneratedIdeas.Last().Title, this);
            }
            if (_random.NextDouble() < 0.02)
            {
                Expressions.GenerateSymbolFromExperience(PersonReference);
            }
            if (_random.NextDouble() < 0.01)
            {
                Doctrines.EvolveFromSymbolsAndBeliefs(Expressions, Beliefs);
            }
        }

        private void HandleDefenses()
        {
            Defenses.EvaluateDefenses(Conflict, Emotions, DynamicBeliefs);
            if (Defenses.IsEmotionBlocked("sorrow"))
            {
                var s = Emotions.GetEmotion("sorrow") * 0.5f;
                Emotions.SetEmotion("sorrow", s);
            }
            Defenses.Decay();
        }

        private void UpdateCultureSystems()
        {
            if (Beliefs.Beliefs.ContainsKey("memória sagrada") && _random.NextDouble() < 0.01)
            {
                var memory = Memory.Memories.LastOrDefault();
                if (memory != null)
                {
                    Traditions.CreateTradition("lembrança", "manter a conexão com o passado", memory.Summary);
                }
            }

            Cultures.Update(this);
            LifeNarrative.UpdateNarrative();
            Framework.Update();
        }
    }
}

