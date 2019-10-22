using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace IsnLibrary
{
    public static class Constants {
        public static string SEP = "(?:\\-|\\s)";
        public static string GROUP = "(\\d{1,5})";
        public static string PUBLISHER = "(\\d{1,7})";
        public static string TITLE = "(\\d{1,6})";
    }
    public class ISBN : Identifier
    {
        public ISBN(string number) : base(number) {}

        public string ISBN10 { get { return Number.Length == 13 ? Number.Substring(3) : Number; } }
        public string ISBN13 { get { return Number.Length == 13 ? Number : $"978{Number}"; } }

        protected override string RegexPattern { get { return "^(978|979)(?:(\\d{10})|(?:" + Constants.SEP + Constants.GROUP + Constants.SEP + Constants.PUBLISHER + Constants.SEP + Constants.TITLE + Constants.SEP + "([0-9])))$"; } }

        public override bool Validate()
        {
            // All ISBN 13s should start with 978 or 979
            if(Number.Length == 13 && !(Number.StartsWith("978") || Number.StartsWith("979")))
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

        protected virtual string RegexPattern { get { return ".*"; } }

        public Identifier(string number)
        {
            Number = number;
        }

        public virtual bool Validate()
        {
            bool regexPass = Regex.IsMatch(Number, RegexPattern);
            return regexPass;
        }

        public override string ToString()
        {
            return Number.Trim().Replace("-", string.Empty).ToUpper();
        }
    }
}
