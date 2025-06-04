using System;

using System.Collections.Generic;

using System.Linq;

using System.IO; // Para Serialização/Desserialização, se você for implementar isso mais tarde
using System.Text.Json;



namespace UltraWorldAI

{

    // ESTRUTURAS E ENUMS

    public enum LifeStage

    {

        Infantil,

        Crianca,

        Adolescente,

        Adulto,

        Idoso

    }



    // --- CONFIGURAÇÕES GLOBAIS (PARAMETRIZAÇÃO DE "MAGIC NUMBERS") ---

    public static class AIConfig

    {

        public const int MaxMemories = 100;

        public const float MemoryDecayRate = 0.01f;

        public const float ForgottenMemoryThreshold = 0.1f;



        public const float EmotionDecayHappiness = -0.01f;

        public const float EmotionDecayFear = -0.05f;

        public const float EmotionDecayAnger = -0.05f;

        public const float EmotionDecayLove = -0.01f;

        public const float EmotionDecaySorrow = -0.02f;

        public const float EmotionDecayCuriosity = -0.01f;



        public const float TraitMin = 0f;

        public const float TraitMax = 1f;

        public const float EmotionMin = 0f;


        public const float AffinityMin = 0f;

        public const float AffinityMax = 1f;



        public const float StressIncreasePerContradiction = 0.1f; // Quanto de estresse uma contradição gera

        public const float StressReductionPerDefense = 0.05f;    // Quanto de estresse é aliviado ao usar uma defesa

        public const float StressDecayRate = 0.01f;               // Quanto estresse decai por tick



        public const float MaxStress = 1.0f;

        public const float MinStress = 0.0f;

    }

    public static class AISettings
    {
        public static int MaxMemories = AIConfig.MaxMemories;
        public static void Load(string path)
        {
            if (!File.Exists(path)) return;
            var json = File.ReadAllText(path);
            var data = JsonSerializer.Deserialize<Dictionary<string, float>>(json);
            if (data == null) return;
            if (data.TryGetValue("MaxMemories", out var mm)) MaxMemories = (int)mm;
        }
    }

    public static class Logger
    {
        public static void Log(string message) => Console.WriteLine(message);
    }



    // CLASSES BASE PARA O SISTEMA DE IA



    public class Memory

    {

        public string Summary { get; set; }

        public DateTime Date { get; set; }

        public float Intensity { get; set; } // De 0.0 a 1.0

        public float EmotionalCharge { get; set; } // Quão emocionalmente carregada é a memória

        public List<string> Keywords { get; set; } // Para buscas e associações

        public string Source { get; set; } // Quem ou o que gerou a memória



        public Memory()

        {

            Keywords = new List<string>();

        }

    }



    public class MemorySystem

    {

        public List<Memory> Memories { get; private set; } = new List<Memory>();



        public void AddMemory(string summary, float intensity = 0.5f, float emotionalCharge = 0.0f, List<string> keywords = null, string source = "self")

        {

            if (Memories.Count >= AISettings.MaxMemories)

            {

                // Implementar estratégia de esquecimento ou compressão

                ForgetLeastImportantMemory();

            }

            Memories.Add(new Memory

            {

                Summary = summary,

                Date = DateTime.Now,

                Intensity = Math.Clamp(intensity, 0f, 1f),

                EmotionalCharge = Math.Clamp(emotionalCharge, -1f, 1f), // Pode ser positiva ou negativa

                Keywords = keywords ?? new List<string>(),

                Source = source

            });

            // Ordenar por data para facilitar acesso recente

            Memories = Memories.OrderByDescending(m => m.Date).ToList();

        }



        private void ForgetLeastImportantMemory()

