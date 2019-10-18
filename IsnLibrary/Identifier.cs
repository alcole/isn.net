using System;
using System.Collections.Generic;
using System.Text;
using static IsnLibrary.IdentifierType;

namespace IsnLibrary
{
    class Identifier
    {
        private String Number { get; }
        private IdType Type { get; }
        private bool IsValid { get; }
        private Identifier OriginalForm { get; }


        public Identifier(String number)
        {
            String tempNumber = number.Trim().Replace("-", string.Empty).ToUpper();      
            IdType TempType = GetType(tempNumber);
            IsValid = Validate(tempNumber, TempType);
            if (IsValid)
            {
                if (TempType == IdType.EANISSN || TempType == IdType.ISBN10)
                {
                    OriginalForm = new Identifier(tempNumber, TempType, true);
                    Number = Convert(tempNumber);
                    Type = GetType(Number);
                }
                else
                {
                    Number = tempNumber;
                    Type = TempType;
                }
            }
        }

        public Identifier(String number, IdType type)
        {
            String tempNumber = number.Trim().Replace("-", string.Empty).ToUpper();
            IdType TempType = GetType(tempNumber);
            IsValid = Validate(tempNumber, TempType);  
            // validate type is correct for the supplied isn
            if (IsValid)
            {
                if (TempType == IdType.EANISSN || TempType == IdType.ISBN10)
                {
                    OriginalForm = new Identifier(tempNumber, TempType, true);
                    Number = Convert(tempNumber);
                    Type = GetType(Number);
                }
                else
                {
                    Number = tempNumber;
                    Type = TempType;
                }
            }
        }

        private Identifier(String number, IdType type, bool addOriginal)
        {
            Number = number.Trim().Replace("-", string.Empty).ToUpper();
            Type = type;
            IsValid = Validate(number, type);
        }

        private IdType GetType(String Number)
        {
            if (Number.Length < 8) return IdType.Other;
            return IdType.ISBN;
        }

        private String Convert(String Number)
        {
            return "9780000000009";
        }

        private bool Validate(String number, IdType type)
        {
            //check regex against valid for type
            return CheckDigitRoutines.generateCheck(number) == number[number.Length-1];
        }


        /*        public Identifier(String number, String type)
                {
                    Number = number;
                    if (Enum.TryParse(type, out IdentifierType Type) {

                    }
                    // if type non canon then change?
                    // if type doesn't match reject?
                }
        */


    }
}
