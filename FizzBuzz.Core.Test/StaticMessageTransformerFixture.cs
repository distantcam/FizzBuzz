using System;
using NUnit.Framework;

namespace FizzBuzz.Core.Test
{
    [TestFixture]
    public class StaticMessageTransformerFixture
    {
        private const string Message = "message";
        private StaticMessageTransformer transformer;

        [SetUp]
        public void SetUp()
        {
            transformer = new StaticMessageTransformer(Message);
        }

        [Test]
        public void ConstructorSetsMessageProperty()
        {
            Assert.AreEqual(Message, transformer.Message);
        }

        [TestCase(1)]
        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(Int32.MaxValue)]
        [TestCase(Int32.MinValue)]
        [TestCase(default(Int32))]
        [Test]
        public void TestTransform(int number)
        {
            Assert.AreEqual(Message, transformer.Transform(number));
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void TestConstructorWithBadMessage()
        {
            transformer = new StaticMessageTransformer(null);
        }
    }
}