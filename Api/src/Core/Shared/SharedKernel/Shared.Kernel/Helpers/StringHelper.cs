using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Core.Shared.Kernel.Helpers
{
    public static class StringHelper
    {


        public static string RemoveSpecialChars(this string str)
        {
            StringBuilder stringBuilder = new StringBuilder();
            var arrayText = str.Normalize(NormalizationForm.FormD).ToCharArray();
            foreach (char letter in arrayText)
            {
                if (CharUnicodeInfo.GetUnicodeCategory(letter) != UnicodeCategory.NonSpacingMark)
                    stringBuilder.Append(letter);
            }
            return stringBuilder.ToString();
        }


    }
}
