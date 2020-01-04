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
            Identifier ISBN = new Identifier("9780262510875");
            Assert.That(ISBN.isValid, Is.True);
            Assert.That(ISBN.identifierType, Is.EqualTo(IdentifierType.ISBN));
        }
        
        [Test]
        public void Isbn10test()
        {
            Identifier isbn10 = new Identifier("0262510871");
            Assert.That(isbn10.isValid, Is.True);
            Assert.That(isbn10.identifierType, Is.EqualTo(IdentifierType.ISBN10));
            //convert the 10 to 13
            /*            ISBN id2 = new ISBN(identifier.ToString());
                        Assert.That(id2.ToString().Length, Is.EqualTo(13));
                        Assert.That(id2.Validate(), Is.True);
                        Assert.That(id2.ToString(), Is.EqualTo("9780262510875"));*/
        }

        [Test]
        public void Ismntest()
        {
            Identifier Ismn = new Identifier("979-0-9016791-7-7");
            Assert.That(Ismn.isValid, Is.True);
            Assert.That(Ismn.identifierType, Is.EqualTo(IdentifierType.ISMN));
            Assert.That(Ismn.isn, Is.EqualTo("979-0-9016791-7-7".Replace("-", "")));
        }


        [Test]
        public void Issntest()
        {
            Identifier issn = new Identifier("00014664");
            Assert.That(issn.isValid, Is.True);
            Assert.That(issn.identifierType, Is.EqualTo(IdentifierType.ISSN));
        }



       // [Test]
        /*        public void NewIdentifier_BadStart_FailsValidation()
                {
                    Identifier identifier = new ISBN("1782312312314");
                    Assert.That(identifier.Validate(), Is.False);
                }

                [Test]
                public void NewIdentifier_BadCheckDigit_FailsValidation()
                {
                   Identifier identifier = new ISBN("9780316769531");
                    Assert.That(identifier.Validate(), Is.False);
                }*/
    }
}