using UltraWorldAI.Language;
using UltraWorldAI;
using Xunit;

public class LanguagePersonalitySystemTests
{
    [Fact]
    public void ApplyTraitsModifiesPersonality()
    {
        var person = new Person("Falante");
        var before = person.Mind.Personality.GetTrait("Abertura");

        LanguagePersonalitySystem.ApplyTraits(person, "Irith");

        Assert.True(person.Mind.Personality.GetTrait("Abertura") > before);
    }
}
