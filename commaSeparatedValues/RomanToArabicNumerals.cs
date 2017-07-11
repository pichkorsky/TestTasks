using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace problemSolving
{
    static class NumConverter
    {
        private enum RomanNumerals { I = 1, V = 5, X = 10, L = 50, C = 100, D = 500,  M = 1000};

        /// <summary>
        /// Roman numerals higher then 3999 are not supported!
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        static public int RomanToArabic(string source)
        {
            if (source == null || source.Length < 1)
                return 0; 
            
            // Converting single Roman numeral
            if (source.Length == 1)
            {
                return ((int)(RomanNumerals)Enum.Parse(typeof(RomanNumerals), source, true));
            }

            // Parsing source string for Roman numerals and store them into array of RomanNumerals
            RomanNumerals[] romanSource = new RomanNumerals[source.Length];
            for (int i = 0; i <= romanSource.Length-1; i++)
            {
                romanSource[i] = (RomanNumerals)Enum.Parse(typeof(RomanNumerals), source[i].ToString(), true);
            }

            // Converting array of RomanNumerals to Arabic values

            int result = 0;

            for (int i = 1; i <= romanSource.Length-1; i++)
            {
                if (romanSource[i] > romanSource[i - 1])
                {
                    result += (int)romanSource[i] - (int)romanSource[i - 1];
                    ++i;
                }
                else
                {
                    if (i == romanSource.Length-1)
                    {
                        result += (int)romanSource[i - 1] + (int)romanSource[i];                        
                    }
                        
                    else
                        result += (int)romanSource[i - 1];
                }
            }

            return result;
        }
        
    }
}
