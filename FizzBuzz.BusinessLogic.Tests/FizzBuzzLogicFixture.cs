using System;
using FizzBuzz.Core;
using NUnit.Framework;

namespace FizzBuzz.BusinessLogic.Tests
{
    [TestFixture]
    public class FizzBuzzLogicFixture
    {
        private FizzBuzzLogic logic;

        [SetUp]
        public void SetUp()
        {
            logic = new FizzBuzzLogic();
        }

        [Test]
        public void CreateRange_WhenCalled_ReturnsValidARangeObject()
        {
            Range rangeFromLogicComponent = logic.CreateRange();

            Assert.IsNotNull(rangeFromLogicComponent);
        }

        [TestCase(1, "1")]
        [TestCase(2, "2")]
        [TestCase(3, "Fizz")]
        [TestCase(4, "4")]
        [TestCase(5, "Buzz")]
        [TestCase(6, "Fizz")]
        [TestCase(7, "7")]
        [TestCase(8, "8")]
        [TestCase(9, "Fizz")]
        [TestCase(10, "Buzz")]
        [TestCase(11, "11")]
        [TestCase(12, "Fizz")]
        [TestCase(13, "13")]
        [TestCase(14, "14")]
        [TestCase(15, "FizzBuzz")]
        [Test]
        public void CreateTransformer_WhenCalled_ReturnsATransformerWhichAdheresToFizzBuzzBusinessRules(int number, string expected)
        {
            ITransformer transformer = logic.CreateTransformer();
            string resultFromTransformer = transformer.Transform(number);

            Assert.AreEqual(expected, resultFromTransformer);
        }
    }
}