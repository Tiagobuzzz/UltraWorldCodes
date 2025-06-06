using System.Collections.Generic;

namespace UltraWorldAI.Civilization;

public class SapientRace
{
    public string Name { get; set; } = string.Empty;
    public string OriginBiome { get; set; } = string.Empty;
    public List<string> DominantGenes { get; set; } = new();
    public List<string> Weaknesses { get; set; } = new();
    public string CognitiveBias { get; set; } = string.Empty;
    public string SociopoliticalTendency { get; set; } = string.Empty;
    public string NaturalAffinity { get; set; } = string.Empty;
    public GenealogyNode GenealogyRoot { get; set; } = new();
}

public class GenealogyNode
{
    public string Name { get; set; } = string.Empty;
    public List<GenealogyNode> Descendants { get; set; } = new();

    public GenealogyNode? Find(string name)
    {
        if (Name == name) return this;
        foreach (var child in Descendants)
        {
            var found = child.Find(name);
            if (found != null) return found;
        }
        return null;
    }

    public void AddDescendant(string ancestorName, string descendantName)
    {
        var node = Find(ancestorName);
        if (node != null)
            node.Descendants.Add(new GenealogyNode { Name = descendantName });
    }
}

public static class RaceRepository
{
    public static List<SapientRace> Races { get; private set; } = new();

    public static void CreateDefaults()
    {
        Races = new List<SapientRace>
        {
            new()
            {
                Name = "Humanos",
                OriginBiome = "Planície Viva",
                DominantGenes = new() { "Adaptação", "Memória Emocional", "Linguagem Expandida" },
                Weaknesses = new() { "Vulnerabilidade Psicológica" },
                CognitiveBias = "Expansão",
                SociopoliticalTendency = "Reinos e Nações",
                NaturalAffinity = "Diversidade Ambiental",
                GenealogyRoot = new GenealogyNode { Name = "Ancestral Humano" }
            },
            new()
            {
                Name = "Elfos",
                OriginBiome = "Floresta Sombria",
                DominantGenes = new() { "Visão Noturna", "Empatia", "Longevidade" },
                Weaknesses = new() { "Estagnação Cultural" },
                CognitiveBias = "Estética",
                SociopoliticalTendency = "Conselhos Eternos",
                NaturalAffinity = "Crescimento Vegetal",
                GenealogyRoot = new GenealogyNode { Name = "Ancestral Élfico" }
            },
            new()
            {
                Name = "Anões",
                OriginBiome = "Montanha Cantante",
                DominantGenes = new() { "Resistência Óssea", "Trabalho Artesanal", "Foco Genético" },
                Weaknesses = new() { "Baixa Adaptação Climática" },
                CognitiveBias = "Precisão",
                SociopoliticalTendency = "Clãs",
                NaturalAffinity = "Pedra e Metal",
                GenealogyRoot = new GenealogyNode { Name = "Ancestral Anão" }
            },
            new()
            {
                Name = "Gigantes",
                OriginBiome = "Planaltos Isolados",
                DominantGenes = new() { "Força Bruta", "Lentidão Mental", "Memória Profunda" },
                Weaknesses = new() { "Densidade de População", "Comida em Excesso" },
                CognitiveBias = "Sobrevivência Territorial",
                SociopoliticalTendency = "Alianças Temporais",
                NaturalAffinity = "Céu e Montanhas",
                GenealogyRoot = new GenealogyNode { Name = "Ancestral Gigante" }
            },
            new()
            {
                Name = "Reptilianos",
                OriginBiome = "Deserto Vazio",
                DominantGenes = new() { "Pele Escamosa", "Regulação de Calor", "Agressividade Condicionada" },
                Weaknesses = new() { "Baixo Laço Social" },
                CognitiveBias = "Supremacia Territorial",
                SociopoliticalTendency = "Impérios Brutalistas",
                NaturalAffinity = "Calor, Pedra e Subterrâneo",
                GenealogyRoot = new GenealogyNode { Name = "Ancestral Reptiliano" }
            },
            new()
            {
                Name = "Fae",
                OriginBiome = "Bosque Nebuloso",
                DominantGenes = new() { "Magnetismo Mental", "Camuflagem Instintiva", "Pele Translúcida" },
                Weaknesses = new() { "Fragilidade Física", "Impulsividade Sensorial" },
                CognitiveBias = "Liberdade Instintiva",
                SociopoliticalTendency = "Sementes de Coletivos Temporários",
                NaturalAffinity = "Névoa, Flores e Luar",
                GenealogyRoot = new GenealogyNode { Name = "Ancestral Fae" }
            },
            new()
            {
                Name = "Tieflings",
                OriginBiome = "Terras Queimadas",
                DominantGenes = new() { "Resistência ao Calor", "Irradiação Etérica", "Olhos Infernais" },
                Weaknesses = new() { "Preconceito Ancestral", "Risco de Transcendência Instável" },
                CognitiveBias = "Sobrevivência Emocional",
                SociopoliticalTendency = "Códigos Internos Orais",
                NaturalAffinity = "Fendas, Cinzas, Rejeição",
                GenealogyRoot = new GenealogyNode { Name = "Ancestral Tiefling" }
            },
            new()
            {
                Name = "Atlantes",
                OriginBiome = "Abismo Oceânico",
                DominantGenes = new() { "Brânquias Cerebrais", "Telepatia Aquática", "Visão de Profundidade" },
                Weaknesses = new() { "Secura Letal", "Tecnologia Instável" },
                CognitiveBias = "Mistério",
                SociopoliticalTendency = "Domínios Silenciosos",
                NaturalAffinity = "Água Densa e Pressão",
                GenealogyRoot = new GenealogyNode { Name = "Ancestral Atlante" }
            },
            new()
            {
                Name = "Insectoides",
                OriginBiome = "Colméias de Cristal",
                DominantGenes = new() { "Mente Coletiva", "Exoesqueleto Modular", "Ovo Simbiótico" },
                Weaknesses = new() { "Padrões Fixos de Comportamento" },
                CognitiveBias = "Eficiência",
                SociopoliticalTendency = "Arquitetura de Casta",
                NaturalAffinity = "Subsolo, Mel, Comunicação Química",
                GenealogyRoot = new GenealogyNode { Name = "Ancestral Insectoide" }
            }
        };
    }

    public static string ListAll()
    {
        return string.Join("\n\n", Races.ConvertAll(r =>
            $"\uD83D\uDC64 {r.Name}\nBiome: {r.OriginBiome} | Tendência: {r.SociopoliticalTendency}\n" +
            $"Genes: {string.Join(", ", r.DominantGenes)}\nFraquezas: {string.Join(", ", r.Weaknesses)}\n" +
            $"Afinidade: {r.NaturalAffinity} | Tendência Cognitiva: {r.CognitiveBias}"));
    }
}
