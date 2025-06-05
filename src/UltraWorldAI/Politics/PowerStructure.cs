using System.Collections.Generic;

namespace UltraWorldAI.Politics;

public enum AuthorityBase
{
    Sangue,
    Fe,
    Sabedoria,
    Forca,
    Memoria,
    Voto,
    Ritual
}

public enum GovernmentType
{
    Monarquia,
    Teocracia,
    Republica,
    Ditadura,
    ConselhoTribal,
    AnarquiaSimbolica
}

public class PowerStructure
{
    public string Name { get; set; } = string.Empty;
    public GovernmentType Type { get; set; }
    public AuthorityBase BaseOfPower { get; set; }
    public string CurrentLeader { get; set; } = string.Empty;
    public bool IsStable { get; set; }
    public List<string> Laws { get; set; } = new();
    public List<string> SymbolsOfPower { get; set; } = new();
    public string CapitalRegion { get; set; } = string.Empty;
}

public static class GovernmentFactory
{
    public static PowerStructure CreateGovernment(string name, GovernmentType type, AuthorityBase basis, string leader, string capital)
    {
        var gov = new PowerStructure
        {
            Name = name,
            Type = type,
            BaseOfPower = basis,
            CurrentLeader = leader,
            IsStable = true,
            CapitalRegion = capital,
            Laws = GenerateLaws(type, basis),
            SymbolsOfPower = GenerateSymbols(type, basis)
        };

        return gov;
    }

    private static List<string> GenerateLaws(GovernmentType type, AuthorityBase basis)
    {
        var laws = new List<string>();

        if (basis == AuthorityBase.Fe) laws.Add("A palavra do Deus é final.");
        if (basis == AuthorityBase.Sangue) laws.Add("A linhagem não pode ser interrompida.");
        if (type == GovernmentType.Republica) laws.Add("O povo deve escolher por palavra ou gesto.");
        if (type == GovernmentType.ConselhoTribal) laws.Add("Toda decisão nasce do círculo.");

        return laws;
    }

    private static List<string> GenerateSymbols(GovernmentType type, AuthorityBase basis)
    {
        var list = new List<string>();
        if (basis == AuthorityBase.Memoria) list.Add("Livro gravado com sangue");
        if (type == GovernmentType.Teocracia) list.Add("Máscara de oração");
        if (basis == AuthorityBase.Forca) list.Add("Martelo marcado com cicatriz");
        return list;
    }

    public static string Describe(PowerStructure gov)
    {
        return $"👑 Reino: {gov.Name} ({gov.Type})\n" +
               $"Base de poder: {gov.BaseOfPower}\n" +
               $"Líder: {gov.CurrentLeader} / Capital: {gov.CapitalRegion}\n" +
               $"Estável: {gov.IsStable}\n" +
               $"Leis: {string.Join(", ", gov.Laws)}\n" +
               $"Símbolos: {string.Join(", ", gov.SymbolsOfPower)}";
    }
}
