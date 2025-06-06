using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace UltraWorldAI.Economy;

public class Block
{
    public int Index { get; set; }
    public DateTime Timestamp { get; set; }
    public string Data { get; set; } = string.Empty;
    public string PreviousHash { get; set; } = string.Empty;
    public string Hash { get; set; } = string.Empty;
}

public static class BlockchainLedger
{
    public static List<Block> Chain { get; } = new();

    static BlockchainLedger()
    {
        Initialize();
    }

    public static void Initialize()
    {
        Chain.Clear();
        var genesis = new Block { Index = 0, Timestamp = DateTime.UtcNow, Data = "Genesis", PreviousHash = "0" };
        genesis.Hash = ComputeHash(genesis);
        Chain.Add(genesis);
    }

    public static Block AddBlock(string data)
    {
        var prev = Chain.Last();
        var block = new Block
        {
            Index = prev.Index + 1,
            Timestamp = DateTime.UtcNow,
            Data = data,
            PreviousHash = prev.Hash
        };
        block.Hash = ComputeHash(block);
        Chain.Add(block);
        return block;
    }

    private static string ComputeHash(Block block)
    {
        var raw = $"{block.Index}{block.Timestamp:o}{block.Data}{block.PreviousHash}";
        using var sha = SHA256.Create();
        var bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(raw));
        return Convert.ToHexString(bytes);
    }
}
