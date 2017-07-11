using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace problemSolving
{
    static class CommaSepValues
    {
        public static string to_CSV(this int[] source, char separator = ',', char concatenator = '-')
        {
            if (source == null || source.Length < 1)
                return String.Empty;

            if (source.Length > int.MaxValue)
                return $"to_CSV method can't handle arrays that are longer than {int.MaxValue}";

            Array.Sort(source); // just in case...

            // pushing first value to the result string
            string result = source[0].ToString();

            // iterating through the source int array
            for (int i = 1; i <= source.Length - 1; i++)
            {
                //if value at current index and value in index-1 are not consecutive -> separate them with separator and continue iteration;
                
                if (source[i] - source[i - 1] != 1) 
                {
                    result += $"{separator}{source[i]}";
                    continue;
                }

                // if values are consecutive -> search for the end of the sequence

                do
                {
                    ++i;

                } while ((source[i] - source[i - 1] == 1) && (i < source.Length - 1));

                //perform necessary test to form up end of the result string  
                //in cases when it's ended with a sequence
                if ((i < source.Length) && (source[i] - source[i - 1] == 1))
                {
                    result += $"{concatenator}{source[i]}";
                }
                else
                {
                    result += $"{concatenator}{source[i - 1]}{separator}{source[i]}";
                }

            }

            return result;
        }
    }

}
