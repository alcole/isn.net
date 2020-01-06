using System;
using System.Collections.Generic;
using System.Text;

namespace IsnLibrary
{
    class CheckDigitRoutines
    {
        private static int ISBN13_LENGTH = 13;

        public static char generateCheck13digit(String isn)
        {
            //if length not 12 or 13 reject
            double checkSum = 0;
            if (isn.Length == ISBN13_LENGTH || isn.Length == ISBN13_LENGTH - 1)
            {
                for (int i = 1; i < 12; i = i + 2)
                {
                    checkSum += Char.GetNumericValue(isn[i]);
                }
                checkSum *= 3;
                for (int i = 0; i < 12; i = i + 2)
                {
                    checkSum += Char.GetNumericValue(isn[i]);
                }
                checkSum = (10 - (checkSum % 10));
                if (checkSum > 9)
                {
                    checkSum = 0;
                }
            }
            return(char)(checkSum + 48);
        }

        public static char generateCheckIsbn10Issn(String isn, int length)
        {
            double checkSum = 0;
            for (int i = 0; i < length - 1; i++)
            {
                checkSum += Char.GetNumericValue(isn, i) * (length - i);
            }
            checkSum = (11 - checkSum % 11) % 11;
            if (checkSum == 10)
            {
                return 'X';
            }
            else
            {
                return (char)(checkSum + 48);
            }
        }

        /**
         * Generates check digit as per ISO 7064 11,2.
         * ISNI and ORCID
         */
        public static char generateCheckIsni(String isn)
        {
            double total = 0;
            for (var i = 0; i < 15; i++)
            {
                var digit = Char.GetNumericValue(isn, i);
                total = (total + digit) * 2;
            }
            var remainder = total % 11;
            double result = (12 - remainder) % 11;
            return result == 10 ? 'X' : (char)(result + 48);
        }
    }
}
