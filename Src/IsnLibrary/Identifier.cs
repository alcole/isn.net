namespace IsnLibrary
{
    public class Identifier
    {     
        public string isn { get; set; }
        public bool isValid { get; set; }
        public IdentifierType identifierType { get; set; }
        protected string originalId { get; }

        public Identifier(string number)
        {
            originalId = number;
            cleanIsn();
            isValid = Validate();
            identifierType = isValid ? setType() : IdentifierType.Invalid;
        }

       // public Identifier(string number, string type)
        //error if type doesn't match

        private void cleanIsn()
        {
            isn = originalId.Trim().ToUpper().Replace(" ", "").Replace("-","");
        }

        public virtual bool Validate()
        {
            char checkDigit = '0';
            if (isn.Length == 13)
            {
                checkDigit = CheckDigitRoutines.generateCheck(isn);
                
            }
            else if (isn.Length == 10)
            {
                checkDigit = CheckDigitRoutines.generateCheckIsbn10Issn(isn, 10);
            }
            else if (isn.Length == 8)
            {
                checkDigit = CheckDigitRoutines.generateCheckIsbn10Issn(isn, 8);
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
                //todo ISMN, ean977, 
                case var result when IsnRegexs.IsmnRx.IsMatch(isn):
                    type = IdentifierType.ISMN;
                    break;
                case var result when IsnRegexs.IsbnRx.IsMatch(isn):
                    type = IdentifierType.ISBN;
                    break;
                case var result when IsnRegexs.Isbn10Rx.IsMatch(isn):
                    type = IdentifierType.ISBN10;
                    break;
                case var result when IsnRegexs.IssnRx.IsMatch(isn):
                    type = IdentifierType.ISSN;
                    break;
            }          
            return type;
        }
    }
}
