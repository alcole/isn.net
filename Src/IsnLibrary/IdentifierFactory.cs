using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace IsnLibrary
{
    public class IdentifierFactory
    {
        public static Identifier? Create(string number) {
            Identifier identifier;
            number = number.Replace("-", string.Empty).ToUpper();
            switch (number.Length)
            {
                case 8:
                case 9:
                    identifier = new ISSN(number);
                    break;
                case 10:
                case 13:
                    identifier =  new ISBN(number);
                    break;
                default:
                    identifier =  new Identifier(number);
                    break;
            }
            if(identifier.Validate()) {
                return identifier;
            }
            return null;
        }
    }
}
