using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace IsnLibrary
{
    public enum IdentifierType { ISBN, ISBN10, ISMN, ISSN, EANISSN, EAN, ISNI, ISPI, Other, Invalid}

    public class IsnRegexs
    {
        public static Regex EanIssnRx = new Regex(@"[9]{1}[7]{1}[7]{1}[\d|\-]{9,13}[\d]{1}",
            RegexOptions.Compiled | RegexOptions.IgnoreCase);
        public static Regex IsmnRx = new Regex(@"[9]{1}[7]{1}[9]{1}[0]{1}[\d|\-]{8,12}[\d]{1}",
            RegexOptions.Compiled | RegexOptions.IgnoreCase);
        public static Regex IsbnRx = new Regex(@"[9]{1}[7]{1}[8|9]{1}[\d|\-]{9,13}[\d]{1}",
            RegexOptions.Compiled | RegexOptions.IgnoreCase);
        public static Regex Isbn10Rx = new Regex(@"[\d|\-]{9,13}[0-9xX]{1}",
            RegexOptions.Compiled | RegexOptions.IgnoreCase);
        public static Regex IssnRx = new Regex(@"\d{4}[-]?\d{3}[0-9xX]{1}",
            RegexOptions.Compiled | RegexOptions.IgnoreCase);
        public static Regex IsniRx = new Regex(@"\d{4}[-]?\d{4}[-]?\d{4}[-]?\d{3}[0-9xX]{1}",
            RegexOptions.Compiled | RegexOptions.IgnoreCase);
    }


}
