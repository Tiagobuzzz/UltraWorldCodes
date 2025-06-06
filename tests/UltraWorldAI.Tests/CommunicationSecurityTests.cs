using UltraWorldAI.Security;
using Xunit;

public class CommunicationSecurityTests
{
    [Fact]
    public void EncryptAndDecryptReturnsOriginalText()
    {
        var key = CommunicationSecurity.GenerateKey();
        var iv = CommunicationSecurity.GenerateIV();
        var encrypted = CommunicationSecurity.Encrypt("hello", key, iv);
        var decrypted = CommunicationSecurity.Decrypt(encrypted, key, iv);
        Assert.Equal("hello", decrypted);
    }
}