        {

            // Remover memórias muito antigas ou de baixa intensidade

            Memories.RemoveAll(m => m.Intensity < AIConfig.ForgottenMemoryThreshold || (DateTime.Now - m.Date).TotalDays > 365); // Exemplo: esquece depois de 1 ano

            if (Memories.Count >= AISettings.MaxMemories)

            {

                // Se ainda estiver cheio, remove a de menor intensidade

                var leastImportant = Memories.OrderBy(m => m.Intensity).ThenBy(m => m.Date).FirstOrDefault();

                if (leastImportant != null)

                {

                    Memories.Remove(leastImportant);

                }

            }

        }



        public void UpdateMemoryDecay()

        {

            foreach (var mem in Memories)

            {

                mem.Intensity = Math.Max(0, mem.Intensity - AIConfig.MemoryDecayRate);

            }

            Memories.RemoveAll(m => m.Intensity <= AIConfig.ForgottenMemoryThreshold);

        }

        public void SaveMemories(string path)
        {
            var json = JsonSerializer.Serialize(Memories);
            File.WriteAllText(path, json);
        }

        public void LoadMemories(string path)
        {
            if (!File.Exists(path)) return;
            var json = File.ReadAllText(path);
            var mems = JsonSerializer.Deserialize<List<Memory>>(json);
            if (mems != null) Memories = mems;
        }



        public List<Memory> RetrieveMemories(string keyword, int count = 5)

        {

            return Memories.Where(m => m.Keywords.Contains(keyword) || m.Summary.Contains(keyword))

                           .OrderByDescending(m => m.Intensity)

                           .Take(count)

                           .ToList();

        }

    }



    public class BeliefSystem

    {

        public Dictionary<string, float> Beliefs { get; private set; } = new Dictionary<string, float>(); // Beliefs with strength (0.0 to 1.0)



        public BeliefSystem()

        {

            // Populate some initial beliefs for testing

            Beliefs.Add("Paz", 0.9f);

            Beliefs.Add("Justiça", 0.8f);

            Beliefs.Add("Comunidade", 0.7f);

            Beliefs.Add("Conhecimento é poder", 0.75f);

            Beliefs.Add("Autoconfiança é essencial", 0.6f);

        }



        public void UpdateBelief(string belief, float change)

        {

            if (Beliefs.ContainsKey(belief))

            {

                Beliefs[belief] = Math.Clamp(Beliefs[belief] + change, 0f, 1f);

            }

            else

            {

                Beliefs.Add(belief, Math.Clamp(change, 0f, 1f));

            }

        }

    }



    public class PersonalitySystem

    {

        public Dictionary<string, float> Traits { get; private set; } = new Dictionary<string, float>(); // Example traits (Big Five, 0.0 to 1.0)



        public PersonalitySystem()

        {

            // Initializing example traits based on Big Five

            Traits.Add("Abertura", 0.7f);         // Openness to experience (curiosity, imagination)

            Traits.Add("Conscienciosidade", 0.6f); // Conscientiousness (organization, discipline)

            Traits.Add("Extroversão", 0.5f);     // Extroversion (sociability, assertiveness)

            Traits.Add("Amabilidade", 0.8f);     // Agreeableness (cooperation, empathy)

            Traits.Add("Neuroticismo", 0.3f);    // Neuroticism (emotional instability, anxiety - lower is better)

        }



        public float GetTrait(string traitName)

        {

            return Traits.TryGetValue(traitName, out float value) ? value : 0.5f; // Default if not found

        }



        public void SetTrait(string traitName, float value)

        {

            Traits[traitName] = Math.Clamp(value, AIConfig.TraitMin, AIConfig.TraitMax);

        }

    }



    public class EmotionSystem

    {

        public Dictionary<string, float> Emotions { get; private set; } = new Dictionary<string, float>();



        public EmotionSystem()

        {

            Emotions.Add("happiness", 0.5f);

            Emotions.Add("fear", 0.2f);

            Emotions.Add("anger", 0.1f);

            Emotions.Add("love", 0.3f);

            Emotions.Add("sorrow", 0.1f);

            Emotions.Add("curiosity", 0.4f);

        }



        public string GetDominantEmotion()

        {

            if (!Emotions.Any()) return "neutral";

            return Emotions.OrderByDescending(e => e.Value).FirstOrDefault().Key;

        }



