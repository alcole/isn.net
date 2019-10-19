using System;
using System.Collections.Generic;
using System.Text;

namespace IsnLibrary
{
    public class ISBN : Identifier
    {
        public ISBN(string number) : base(number) {}

        public string ISBN10 { get { return Number.Length == 13 ? Number.Substring(3) : Number; } }
        public string ISBN13 { get { return Number.Length == 13 ? Number : $"978{Number}"; } }

        public override bool Validate()
        {
            // All ISBN 13s should start with 977 or 978
            if(Number.Length == 13 && !(Number.StartsWith("978") || Number.StartsWith("977")))
                return false;

            // check digit test
            char checkDigit = CheckDigitRoutines.generateCheck(Number);
            if(!Number.EndsWith(checkDigit))
                return false;

            return base.Validate();
        }

    }

    public class ISSN : Identifier
    {
        public ISSN(string number) : base(number) {}

        public override bool Validate()
        {

            // check digit test
            char checkDigit = CheckDigitRoutines.generateCheck(Number);
            if(!Number.EndsWith(checkDigit))
                return false;

            return base.Validate();
        }
    }

    public class Identifier
    {
        protected string Number { get; }

        public Identifier(string number)
        {
            Number = number;
        }

        public virtual bool Validate()
        {

            return true;
        }

        public override string ToString()
        {
            return Number.Trim().Replace("-", string.Empty).ToUpper();
        }
    }
}
