using System;

namespace CodingExercises
{
    public class OneAway
    {
        public bool IsOneAway(string first, string second)
        {
            if (Math.Abs(first.Length - second.Length) > 1)
            {
                return false;
            }

            if (first.Length <= second.Length)
            {
                return compareStrings(first, second);
            }
            else
            {
                return compareStrings(second, first);
            }
        }

        private bool compareStrings(string notLonger, string other)
        {
            int nlPos = 0;
            int oPos = 0;
            int edits = 0;
            while (nlPos < notLonger.Length)
            {
                if (notLonger[nlPos] != other[oPos])
                {
                    edits++;
                    if (edits > 1)
                    {
                        return false;
                    }
                    if (notLonger.Length < other.Length)
                    {
                        oPos++;
                    }
                }
                nlPos++;
                oPos++;
            }
            return (edits <= 1);
        }
    }
}