        public float GetEmotion(string emotionName)

        {

            return Emotions.TryGetValue(emotionName, out float value) ? value : 0f;

        }



        public void SetEmotion(string emotionName, float value)

        {

            Emotions[emotionName] = Math.Clamp(value, AIConfig.EmotionMin, AIConfig.EmotionMax);

        }



        public void UpdateEmotionsDecay()

        {

            foreach (var key in Emotions.Keys.ToList())

            {

                float decayRate = 0f;

                switch (key)

                {

                    case "happiness": decayRate = AIConfig.EmotionDecayHappiness; break;

                    case "fear": decayRate = AIConfig.EmotionDecayFear; break;

                    case "anger": decayRate = AIConfig.EmotionDecayAnger; break;

                    case "love": decayRate = AIConfig.EmotionDecayLove; break;

                    case "sorrow": decayRate = AIConfig.EmotionDecaySorrow; break;

                    case "curiosity": decayRate = AIConfig.EmotionDecayCuriosity; break;

                }

                SetEmotion(key, Emotions[key] + decayRate);

            }

        }

    }



    public class MetacognitionSystem

    {

        private Person _person;

        public List<string> SelfImage { get; private set; } = new List<string>(); // Aspects of self-image



        public MetacognitionSystem(Person person)

        {

            _person = person;

            // Initialize self-image based on initial traits or default values

            SelfImage.Add("paciente");

            SelfImage.Add("sociável");

            SelfImage.Add("justo");

            SelfImage.Add("curioso");

        }



        public void AddToSelfImage(string aspect)

        {

            if (!SelfImage.Contains(aspect))

            {

                SelfImage.Add(aspect);

                Logger.Log($"[Metacognition] {_person.Name}'s self-image now includes: {aspect}");

            }

        }



        public void RemoveFromSelfImage(string aspect)

