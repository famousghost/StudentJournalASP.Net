using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentJournalASPNET
{
    public class Pesel
    {
        private readonly string peselTextRepresentation;

        private Pesel(string peselText)
        {
            peselTextRepresentation = peselText;
        }

        public static bool TryParse(string peselText, out Pesel pesel)
        {
            pesel = new Pesel(peselText);
            if (peselText.Length == 11)
            {
                int checkNumbersAllTheSame = 0;
                for (int i = 0; i < 11; i++)
                {
                    if (peselText[0] == peselText[i])
                    {
                        checkNumbersAllTheSame++;
                    }
                }
                if (checkNumbersAllTheSame == 11)
                {
                    return false;
                }
                int sumOfValidateNumbers = 0;
                int[] arrayOfValiationNumbers = { 1, 3, 7, 9, 1, 3, 7, 9, 1, 3 };
                int lastNumberOfPesel = (int)Char.GetNumericValue(peselText[10]);
                for (int i = 0; i < 10; i++)
                {
                    int peselTextToNumber = (int)Char.GetNumericValue(peselText[i]);
                    sumOfValidateNumbers += (peselTextToNumber * arrayOfValiationNumbers[i]);
                }
                int validateSum = 10 - sumOfValidateNumbers % 10;
                validateSum = (validateSum == 10) ? 0 : validateSum;
                if (validateSum == lastNumberOfPesel)
                {
                    return true;
                }
            }
            return false;
        }

        public static Pesel Parse(string peselText)
        {
            return new Pesel(peselText);
        }

        public override string ToString()
        {
            return peselTextRepresentation;
        }
    }
}

