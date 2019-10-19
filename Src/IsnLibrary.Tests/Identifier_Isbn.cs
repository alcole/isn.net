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
            Identifier identifier = new Identifier("9780316769532", IdentifierType.ISBN);
            Assert.That(identifier, Is.Not.Null);
        }

        [Test]
        public void NewIdentifier_BadStart_FailsValidation()
        {
            var ex = Assert.Throws<ArgumentException>(() => new Identifier("1782312312314", IdentifierType.ISBN));
            Assert.That(ex.Message, Is.EqualTo("Not a valid ISN"));
        }

        [Test]
        public void NewIdentifier_BadCheckDigit_FailsValidation()
        {
            var ex = Assert.Throws<ArgumentException>(() => new Identifier("9780316769531", IdentifierType.ISBN));
            Assert.That(ex.Message, Is.EqualTo("Not a valid ISN"));
        }
    }
}