        {

            if (SelfImage.Remove(aspect))

            {

                Logger.Log($"[Metacognition] {_person.Name}'s self-image no longer includes: {aspect}");

            }

        }

    }



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
                _person.Mind.Stress.AddStress(AIConfig.StressIncreasePerContradiction); // Contradição aumenta o estresse

            }

        }



        public void ResolveContradiction(string contradictionIdentifier)

        {

            // Pode ser mais sofisticado, buscando o identificador correto ou parte dele

            var resolved = ActiveContradictions.RemoveAll(c => c.Contains(contradictionIdentifier));

            if (resolved > 0)
                ContradictionResolved?.Invoke(contradictionIdentifier);


                Logger.Log($"[Conflict] {_person.Name} has resolved/mitigated contradiction.");

                _person.Mind.Stress.ReduceStress(AIConfig.StressReductionPerDefense * resolved); // Reduz o estresse ao resolver

            }

        }



        public bool HasActiveContradictions()

        {

            return ActiveContradictions.Any();

        }

    }



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

            if (amount > 0)

            {

                // Console.WriteLine($"[Stress] {_person.Name} stress increased to: {CurrentStressLevel:F2}");

            }

        }



        public void ReduceStress(float amount)

        {

            CurrentStressLevel = Math.Max(AIConfig.MinStress, CurrentStressLevel - amount);

            if (amount > 0)

            {

                // Console.WriteLine($"[Stress] {_person.Name} stress reduced to: {CurrentStressLevel:F2}");

            }

        }



        public void UpdateStressDecay()

        {

            ReduceStress(AIConfig.StressDecayRate);

        }



        public bool IsStressed()

        {

            return CurrentStressLevel > 0.5f; // Limiar para considerar estressado

        }

    }





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

            Narrative = new NarrativeEngine(person);

        }



        public void Update()

        {

            Memory.UpdateMemoryDecay();

            Emotions.UpdateEmotionsDecay();

            Stress.UpdateStressDecay();

            // Outras atualizações de sistema aqui, como processos de pensamento, etc.

        }

    }



    public class Person

    {

        public string Name { get; set; }

        public Mind Mind { get; private set; }

        public LifeStage CurrentLifeStage { get; set; } = LifeStage.Adult; // Default



        public Person(string name)

        {

            Name = name;

            Mind = new Mind(this);

        }



        public string ReflectOnSelf()

        {

            return Mind.Narrative.GenerateReflection();

        }



        public void AddExperience(string summary, float intensity = 0.5f, float emotionalCharge = 0.0f, List<string> keywords = null, string source = "self")

        {

            Mind.Memory.AddMemory(summary, intensity, emotionalCharge, keywords, source);

            Logger.Log($"\n[{Name} Experience] '{summary}' (Intensity: {intensity}, Emotion: {emotionalCharge})");

        }



        public void Update()

        {

            Mind.Update(); // Atualiza todos os subsistemas internos

        }

    }



    // -------------------------------------------------------------

    // O NARRATIVEENGINE APRIMORADO PARA DEFESA PSICOLÓGICA

    // -------------------------------------------------------------

    public class NarrativeEngine

    {

        private readonly Person _person;

        private Random _random = new Random();



        public NarrativeEngine(Person person)

        {

            _person = person;

        }



        public string GenerateReflection()

        {

            var memories = _person.Mind.Memory.Memories;

            var beliefs = _person.Mind.Beliefs;

            var personality = _person.Mind.Personality;

            var selfImage = _person.Mind.Meta.SelfImage;

            var dominantEmotion = _person.Mind.Emotions.GetDominantEmotion();

            var currentStress = _person.Mind.Stress.CurrentStressLevel;



            var reflectionNarratives = new List<string>();

            var contradictionsDetected = new List<Tuple<string, string, string, float, string>>(); // BaseContradiction, SelfAspect, ConflictingAction, MemoryIntensity, MemorySummary



            // --- 1. Análise de ações contraditórias com autoimagem ---

            var recentAndSignificantMemories = memories

                .OrderByDescending(m => m.Date)

                .Take(7)

                .Union(memories.OrderByDescending(m => m.Intensity).Take(3))

                .Distinct()

                .ToList();



            foreach (var mem in recentAndSignificantMemories)

            {

                // Exemplo 1: Paciência vs. Ação Impulsiva/Confronto

                if (mem.Summary.Contains("confrontou") && selfImage.Contains("paciente"))

                {

                    contradictionsDetected.Add(Tuple.Create(

                        $"Eu me vejo como paciente, mas recentemente '{mem.Summary}'.",

                        "paciente", "impulsividade", mem.Intensity, mem.Summary));

                }

                // Exemplo 2: Sociabilidade vs. Isolamento

                else if (mem.Summary.Contains("isolou") && selfImage.Contains("sociável"))

                {

                    contradictionsDetected.Add(Tuple.Create(

                        $"Eu me considero sociável, mas tenho sentido a necessidade de '{mem.Summary}'.",

                        "sociável", "isolamento", mem.Intensity, mem.Summary));

                }

                // Exemplo 3: Justiça vs. Ação Questionável

                else if (mem.Summary.Contains("trapaceou") && selfImage.Contains("justo"))

                {

                    contradictionsDetected.Add(Tuple.Create(

                        $"Acredito ser justo, mas houve um momento em que eu '{mem.Summary}'.",

                        "justo", "injustiça", mem.Intensity, mem.Summary));

                }

                // Adicione mais regras de contradição aqui conforme necessário

            }



            // --- 2. Emoções dominantes que desafiam crenças/autoimagem ---

            if (dominantEmotion == "anger" && beliefs.Beliefs.TryGetValue("Paz", out float peaceBeliefStrength) && peaceBeliefStrength > 0.7f)

            {

                contradictionsDetected.Add(Tuple.Create(

                    $"Estou sentindo muita raiva, e isso vai contra meus valores de paz.",

                    "pacífico", "raiva", _person.Mind.Emotions.GetEmotion("anger") * 0.8f, "estado emocional"));

            }

            // Adicione mais regras de emoção-crença aqui



            // Processa cada contradição detectada

            foreach (var contradictionData in contradictionsDetected)

            {

                string baseContradiction = contradictionData.Item1;

                string selfAspect = contradictionData.Item2;

                string conflictingAction = contradictionData.Item3;

                float memoryIntensity = contradictionData.Item4;

                string memorySummary = contradictionData.Item5;



                // Trigger the contradiction in the conflict system

                _person.Mind.Conflict.TriggerContradiction(selfAspect, conflictingAction, memorySummary);

                reflectionNarratives.Add(HandleContradiction(baseContradiction, selfAspect, conflictingAction, memoryIntensity, memorySummary));

            }



            // --- 3. Tentativas de coerência e narrativa de "dia a dia" ---

            if (!reflectionNarratives.Any())

            {

                reflectionNarratives.Add(GenerateCoherentNarrative());

            }

            else

            {

                reflectionNarratives.Add($"Apesar dessas reflexões, {_person.Name} busca um equilíbrio interno. Sinto que, no geral, minhas ações refletem quem eu sou. Ou talvez, estou em constante mudança.");

            }



            if (!reflectionNarratives.Any())

            {

                reflectionNarratives.Add($"Hoje, {_person.Name} refletiu sobre suas experiências, buscando entender seu lugar no mundo.");

            }



            return string.Join("\n", reflectionNarratives.Where(s => !string.IsNullOrWhiteSpace(s)));

        }



        private string HandleContradiction(string baseContradiction, string selfAspect, string conflictingAction, float memoryIntensity, string memorySummary)

        {

            // Fatores que influenciam a escolha da defesa:

            float openness = _person.Mind.Personality.GetTrait("Abertura");

            float conscientiousness = _person.Mind.Personality.GetTrait("Conscienciosidade");

            float neuroticism = _person.Mind.Personality.GetTrait("Neuroticismo"); // Estabilidade emocional (alto neuroticismo = instabilidade, ansiedade)

            float stressLevel = _person.Mind.Stress.CurrentStressLevel;



            // Define limiares e pesos para os mecanismos de defesa

            // Prioridade: Justificação > Ajuste/Racionalização > Negação/Projeção > Repressão (último recurso)



            double justificationWeight = 0.5 + (conscientiousness * 0.3) - (stressLevel * 0.1) - (neuroticism * 0.1);

            double adjustmentWeight = 0.3 + (openness * 0.4) - (stressLevel * 0.2);

            double rationalizationWeight = 0.4 + (conscientiousness * 0.2) + (stressLevel * 0.1);

            double denialWeight = 0.2 + (neuroticism * 0.3) + (stressLevel * 0.2);

            double projectionWeight = 0.1 + (neuroticism * 0.2) + (stressLevel * 0.15);

            double repressionWeight = 0.05 + (stressLevel * 0.3) + (memoryIntensity * 0.2);



            // Normaliza os pesos para que somem 1, priorizando a mais alta

            // Este método de normalização pode ser aprimorado, mas é um ponto de partida.

            double totalWeight = justificationWeight + adjustmentWeight + rationalizationWeight + denialWeight + projectionWeight + repressionWeight;



            justificationWeight /= totalWeight;

            adjustmentWeight /= totalWeight;

            rationalizationWeight /= totalWeight;

            denialWeight /= totalWeight;

            projectionWeight /= totalWeight;

            repressionWeight /= totalWeight;



            double roll = _random.NextDouble();

            string reflection = "";



            // Seleciona o mecanismo de defesa

            if (roll < justificationWeight)

            {

                reflection = TryJustify(baseContradiction, selfAspect, conflictingAction, memorySummary);

            }

            else if (roll < justificationWeight + adjustmentWeight)

            {

                reflection = TryAdjustSelfImage(baseContradiction, selfAspect, conflictingAction);

            }

            else if (roll < justificationWeight + adjustmentWeight + rationalizationWeight)

            {

                reflection = TryRationalize(baseContradiction, selfAspect, conflictingAction);

            }

            else if (roll < justificationWeight + adjustmentWeight + rationalizationWeight + denialWeight)

            {

                reflection = TryDeny(baseContradiction, selfAspect, conflictingAction);

            }

            else if (roll < justificationWeight + adjustmentWeight + rationalizationWeight + denialWeight + projectionWeight)

            {

                reflection = TryProject(baseContradiction, selfAspect, conflictingAction);

            }

            else

            {

                reflection = TryRepress(baseContradiction, selfAspect, conflictingAction);

            }



            // Uma vez que um mecanismo de defesa é usado, o conflito pode ser "resolvido" ou mitigado

            _person.Mind.Conflict.ResolveContradiction($"Contradiction detected: Self-image '{selfAspect}' vs. '{conflictingAction}'");



            return reflection;

        }



        // --- Mecanismos de Defesa Detalhados ---



        private string TryJustify(string baseContradiction, string selfAspect, string conflictingAction, string memorySummary)

        {

            var justificationOptions = new List<string>();



            if (conflictingAction.Contains("impulsividade"))

            {

                justificationOptions.Add($"A situação exigia uma resposta imediata. Minha paciência seria uma desvantagem.");

                justificationOptions.Add($"Foi um momento de forte emoção, mas isso não anula meu eu paciente. Foi uma exceção compreensível.");

            }

            else if (conflictingAction.Contains("isolamento"))

            {

                justificationOptions.Add($"Eu precisava de um tempo para introspecção. Mesmo os sociáveis precisam de momentos de quietude.");

                justificationOptions.Add($"O ambiente não estava propício para interações significativas. Não valia a pena o esforço.");

            }

            else if (conflictingAction.Contains("injustiça"))

            {

                justificationOptions.Add($"As circunstâncias me forçaram a tomar uma decisão 'menos que ideal' para um bem maior. O contexto importa.");

                justificationOptions.Add($"Não era uma questão de justiça no sentido puro, mas de pragmatismo para evitar um mal ainda maior.");

            }

            else if (conflictingAction.Contains("raiva"))

            {

                justificationOptions.Add($"Minha raiva é uma resposta natural e justa à provocação. Isso não significa que não valorize a paz.");

                justificationOptions.Add($"A raiva me impulsionou a agir contra a injustiça, servindo a um propósito positivo, apesar do desconforto.");

            }



            string justification = justificationOptions.Any() ? justificationOptions[_random.Next(justificationOptions.Count)] :

                                                                $"Houve uma boa razão para o que aconteceu. Não é o que parece à primeira vista.";

            return $"{baseContradiction} No entanto, {_person.Name} ponderou: \"{justification}\"";

        }



        private string TryRationalize(string baseContradiction, string selfAspect, string conflictingAction)

        {

            var rationalizationOptions = new List<string>();



            if (conflictingAction.Contains("impulsividade"))

            {

                rationalizationOptions.Add($"Minha 'impulsividade' foi na verdade uma demonstração de decisão rápida e eficiência, algo que eu valorizo.");

            }

            else if (conflictingAction.Contains("isolamento"))

            {

                rationalizationOptions.Add($"Este 'isolamento' foi uma oportunidade estratégica para desenvolver novas habilidades, otimizando meu tempo.");

            }

            else if (conflictingAction.Contains("injustiça"))

            {

                rationalizationOptions.Add($"A ação que pareceu injusta foi, na realidade, um cálculo complexo para reequilibrar o sistema a longo prazo.");

            }

            else if (conflictingAction.Contains("raiva"))

            {

                rationalizationOptions.Add($"A raiva que senti era meramente um catalisador energético, uma resposta fisiológica para aumentar meu foco.");

            }



            string rationalization = rationalizationOptions.Any() ? rationalizationOptions[_random.Next(rationalizationOptions.Count)] :

                                                                $"Se eu analisar bem, minha ação foi perfeitamente lógica e consistente com meus objetivos mais profundos.";

            return $"{baseContradiction} Mas {_person.Name} racionalizou: \"{rationalization}\"";

        }



        private string TryAdjustSelfImage(string baseContradiction, string oldSelfAspect, string newConflictingAspect)

        {

            _person.Mind.Meta.RemoveFromSelfImage(oldSelfAspect);

            if (!oldSelfAspect.Contains("pacífico") && !oldSelfAspect.Contains("justo")) // Core beliefs/values might be harder to remove entirely

            {

                _person.Mind.Meta.AddToSelfImage(newConflictingAspect);

            }

            else

            {

                _person.Mind.Meta.AddToSelfImage($"ocasionalmente-{newConflictingAspect}"); // Adiciona um qualificador

            }



            return $"{baseContradiction} Talvez eu não seja tão '{oldSelfAspect}' quanto pensava. Talvez eu esteja evoluindo para algo mais '{newConflictingAspect}'.";

        }



        private string TryDeny(string baseContradiction, string selfAspect, string conflictingAction)

        {

            return $"{baseContradiction} {_person.Name} refutou a ideia: \"Isso não é verdade. Não reflete quem eu sou de forma alguma. Deve ter sido um mal-entendido ou uma percepção distorcida da situação.\"";

        }



        private string TryProject(string baseContradiction, string selfAspect, string conflictingAction)

        {

            return $"{baseContradiction} {_person.Name} pensou: \"Na verdade, a culpa não foi minha. Foi a situação externa que me obrigou a agir, ou foi a falha de {(_random.NextDouble() > 0.5 ? "outra pessoa" : "o ambiente")} que me levou a isso.\"";

        }



        private string TryRepress(string baseContradiction, string selfAspect, string conflictingAction)

        {

            // Tenta "esquecer" a memória para reduzir a dissonância.

            // Para ser mais robusto, você poderia marcar a memória como "reprimida" e torná-la inacessível na maioria das buscas,

            // mas ainda potencialmente recuperável sob certas condições (ex: trauma, hipnose simulada).

            _person.Mind.Memory.Memories.RemoveAll(m => m.Summary.Contains(conflictingAction) && m.Intensity > 0.5f); // Remove a memória diretamente para este exemplo.

            _person.Mind.Stress.AddStress(0.2f); // Repressão a longo prazo pode ser custosa, aumentando o estresse basal.



            return $"{baseContradiction} {_person.Name} sentiu um estranho vazio ao tentar se aprofundar, como se a memória estivesse... embaçada. Parece que não consigo pensar nisso agora.";

        }



        private string GenerateCoherentNarrative()

        {

            var selfImage = _person.Mind.Meta.SelfImage;

            var dominantEmotion = _person.Mind.Emotions.GetDominantEmotion();



            string coherentNarrative = $"No geral, {_person.Name} sente que suas ações recentes estão alinhadas com sua autoimagem de {string.Join(", ", selfImage)}. ";



            switch (dominantEmotion)

            {

                case "happiness":

                    coherentNarrative += $"Há uma sensação de contentamento e as coisas parecem estar no caminho certo.";

                    break;

                case "fear":

                    coherentNarrative += $"Apesar de tudo, uma ponta de apreensão persiste, indicando algo a ser observado.";

                    break;

                case "anger":

                    coherentNarrative += $"Mesmo em momentos de paz, uma chama de indignação arde, talvez por alguma injustiça percebida.";

                    break;

                case "curiosity":

                    coherentNarrative += $"Uma curiosidade constante guia suas reflexões, sempre em busca de novos entendimentos.";

                    break;

                case "sorrow":

                    coherentNarrative += $"Uma leve tristeza permeia seus pensamentos, uma aceitação melancólica de algum evento passado.";

                    break;

                default:

                    coherentNarrative += $"A vida segue seu curso, e {_person.Name} busca manter o equilíbrio.";

                    break;

            }

            return coherentNarrative;

        }

    }

}
