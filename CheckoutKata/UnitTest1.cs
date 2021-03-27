using NUnit.Framework;

namespace CheckoutKata
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestEmptyOrder()
        {
            Assert.AreEqual(0.00, Checkout.ProcessOrder(""));
        }

        [Test]
        public void TestItemsThatDontExist()
        {
            Assert.AreEqual(0.00, Checkout.ProcessOrder("EFGH"));
        }

        [Test]
        public void TestOneOfEachItem()
        {
            Assert.AreEqual(120, Checkout.ProcessOrder("ABCD"));
        }

        [Test]
        [TestCase("BBB", 40)]
        [TestCase("BBBB", 55)]
        [TestCase("BBBBB", 70)]
        [TestCase("BBBBBB", 80)]
        public void TestItemBDiscount(string order, double expected)
        {
            Assert.AreEqual(expected, Checkout.ProcessOrder(order));
        }

        [Test]
        [TestCase("DD", 82.50)]
        [TestCase("DDD", 137.50)]
        [TestCase("DDDD", 165)]
        [TestCase("DDDDD", 220)]
        public void TestItemDDiscount(string order, double expected)
        {
            Assert.AreEqual(expected, Checkout.ProcessOrder(order));
        }

        [Test]
        [TestCase("AABBCCDD", 212.50)]
        [TestCase("BBBCDDDDD", 300.00)]
        [TestCase("AABBBBBBDDD", 237.50)]
        [TestCase("ABCDABCDABCD", 327.50)]
        public void TestMixedOrders(string order, double expected)
        {
            Assert.AreEqual(expected, Checkout.ProcessOrder(order));
        }
    }
}