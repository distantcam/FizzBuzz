using System;

using MbUnit.Framework;

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

        [Row(1)]
        [Row(0)]
        [Row(-1)]
        [Row(Int32.MinValue)]
        [Row(Int32.MaxValue)]
        [Row(default(Int32))]
        [Test]
        public void TestTransform(int num)
        {
            Assert.IsEmpty(transformer.Transform(num));
        }
    }
}