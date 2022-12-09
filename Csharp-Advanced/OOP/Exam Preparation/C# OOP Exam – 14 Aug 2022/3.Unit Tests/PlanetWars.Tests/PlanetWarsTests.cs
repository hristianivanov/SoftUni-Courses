namespace PlanetWars.Tests
{
    using System;
    using System.Linq;

    using NUnit.Framework;

    public class Tests
    {
        [TestFixture]
        public class PlanetWarsTests
        {
            private Weapon weapon;
            private string defWeaponName = "bomb";
            private double defPrice = 12.3;
            private int defDesctructionLevel = 8;

            private string defPlanetName = "planetN";
            private double defBudget;
            private Planet planet;

            [SetUp]
            public void SetUp()
            {
                weapon = new Weapon(defWeaponName, defPrice, defDesctructionLevel);
            }
            [Test]
            public void Test_ConstructorShouldSetPropertyValuesCorrectly()
            {
                string expectedName = "bomb";
                double expectedPrice = 12.3;
                int expectedDesctructionLevel = 8;

                Assert.AreEqual(expectedName, weapon.Name);
                Assert.AreEqual(expectedPrice, weapon.Price);
                Assert.AreEqual(expectedDesctructionLevel, weapon.DestructionLevel);
            }

            [Test]
            public void Test_NameSetShouldWork()
            {
                string expectedName = "another";
                weapon.Name = "another";

                Assert.AreEqual(expectedName, weapon.Name);
            }

            [TestCase(-1)]
            [TestCase(-49)]
            public void Test_PriceShouldThrowException_WhenIsNegative(double price)
            {
                Assert.Throws<ArgumentException>(() =>
                {
                    weapon.Price = price;
                });
            }

            [Test]
            public void Test_DestructionLevelSetterShouldWork()
            {
                int expecteddesctructionLevel = 4;
                weapon.DestructionLevel = 4;

                Assert.AreEqual(expecteddesctructionLevel, weapon.DestructionLevel);
            }

            [Test]
            public void Test_IncreaseDestructionLevelShouldWork()
            {
                int expectedDestructionLevel = weapon.DestructionLevel + 1;

                weapon.IncreaseDestructionLevel();

                Assert.AreEqual(expectedDestructionLevel, weapon.DestructionLevel);
            }

            [TestCase(0)]
            [TestCase(10)]
            [TestCase(11)]
            public void Test_IsNuclearShouldWork(int level)
            {
                bool expectedIsNuclear = false;

                Assert.AreEqual(expectedIsNuclear, weapon.IsNuclear);

                expectedIsNuclear = true;
                weapon.IncreaseDestructionLevel();
                weapon.IncreaseDestructionLevel();
                Assert.AreEqual(expectedIsNuclear, weapon.IsNuclear);

                weapon.IncreaseDestructionLevel();
                Assert.AreEqual(expectedIsNuclear, weapon.IsNuclear);
            }

            [Test]
            public void Test_PlanetNameShouldSetProperly()
            {
                planet = new Planet("name", 10);
                string expectedName = "name";

                Assert.AreEqual(expectedName, planet.Name);
            }

            [TestCase("")]
            [TestCase(null)]
            public void Test_PlanetNameShouldThrowExc_WhenISInvalid(string name)
            {
                Assert.Throws<ArgumentException>(() =>
                {
                    planet = new Planet(name, 10);
                });
            }

            [Test]
            public void Test_BudgetShouldSetProperly()
            {
                double expectedBudget = 15;
                planet = new Planet("SOMETHING", 15);
                double actualBudget = planet.Budget;

                Assert.AreEqual(expectedBudget, actualBudget);
            }


            [TestCase(-1)]
            [TestCase(-2)]
            public void Test_BudgetShouldThrowExceptWhenIsNegative(double budget)
            {
                Assert.Throws<ArgumentException>(() =>
                {
                    planet = new Planet("any", budget);
                });
            }

            [Test]
            public void Test_ProfitShouldWork()
            {
                planet = new Planet("some", 15);
                planet.Profit(15);
                double expectedBudget = 30;
                Assert.AreEqual(expectedBudget, planet.Budget);
            }

            [Test]
            public void SpendFundShouldWork()
            {
                planet = new Planet("some", 15);
                double expectedBudget = 10;
                planet.SpendFunds(5);

                Assert.AreEqual(expectedBudget, planet.Budget);
            }

            [TestCase(40)]
            [TestCase(30)]
            [TestCase(20)]
            [TestCase(16)]
            public void SpendFundShouldThrowExcept_WhenAmmountIsBiggerThanBudget(double ammount)
            {
                planet = new Planet("some", 15);

                Assert.Throws<InvalidOperationException>(() =>
                {
                    planet.SpendFunds(ammount);
                });
            }

            [Test]
            public void Test_AddWeaponShouldWorkProperly()
            {
                planet = new Planet("some", 15);
                planet.AddWeapon(weapon);

                Assert.AreEqual(1, planet.Weapons.Count);
            }

            [Test]
            public void Test_AddWeaponShouldThrowExcept_WhenWeaponExist()
            {
                planet = new Planet("some", 15);

                Assert.Throws<InvalidOperationException>(() =>
                {
                    planet.AddWeapon(weapon);
                    planet.AddWeapon(weapon);
                });
            }

            [Test]
            public void RemoveWeapon_ShouldWork()
            {
                planet = new Planet("some", 15);

                planet.AddWeapon(weapon);
                planet.AddWeapon(new Weapon("weapon", 20, 5));

                planet.RemoveWeapon(weapon.Name);

                Assert.AreEqual(1, planet.Weapons.Count);
            }

            [Test]
            public void Test_UpgradeWeapon_ShouldWork()
            {
                planet = new Planet("some", 15);

                planet.AddWeapon(weapon);

                planet.UpgradeWeapon(weapon.Name);
                int expectedWeaponDestructLevel = 9;

                Assert.AreEqual(expectedWeaponDestructLevel, planet.Weapons.First(x => x.Name == weapon.Name).DestructionLevel);
            }

            [Test]
            public void Test_UpgradeWeapon_ShouldThrowExcept_WhenWeaponDoesntExist()
            {
                planet = new Planet("some", 15);

                Assert.Throws<InvalidOperationException>(() =>
                {
                    planet.UpgradeWeapon("Not EXIST");
                });
            }

            [Test]
            public void Test_DestructOpponent_ShouldWork()
            {
                planet = new Planet("some", 140);
                planet.AddWeapon(weapon);
                Planet opponent = new Planet("oponent", 20);
                opponent.AddWeapon(new Weapon("weapon", 13, 4));
                string actual = planet.DestructOpponent(opponent);

                string expected = $"{opponent.Name} is destructed!";

                Assert.AreEqual(expected, actual);
            }


            [Test]
            public void Test_DestructOpponent_ShouldThrowExcept_WhenOpponentIsMorePowerful()
            {
                planet = new Planet("some", 20);
                planet.AddWeapon(weapon);
                Planet opponent = new Planet("oponent", 20);

                Assert.Throws<InvalidOperationException>(() =>
                {
                    string actual = planet.DestructOpponent(opponent);
                    opponent.AddWeapon(new Weapon("weapon", 13, 8));
                    planet.DestructOpponent(opponent);
                });

                Assert.Throws<InvalidOperationException>(() =>
                {
                    string actual = planet.DestructOpponent(opponent);
                    opponent.AddWeapon(new Weapon("weapon", 13, 10));
                    planet.DestructOpponent(opponent);
                });

                Assert.Throws<InvalidOperationException>(() =>
                {
                    string actual = planet.DestructOpponent(opponent);
                    opponent.AddWeapon(new Weapon("weapon", 13, 9));
                    planet.DestructOpponent(opponent);
                });
            }

        }

    }
}

