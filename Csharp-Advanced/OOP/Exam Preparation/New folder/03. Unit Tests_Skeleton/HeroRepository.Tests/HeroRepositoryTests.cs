using System;
using NUnit.Framework;
[TestFixture]
public class HeroRepositoryTests
{
    private Hero hero;
    private const string DEF_NAME = "Jack";
    private const int DEF_LEVEL = 10;
    private HeroRepository heroRepository;
    [SetUp]
    public void SetUp()
    {
        hero = new Hero(DEF_NAME, DEF_LEVEL);
        heroRepository = new HeroRepository();
    }

    [Test]
    public void HeroConstructor()
    {
        Assert.AreEqual(DEF_LEVEL, hero.Level);
        Assert.AreEqual(DEF_NAME, hero.Name);
    }

    [Test]
    public void HeroRepositoryConstructor()
    {
        Assert.AreEqual(0, heroRepository.Heroes.Count);
    }

    [Test]
    public void CreateMethodAddHero()
    {
        heroRepository.Create(hero);
        Assert.AreEqual(1, heroRepository.Heroes.Count);
    }

    [Test]
    public void CreateMethod_WhenHeroIsNull()
    {
        Assert.Throws<ArgumentNullException>(() => heroRepository.Create(null));
    }

    [Test]
    public void CreateMethod_WhenHeroExist()
    {
        heroRepository.Create(hero);
        Assert.Throws<InvalidOperationException>(() => heroRepository.Create(hero));
    }

    [Test]
    public void CreateMethodReturnMessage()
    {
        var expected = $"Successfully added hero {hero.Name} with level {hero.Level}";
        var actual = heroRepository.Create(hero);
        Assert.AreEqual(expected,actual);
    }

    [Test]
    public void RemoveMethodRemoveHero()
    {
        heroRepository.Create(hero);
        heroRepository.Create(new Hero("another",12));
        heroRepository.Create(new Hero("diffrent",8));
        heroRepository.Remove(hero.Name);
        Assert.AreEqual(2, heroRepository.Heroes.Count);
    }


    [Test]
    public void RemoveMethodReturnsTrueIfRemovesHero()
    {
        heroRepository.Create(hero);
        heroRepository.Create(new Hero("another", 12));
        heroRepository.Create(new Hero("diffrent", 8));
        var expected = true;
        var actual = heroRepository.Remove(hero.Name);
        Assert.AreEqual(expected,actual);
    }

    [Test]
    public void RemoveMethodReturnsFalseIfDontRemoves()
    {
        heroRepository.Create(hero);
        heroRepository.Create(new Hero("another", 12));
        heroRepository.Create(new Hero("diffrent", 8));
        var expected = false;
        var actual = heroRepository.Remove("error");
        Assert.AreEqual(expected, actual);
    }

    [TestCase(null)]
    [TestCase("")]
    [TestCase("  ")]
    public void RemoveMethodWithNameIsNullOrWhiteSpace(string name)
    {
        Assert.Throws<ArgumentNullException>(()=>heroRepository.Remove(name));
    }

    [Test]
    public void GetHeroWithHighestLevelReturnHero()
    {
        var expectedHero = new Hero("another", 12);
        heroRepository.Create(hero);
        heroRepository.Create(expectedHero);
        heroRepository.Create(new Hero("diffrent", 8));

        var actualHero = heroRepository.GetHeroWithHighestLevel();

        Assert.AreEqual(expectedHero, actualHero);
    }

    [Test]
    public void GetHeroReturnHero()
    {
        heroRepository.Create(hero);

        var actual = heroRepository.GetHero(hero.Name);
        var expected = hero;

        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void GetHeroWithNotExistingHero()
    {
        Assert.Null(heroRepository.GetHero(hero.Name));
    }


}