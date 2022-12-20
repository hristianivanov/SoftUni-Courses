using NUnit.Framework;
using System;

namespace Gyms.Tests
{
    [TestFixture]
    public class GymsTests
    {
        private Athlete athlete;
        private const string DEF_ATHLETENAME = "Griezman";
        private Gym gym;
        private const string DEF_GYMNAME = "Pulse Fitness";
        private const int DEF_CAPACITY = 20;
        [SetUp]
        public void SetUp()
        {
            athlete = new Athlete(DEF_ATHLETENAME);
            gym = new Gym(DEF_GYMNAME, DEF_CAPACITY);
        }

        [Test]
        public void Test_AthleteConstructor()
        {
            Assert.AreEqual(DEF_ATHLETENAME, athlete.FullName);
            Assert.AreEqual(false, athlete.IsInjured);
        }

        [Test]
        public void Test_GymConstructor()
        {
            Assert.AreEqual(DEF_GYMNAME, gym.Name);
            Assert.AreEqual(DEF_CAPACITY, gym.Capacity);
            Assert.AreEqual(0, gym.Count);
        }
        [TestCase(null)]
        [TestCase("")]
        public void Test_GymNameIsNullOrEmpty(string name)
        {
            Assert.Throws<ArgumentNullException>(() => gym = new Gym(name, DEF_CAPACITY));
        }

        [TestCase(-15)]
        [TestCase(-1)]
        public void Test_GymCapacityBelowZero(int capacity)
        {
            Assert.Throws<ArgumentException>(() => gym = new Gym(DEF_GYMNAME, capacity));
        }

        [TestCase(1)]
        [TestCase(2)]
        [TestCase(5)]
        public void Test_GymAddAthleteShouldAddAthlete(int times)
        {
            for (int i = 0; i < times; i++)
                gym.AddAthlete(athlete);

            Assert.AreEqual(times, gym.Count);
        }

        [Test]
        public void Test_GymAddAthleteWhenGymCapacityIsEqualToAthletesInGym()
        {
            for (int i = 0; i < DEF_CAPACITY; i++)
                gym.AddAthlete(athlete);

            Assert.Throws<InvalidOperationException>(() => gym.AddAthlete(athlete));
        }

        [Test]
        public void Test_GymRemoveAthleteShouldRemoveAthlete()
        {
            gym.AddAthlete(athlete);
            gym.AddAthlete(athlete);
            gym.AddAthlete(athlete);

            gym.RemoveAthlete(athlete.FullName);

            Assert.AreEqual(2, gym.Count);
        }

        [Test]
        public void Test_GymRemoveAthleteWhenAthleteDoesNotExist()
        {
            Assert.Throws<InvalidOperationException>(() => gym.RemoveAthlete("invalid"));
        }

        [Test]
        public void Test_GymInjureAthleteShouldWork()
        {
            gym.AddAthlete(athlete);
            var expected = athlete;
            var actual = gym.InjureAthlete(athlete.FullName);

            Assert.AreEqual(true,actual.IsInjured);
            Assert.AreEqual(expected, actual);
        }


        [Test]
        public void Test_GymInjureAthleteWhenAthleteDoesNotExist()
        {
            Assert.Throws<InvalidOperationException>(() => gym.InjureAthlete("invalid"));
        }

        [Test]
        public void Test_GymReport()
        {
            gym.AddAthlete(athlete);
            gym.InjureAthlete(athlete.FullName);
            gym.AddAthlete(new Athlete("Mbappe"));
            gym.AddAthlete(new Athlete("Messi"));
            var expectedAthletesNames = $"Mbappe, Messi";
            var expected = $"Active athletes at {DEF_GYMNAME}: {expectedAthletesNames}";

            var actual = gym.Report();

            Assert.AreEqual(expected, actual);
        }
    }
}
