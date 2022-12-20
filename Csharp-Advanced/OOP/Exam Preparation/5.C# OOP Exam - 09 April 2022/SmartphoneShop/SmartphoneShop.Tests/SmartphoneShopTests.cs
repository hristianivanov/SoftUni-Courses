using NUnit.Framework;
using System;

namespace SmartphoneShop.Tests
{
    [TestFixture]
    public class SmartphoneShopTests
    {
        private Smartphone smartphone;
        private string model = "huawei p40";
        int battery = 100;
        private Shop shop;

        [SetUp]
        public void SetUp()
        {
            smartphone = new Smartphone(model, battery);
        }

        [Test]
        public void Test_SmartPhoneConstructorShouldSetProperly()
        {
            Assert.AreEqual("huawei p40", smartphone.ModelName);
            Assert.AreEqual(100, smartphone.MaximumBatteryCharge);
            Assert.AreEqual(100, smartphone.CurrentBateryCharge);
        }

        [Test]
        public void Test_ShopConstructorShouldSetProperly()
        {
            shop = new Shop(2);
            Assert.AreEqual(2, shop.Capacity);
            Assert.AreEqual(0, shop.Count);
        }

        [TestCase(-1)]
        [TestCase(-5)]
        [TestCase(-10)]
        public void Test_Capcity_WhenIsNegative(int capacity)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                shop = new Shop(capacity);
            });
        }

        [Test]
        public void Test_AddShouldWork()
        {
            shop = new Shop(2);
            shop.Add(smartphone);
            Assert.AreEqual(1, shop.Count);
        }

        [Test]
        public void Test_AddShouldThrowExcept_WhenPhoneExist()
        {
            shop = new Shop(2);
            shop.Add(smartphone);

            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.Add(smartphone);
            });
        }


        [Test]
        public void Test_AddShouldThrowExcept_WhenCapacityIsFull()
        {
            shop = new Shop(1);
            shop.Add(smartphone);

            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.Add(new Smartphone("model", 100));
            });
        }

        [Test]
        public void Test_RemoveShouldWork()
        {
            shop = new Shop(2);
            shop.Add(smartphone);

            shop.Remove(smartphone.ModelName);
            Assert.AreEqual(0, shop.Count);
        }

        [Test]
        public void Test_RemoveShouldThrowExcept_WhenPhoneNotExist()
        {
            shop = new Shop(2);
            shop.Add(smartphone);
            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.Remove("model");
            });
        }

        [Test]
        public void Test_TestPhoneShouldWork()
        {
            shop = new Shop(2);
            shop.Add(smartphone);

            shop.TestPhone(smartphone.ModelName, 20);

            Assert.AreEqual(80, smartphone.CurrentBateryCharge);
        }

        [Test]
        public void Test_TestPhoneShouldThrowExcept_WhenPhoneNotExist()
        {
            shop = new Shop(2);
            shop.Add(smartphone);
            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.TestPhone("model",19);
            });
        }

        [Test]
        public void Test_TestPhoneShouldThrowExcept_WhenCurBatteryUssageIsLessThanUssage()
        {
            shop = new Shop(2);
            shop.Add(smartphone);
            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.TestPhone(smartphone.ModelName, 110);
            });
        }

        [Test]
        public void Test_ChargePhoneShouldWork()
        {
            shop = new Shop(2);
            shop.Add(smartphone);

            shop.TestPhone(smartphone.ModelName, 20);
            shop.ChargePhone(smartphone.ModelName);
            Assert.AreEqual(100, smartphone.CurrentBateryCharge);
        }

        [Test]
        public void Test_ChargePhoneShouldThrowExcept_WhenPhoneNotExist()
        {
            shop = new Shop(2);
            shop.Add(smartphone);

            shop.TestPhone(smartphone.ModelName, 20);
            shop.TestPhone(smartphone.ModelName, 5);

            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.ChargePhone("phone");
            });
        }

    }
}