namespace IsnLibrary
{
    public class Identifier
    {     
        public string isn { get; set; }
        public bool isValid { get; set; }
        public IdentifierType identifierType { get; set; }
        public string originalId { get; }

        public Identifier(string number)
        {
            originalId = number;
            cleanIsn();
            isValid = Validate();
            identifierType = isValid ? setType() : IdentifierType.Invalid;
            checkTypes();
        }

        public Identifier(string number, IdentifierType idtype) : this(number)
        {
            if (idtype != this.identifierType)
            {
                isValid = false;
                this.identifierType = idtype;
            }
        }

        private void checkTypes()
        {
            if (isValid && identifierType == IdentifierType.ISBN10)
            {
                isn = $"{"978"}{isn.Substring(0, 9)}{CheckDigitRoutines.generateCheck13digit($"{"978"}{isn}")}";
                identifierType = IdentifierType.ISBN;
            }
            if (isValid && identifierType == IdentifierType.EANISSN)
            {
                isn = $"{isn.Substring(3, 7)}{CheckDigitRoutines.generateCheckIsbn10Issn(isn.Substring(3, 7), 8)}";
                identifierType = IdentifierType.ISSN;
            }
        }

        private void cleanIsn()
        {
            isn = originalId.Trim().ToUpper().Replace(" ", "").Replace("-","");
        }

        public virtual bool Validate()
        {
            char checkDigit = '0';
            if (isn.Length == 13)
            {
                checkDigit = CheckDigitRoutines.generateCheck13digit(isn);                
            }
            else if (isn.Length == 10)
            {
                checkDigit = CheckDigitRoutines.generateCheckIsbn10Issn(isn, 10);
            }
            else if (isn.Length == 8)
            {
                checkDigit = CheckDigitRoutines.generateCheckIsbn10Issn(isn, 8);
            }
            else if (isn.Length == 16)
            {
                checkDigit = CheckDigitRoutines.generateCheckIsni(isn);
            }
            else
            {
                return false;
            }
            return isn.EndsWith(checkDigit);
        }

        private IdentifierType setType()
        {
            IdentifierType type = IdentifierType.Other;
            if (isn.Length == 13 )
            {
                type = IdentifierType.EAN;
            }
            switch (isn)
            {
                case var result when IsnRegexs.IsmnRx.IsMatch(isn):
                    type = IdentifierType.ISMN;
                    break;
                case var result when IsnRegexs.IsbnRx.IsMatch(isn):
                    type = IdentifierType.ISBN;
                    break;
                case var result when IsnRegexs.EanIssnRx.IsMatch(isn):
                    type = IdentifierType.EANISSN;
                    break;
                case var result when IsnRegexs.Isbn10Rx.IsMatch(isn):
                    type = IdentifierType.ISBN10;
                    break;
                case var result when IsnRegexs.IssnRx.IsMatch(isn):
                    type = IdentifierType.ISSN;
                    break;
                case var result when IsnRegexs.IsniRx.IsMatch(isn):
                    type = IdentifierType.ISNI;
                    break;
            }          
            return type;
        }
    }

    public class Isni : Identifier
    {
        public bool isORCID;
        public Isni(string number) : base(number, IdentifierType.ISNI)
        {
            isORCID = IsnRegexs.OrcidRx.IsMatch(isn);
        }
    }
}
