using System;
using System.Collections.Generic;
using System.Text;

namespace IsnLibrary
{
    class CheckDigitRoutines
    {
        public static char generateCheck(String isn) 
            {
            if (!(isn.Length == ISBN13_LENGTH
                || isn.Length == ISBN10_LENGTH
                || isn.Length == ISBN13_LENGTH - 1
                || isn.Length == ISBN10_LENGTH - 1
                || isn.Length == ISSN_LENGTH
                || isn.Length == ISSN_LENGTH - 1)) throw new IllegalArgumentException();

                double checkSum = 0;
            if (isn.Length == ISBN13_LENGTH || isn.Length == ISBN13_LENGTH - 1) {
                for (int i = 1; i< 12; i = i + 2) {
                checkSum += Char.GetNumericValue(isn[i]);
                }
            checkSum *= 3;
                for (int i = 0; i< 12; i = i + 2) {
                checkSum += Char.GetNumericValue(isn[i]);
                }
        checkSum = (10 - (checkSum % 10));
                if (checkSum > 9) {
                checkSum = 0;
                } 
                return (char) (checkSum + 48);
            } else {
                return generateCheckIsbn10Issn(isn, ((isn.Length + 1) / 2) * 2);
            }
            }

        private static char generateCheckIsbn10Issn(String isn, int length)
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
    }
}
