using System;
using static System.Console;

namespace problemSolving
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                doWork();
            }
            catch (Exception ex)
            {
                WriteLine(ex.Message);
            }
        }

        static void doWork()
        {
            test_CSV();
            test_toArabic();
            test_Islands();
        }


        static void test_CSV()
        {
            int[] arrayOfInt;
            arrayOfInt = new int[] { -10, -9, -8, 5, 7, 9, 10, 11, 12, 13 };
            WriteLine("CSV test of the mixed values.");
            WriteLine("Input: " + string.Join(" ",Array.ConvertAll(arrayOfInt, v => v.ToString())));
            WriteLine("Output:" + arrayOfInt.to_CSV(',',':'));
                        
            arrayOfInt = new int[] { 0, 1, 2, 5, 7, 9, 10, 11, 12, 13 };
            WriteLine("\nCSV test with user defined separator and concatenator: ");
            WriteLine("Input: " + string.Join(" ", Array.ConvertAll(arrayOfInt, v => v.ToString())));
            WriteLine("Output:" + arrayOfInt.to_CSV(';', ':'));

            WriteLine("\nCSV test with 0 length and null value of int[]");
            arrayOfInt = null;
            WriteLine(arrayOfInt.to_CSV() + " <- empty string if int[] is null");
            arrayOfInt = new int[0];
            WriteLine(arrayOfInt.to_CSV() + " <- empty string if iny[] is 0 length");

            WriteLine(Environment.NewLine + new String('-', 20) + Environment.NewLine);
        }
        static void test_toArabic()
        {
            WriteLine($"Roman to Arabic numerals conversion test.\n\nInput: CCCXCIX, output: {NumConverter.RomanToArabic("CCCXCIX")}"); //399
            WriteLine($"Input: MMMCMXCIX, output: {NumConverter.RomanToArabic("MMMCMXCIX")}"); //3999
            WriteLine("Roman numbers higher than 3999 are not supported");

            WriteLine(Environment.NewLine + new String('-', 20) + Environment.NewLine);
        }
        static void test_Islands()
        {
            WriteLine("Islands or figures counting test.");
            byte[,] samplePicture = new byte[5, 16]
            {
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                {0,1,0,0,0,1,1,1,0,0,1,1,0,1,1,0 },
                {0,1,0,0,0,1,1,1,0,0,1,1,1,1,0,0 },
                {0,1,0,0,0,1,1,1,0,0,1,1,0,1,1,0 },
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 }


            };

            Islands.CountIslands(samplePicture);

            WriteLine(Environment.NewLine + new String('-', 20) + Environment.NewLine);

            WriteLine("Second Islands or figures counting test. Input is the same" +
                      "\nNotation of white dots changed to blank space.");
            Islands.CountIslands(samplePicture,'O',' ');
        }

    }

}
