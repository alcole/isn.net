using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace IsnLibrary
{
    class IdentifierType
    {
        public enum IdType { ISBN, ISBN10, ISMN, ISSN, EANISSN, EAN, ISNI, ISPI, Other}

        private static String SEP = "(?:\\-|\\s)";
        private static String GROUP = "(\\d{1,5})";
        private static String PUBLISHER = "(\\d{1,7})";
        private static String TITLE = "(\\d{1,6})";

        static Regex ISBN13_REGEX= new Regex("^(978|979)(?:(\\d{10})|(?:" + SEP + GROUP + SEP + PUBLISHER + SEP + TITLE + SEP + "([0-9])))$", RegexOptions.Compiled | RegexOptions.IgnoreCase);
        static Regex ISBN10_REGEX     = new Regex("^(?:(\\d{9}[0-9X])|(?:" + GROUP + SEP + PUBLISHER + SEP + TITLE + SEP + "([0-9X])))$", RegexOptions.Compiled | RegexOptions.IgnoreCase);
        static Regex ISSN_REGEX = new Regex("(?:ISSN )?(\\d{4})-(\\d{3}[0-9X])$", RegexOptions.Compiled);
        //also ISMN
        //static Regex EAN13Regex = new Regex(); or is this just length 13 of digits?
        //also ISNI
    }
}
