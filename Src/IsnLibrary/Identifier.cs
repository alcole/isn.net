using System;
using System.Collections.Generic;
using System.Text;

namespace IsnLibrary
{
    public class ISBN : Identifier
    {
        public ISBN(string number) : base(number, IdentifierType.ISBN) {}
    }

    public class Identifier
    {
        private string Number { get; }
        private IdentifierType Type { get; }

        public Identifier(string number, IdentifierType identifierType)
        {
            if (!Validate(number, identifierType))
            {
                throw new ArgumentException("Not a valid ISN");
            }
            Number = number;
            Type = Type;
        }

        private bool Validate(String number, IdentifierType type)
        {
            // Allow "other" ISNs skip validation
            if(type == IdentifierType.Other)
                return true;

            // check digit test
            char checkDigit = CheckDigitRoutines.generateCheck(number);
            if(!number.EndsWith(checkDigit))
                return false;

            // All ISBN 13s should start with 977 or 978
            if(type == IdentifierType.ISBN && !(number.StartsWith("978") || number.StartsWith("977")))
                return false;

            return true;
        }

        public override string ToString()
        {
            return Number.Trim().Replace("-", string.Empty).ToUpper();
        }
    }
}
