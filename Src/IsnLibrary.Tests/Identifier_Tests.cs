using NUnit.Framework;
using System;

namespace IsnLibrary.Tests
{
    public class Identifier_Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void IsbnTest()
        {
            Identifier ISBN = new Identifier("9780262510875");
            Assert.That(ISBN.isValid, Is.True);
            Assert.That(ISBN.identifierType, Is.EqualTo(IdentifierType.ISBN));
        }
        
        [Test]
        public void Isbn10Test()
        {
            Identifier isbn10 = new Identifier("0262510871");
            Assert.That(isbn10.isValid, Is.True);
            Assert.That(isbn10.originalId, Is.EqualTo("0262510871"));
            Assert.That(isbn10.isn, Is.EqualTo("9780262510875"));
            Assert.That(isbn10.identifierType, Is.EqualTo(IdentifierType.ISBN));
        }

        [Test]
        public void EanIssnTest()
        {
            Identifier EanIssn = new Identifier("9772049363002");
            Assert.That(EanIssn.isValid, Is.True);
            Assert.That(EanIssn.identifierType, Is.EqualTo(IdentifierType.ISSN));
            Assert.That(EanIssn.originalId, Is.EqualTo("9772049363002"));
            Assert.That(EanIssn.isn, Is.EqualTo("20493630"));
            Assert.That(EanIssn.identifierType, Is.EqualTo(IdentifierType.ISSN));
        }

        [Test]
        public void EanIssnTestwithX()
        {
            Identifier EanIssn = new Identifier("9772434561006");
            Assert.That(EanIssn.isValid, Is.True);
            Assert.That(EanIssn.identifierType, Is.EqualTo(IdentifierType.ISSN));
            Assert.That(EanIssn.originalId, Is.EqualTo("9772434561006"));
            Assert.That(EanIssn.isn, Is.EqualTo("2434561X"));
            Assert.That(EanIssn.identifierType, Is.EqualTo(IdentifierType.ISSN));
        }

        [Test]
        public void IsmnTest()
        {
            Identifier Ismn = new Identifier("979-0-9016791-7-7");
            Assert.That(Ismn.isValid, Is.True);
            Assert.That(Ismn.identifierType, Is.EqualTo(IdentifierType.ISMN));
            Assert.That(Ismn.isn, Is.EqualTo("979-0-9016791-7-7".Replace("-", "")));
        }


        [Test]
        public void IssnTest()
        {
            Identifier issn = new Identifier("00014664");
            Assert.That(issn.isValid, Is.True);
            Assert.That(issn.identifierType, Is.EqualTo(IdentifierType.ISSN));
        }

        [Test]
        public void IsniTest()
        {
            Isni isni = new Isni("0000 0004 5352 4211");
            Assert.That(isni.isValid, Is.True);
            Assert.That(isni.identifierType, Is.EqualTo(IdentifierType.ISNI));
            Assert.That(isni.isORCID, Is.False);
        }

        [Test]
        public void OrcidTest()
        {
            Isni isni = new Isni("0000-0002-1825-0097");
            Assert.That(isni.isValid, Is.True);
            Assert.That(isni.identifierType, Is.EqualTo(IdentifierType.ISNI));
            Assert.That(isni.isORCID, Is.True);
        }

        [Test]
        public void OrcidWithXTest()
        {
            Isni isni = new Isni("0000-0002-9079-593X");
            Assert.That(isni.isValid, Is.True);
            Assert.That(isni.identifierType, Is.EqualTo(IdentifierType.ISNI));
            Assert.That(isni.isORCID, Is.True);
        }



        [Test]
        public void NewIdentifier_BadCheckDigit_FailsValidation()
        {
            Identifier identifier = new Identifier("9780316769531");
            Assert.That(identifier.isValid, Is.False);
            Assert.That(identifier.identifierType, Is.EqualTo(IdentifierType.Invalid));
        }
    }
}