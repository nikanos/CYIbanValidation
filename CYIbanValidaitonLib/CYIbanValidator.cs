using CYIbanValidaitonLib.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace CYIbanValidaitonLib
{
    public class CYIbanValidator : ICYIbanValidator
    {
        private static readonly Dictionary<char, int> ibanLetterMapping;
        private readonly IMod97 modder;

        static CYIbanValidator()
        {
            ibanLetterMapping = GetIbanLetterMapping();
        }

        public CYIbanValidator(IMod97 modder)
        {
            this.modder = modder ?? throw new ArgumentNullException(nameof(modder));
        }

        public bool CheckIban(string iban)
        {
            if (string.IsNullOrEmpty(iban))
                return false;

            string cleanIban = CleanupIban(iban);

            if (!IsCypriotIban(cleanIban))
                return false;

            string reversedIban = ReverseIban(cleanIban);
            string transformedIban = TransformIban(reversedIban);

            int mod97Result = modder.Mod97(transformedIban);

            const int EXPECTED_MOD_RESULT_TO_BE_VALID = 1;
            return mod97Result == EXPECTED_MOD_RESULT_TO_BE_VALID;
        }

        #region Private Methods

        private static Dictionary<char, int> GetIbanLetterMapping()
        {
            return new Dictionary<char, int>()
            {
                {'A',10},
                {'B',11},
                {'C',12},
                {'D',13},
                {'E',14},
                {'F',15},
                {'G',16},
                {'H',17},
                {'I',18},
                {'J',19},
                {'K',20},
                {'L',21},
                {'M',22},
                {'N',23},
                {'O',24},
                {'P',25},
                {'Q',26},
                {'R',27},
                {'S',28},
                {'T',29},
                {'U',30},
                {'V',31},
                {'W',32},
                {'X',33},
                {'Y',34},
                {'Z',35}
            };
        }

        private string CleanupIban(string iban)
        {
            //remove whitespace
            return new string(iban.Where(c => !Char.IsWhiteSpace(c)).ToArray());
        }

        private bool IsCypriotIban(string iban)
        {
            /*
                IBAN structure - CY2!n3!n5!n16!c
                IBAN length - 28
                IBAN electronic format example - CY17002001280000001200527600
            */
            const string CYIBAN_RE = "^CY[0-9]{10}[A-Z0-9]{16}$";
            return Regex.IsMatch(iban, CYIBAN_RE);
        }

        private string ReverseIban(string iban)
        {
            const int BBAN_INDEX_START = 4;
            //Move country + check digits to end
            return iban.Substring(BBAN_INDEX_START) + iban.Substring(0, BBAN_INDEX_START);
        }

        private string TransformIban(string iban)
        {
            StringBuilder result = new StringBuilder();
            foreach (char c in iban)
            {
                if (ibanLetterMapping.ContainsKey(c))
                    result.Append(ibanLetterMapping[c]);
                else
                    result.Append(c);
            }
            return result.ToString();
        }

        #endregion
    }
}
