using System;

namespace IsnLibrary
{
    public static class IsnFunctions
    {
        public static bool isValid(String isn, String type)
        {
            return true;
        }

        public static String getCanonical(String isn, String type)
        {
            //strip dashes
            //lower x to upper X
            //ISBN 10 to ISBN 13
            //EAN-ISSN to ISSN
            return "111";
        }

        public static String getType(String isn)
        {
            return "ISBN";
        }

        //couldhave types as an enum class?
    }
}
