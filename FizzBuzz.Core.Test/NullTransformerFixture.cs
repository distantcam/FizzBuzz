using System;
using NUnit.Framework;

namespace FizzBuzz.Core.Test
{
    [TestFixture]
    public class NullTransformerFixture
    {
        private NullTransformer transformer;

        [SetUp]
        public void SetUp()
        {
            transformer = new NullTransformer();
        }

        [TestCase(1)]
        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(Int32.MinValue)]
        [TestCase(Int32.MaxValue)]
        [TestCase(default(Int32))]
        [Test]
        public void TestTransform(int num)
        {
            Assert.IsEmpty(transformer.Transform(num));
        }
    }
}