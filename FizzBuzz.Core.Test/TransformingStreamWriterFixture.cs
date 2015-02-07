using System;
using System.IO;
using NUnit.Framework;
using Rhino.Mocks;

namespace FizzBuzz.Core.Test
{
    [TestFixture]
    public class TransformingStreamWriterFixture
    {
        private MockRepository mocks;

        [SetUp]
        public void SetUp()
        {
            mocks = new MockRepository();
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void Constructor_CalledWithNullTextWriter_ThrowsException()
        {
            ITransformer mockTransformer = mocks.StrictMock<ITransformer>();
            mocks.ReplayAll();

            TransformingTextWriter writer = new TransformingTextWriter(null, mockTransformer);

            mocks.VerifyAll();
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void Constructor_CalledWithNullTransformer_ThrowsException()
        {
            TextWriter mockTextWriter = mocks.StrictMock<TextWriter>();
            mocks.ReplayAll();

            TransformingTextWriter writer = new TransformingTextWriter(mockTextWriter, null);

            mocks.VerifyAll();
        }

        [Test]
        public void Write_WhenCalled_CallsUnderlyingTransformAndTextWriter()
        {
            TextWriter mockTextWriter = mocks.StrictMock<TextWriter>();
            ITransformer mockTransformer = mocks.StrictMock<ITransformer>();

            int dummyNumber = 12;
            string transformedNumber = "Transformed";

            Expect.Call(mockTransformer.Transform(dummyNumber)).Return(transformedNumber);

            mockTextWriter.WriteLine(transformedNumber);

            mocks.ReplayAll();

            TransformingTextWriter writer = new TransformingTextWriter(mockTextWriter, mockTransformer);
            writer.Write(dummyNumber);

            mocks.VerifyAll();
        }
    }
}