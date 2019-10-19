using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace IsnLibrary
{
    public class IdentifierFactory
    {
        public static Identifier? Create(string number) {
            try {
                switch (number.Length)
                {
                    case 8:
                    case 9:
                        return new Identifier(number, IdentifierType.ISSN);
                    case 10:
                        return new Identifier(number, IdentifierType.ISBN10);
                    case 13:
                        // return new Identifier(number, IdentifierType.ISBN); 
                        return new ISBN(number);
                    default:
                        return new Identifier(number, IdentifierType.Other);
                }
            } catch(ArgumentException exception) {
                Debug.WriteLine($"Validation failed: {exception.ToString()}");
            }
            return null;
        }
    }
}
