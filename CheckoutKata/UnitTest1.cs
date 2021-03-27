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
        public void Test1()
        {
            Assert.AreEqual("Test", Checkout.Test("Test"));
        }
    }
}