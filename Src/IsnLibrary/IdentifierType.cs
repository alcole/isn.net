using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Text.RegularExpressions;

namespace IsnLibrary
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum IdentifierType { ISBN, ISBN10, ISMN, ISSN, EANISSN, EAN, ISNI, ISPI, Other, Invalid}

    public class IsnRegexs
    {
        public static Regex EanIssnRx = new Regex(@"[9]{1}[7]{1}[7]{1}[\d|]{9}[\d]{1}",
            RegexOptions.Compiled | RegexOptions.IgnoreCase);
        public static Regex IsmnRx = new Regex(@"[9]{1}[7]{1}[9]{1}[0]{1}[\d]{8}[\d]{1}",
            RegexOptions.Compiled | RegexOptions.IgnoreCase);
        public static Regex IsbnRx = new Regex(@"[9]{1}[7]{1}[8|9]{1}[\d]{9}[\d]{1}",
            RegexOptions.Compiled | RegexOptions.IgnoreCase);
        public static Regex Isbn10Rx = new Regex(@"^[\d|\-]{9,13}[0-9xX]{1}$",
            RegexOptions.Compiled | RegexOptions.IgnoreCase);
        public static Regex IssnRx = new Regex(@"^\d{4}[-]?\d{3}[0-9xX]{1}$",
            RegexOptions.Compiled | RegexOptions.IgnoreCase);
        public static Regex IsniRx = new Regex(@"\d{4}[-]?\d{4}[-]?\d{4}[-]?\d{3}[0-9xX]{1}",
            RegexOptions.Compiled | RegexOptions.IgnoreCase);
        public static Regex OrcidRx = new Regex(@"^[0]{7}(1[5-9][0-9]{6}|2[0-9]{7}|3[0-4] [0-9]{6}])[0-9xX]{1}$",
            RegexOptions.Compiled | RegexOptions.IgnoreCase);  
    }
}
