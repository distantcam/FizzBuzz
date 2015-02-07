using System;
using NUnit.Framework;

namespace FizzBuzz.Core.Test
{
    [TestFixture]
    public class IdentityTransformerFixture
    {
        private IdentityTransformer transformer;

        [SetUp]
        public void Setup()
        {
            transformer = new IdentityTransformer();
        }

        [Test]
        public void TestTransform()
        {
            int dummyAsInt = 1;
            string dummAsString = dummyAsInt.ToString();
            Assert.AreEqual(dummAsString, transformer.Transform(dummyAsInt));
        }
    }
}