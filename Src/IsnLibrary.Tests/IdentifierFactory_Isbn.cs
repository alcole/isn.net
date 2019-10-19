using NUnit.Framework;
using System;
using System.Diagnostics;


namespace IsnLibrary.Tests
{
    public class IdentifierFactory_Isbn
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void NewIdentifier_CorrectIsbn_PassValidation()
        {
            Identifier identifier = IdentifierFactory.Create("9780316769532");
            Assert.That(identifier, Is.Not.Null);
        }

        [Test]
        public void NewIdentifier_BadStart_FailsValidation()
        {
            Identifier? identifier = IdentifierFactory.Create("1782312312314");
            Assert.That(identifier, Is.Null);
        }

        [Test]
        public void NewIdentifier_BadCheckDigit_FailsValidation()
        {
            Identifier? identifier = IdentifierFactory.Create("9780316769531");
            Assert.That(identifier, Is.Null);
        }
    }
}