using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace UltraWorldAI.Security;

/// <summary>
/// Provides simple AES based encryption for communications.
/// </summary>
public static class CommunicationSecurity
{
    public static byte[] Encrypt(string plainText, byte[] key, byte[] iv)
    {
        using var aes = Aes.Create();
        aes.Key = key;
        aes.IV = iv;
        var encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

        using var ms = new MemoryStream();
        using var cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write);
        using var sw = new StreamWriter(cs);
        sw.Write(plainText);
        sw.Close();
        return ms.ToArray();
    }

    public static string Decrypt(byte[] cipherText, byte[] key, byte[] iv)
    {
        using var aes = Aes.Create();
        aes.Key = key;
        aes.IV = iv;
        var decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

        using var ms = new MemoryStream(cipherText);
        using var cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read);
        using var sr = new StreamReader(cs);
        return sr.ReadToEnd();
    }

    public static byte[] GenerateKey() => Aes.Create().Key;
    public static byte[] GenerateIV() => Aes.Create().IV;
}
