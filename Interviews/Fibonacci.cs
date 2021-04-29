using System;

namespace Interviews
{
    public class Fibonacci
    {
        /*  7.540.113.804.746.346.429 is the 93rd Fibonacci number with the index starting from 1.
         * 12.200.160.415.121.876.738 is the 94th, but because
         *  9.223.372.036.854.780.000 is the maximum value for a variable of type long (Int64), set a limit:
         */
        private const int maxNumbersSupported = 93;
        private static long[] fibMemo = new long[maxNumbersSupported + 1];

        /// <summary>
        /// Calculates the nth Fibonacci number in O(n) time or better without using any "for" or "while" loops
        /// </summary>
        public static long NthNumber(int nth)
        {
            if (nth < 1 || nth > maxNumbersSupported)
            {
                throw new ArgumentException(
                    $"Please provide a positive value in the range [1..{maxNumbersSupported}]" );
            }

            if (nth == 1)
            {
                return 0;
            }
            if (nth == 2)
            {
                return 1;
            }

            if (fibMemo[nth] != 0)
            {
                return fibMemo[nth];
            }
            else
            {
                fibMemo[nth] = NthNumber( nth - 1 ) + NthNumber( nth - 2 );
                return fibMemo[nth];
            }
        }
    }
}
