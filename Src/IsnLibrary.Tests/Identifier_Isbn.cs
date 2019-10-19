using NUnit.Framework;
using System;

namespace IsnLibrary.Tests
{
    public class Identifier_Isbn
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void NewIdentifier_CorrectIsbn_PassValidation()
        {
            ISBN identifier = new ISBN("9780316769532");
            Assert.That(identifier.Validate(), Is.True);
            Assert.That(identifier.ISBN10.Length, Is.EqualTo(10));
            Assert.That(identifier.ISBN10, Is.EqualTo("0316769532"));
            Assert.That(identifier.ISBN13.Length, Is.EqualTo(13));
            Assert.That(identifier.ISBN13, Is.EqualTo("9780316769532"));
        }

        [Test]
        public void NewIdentifier_BadStart_FailsValidation()
        {
            Identifier identifier = new ISBN("1782312312314");
            Assert.That(identifier.Validate(), Is.False);
        }

        [Test]
        public void NewIdentifier_BadCheckDigit_FailsValidation()
        {
           Identifier identifier = new ISBN("9780316769531");
            Assert.That(identifier.Validate(), Is.False);
        }
    }
}