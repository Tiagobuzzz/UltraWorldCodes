using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text.Json;

namespace UltraWorldAI
{
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
