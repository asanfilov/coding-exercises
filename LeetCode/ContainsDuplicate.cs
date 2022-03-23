using System.Collections.Generic;

namespace LeetCode
{
    // Given an integer array nums, return true if any value appears at least twice in the array, and return false if every element is distinct.
    // Constraints:
    // 1 <= nums.length <= 10^5
    // -10^9 <= nums[i] <= 10^9
    public class ContainsDuplicate
    {
        /// <summary>
        /// First attempt. Takes O(n*n) time (equivalent to two nested for loops
        /// <para> Runtime: 660 ms, faster than 15.96% of C# online submissions for Contains Duplicate.
        ///         Memory Usage: 48.7 MB, less than 23.70% of C# online submissions for Contains Duplicate.</para>
        /// <para> Runtime: 884 ms, faster than 12.07% of C# online submissions for Contains Duplicate.
        ///         Memory Usage: 47.1 MB, less than 52.35% of C# online submissions for Contains Duplicate.</para>
        /// <para> Runtime: 1189 ms, faster than 5.77% of C# online submissions for Contains Duplicate.
        ///         Memory Usage: 47.8 MB, private less than 35.79% of C# online submissions for Contains Duplicate.</para>
        /// </summary>
        /// <param name="nums"></param>
        public static bool NaiveSolution(int[] nums)
        {
            if (nums.Length <= 1) return false;

            bool result = false;

            int i = 0;
            while (!result
                   && i < nums.Length - 1)
            {
                for (int j = i + 1 ; j < nums.Length ; j++)
                {
                    if (nums[j] == nums[i])
                    {
                        result = true;
                        break;
                    }
                }
                i++;
            }
            return result;
        }

        /// <summary>
        /// Optimized implementation. Takes O(n) time at the expense of O(n) space
        /// <para> Runtime: 270 ms, faster than 47.61% of C# online submissions for Contains Duplicate.
        ///        Memory Usage: 45.9 MB, less than 92.33% of C# online submissions for Contains Duplicate.</para>
        /// <para> Runtime: 359 ms, faster than 23.80% of C# online submissions for Contains Duplicate.
        ///        Memory Usage: 46.9 MB, less than 62.13% of C# online submissions for Contains Duplicate.</para>
        /// <para> Runtime: 393 ms, faster than 20.21% of C# online submissions for Contains Duplicate.
        /// Memory Usage: 47.1 MB, less than 48.93% of C# online submissions for Contains Duplicate.</para>
        /// </summary>
        /// <param name="nums"></param>
        public static bool OptimizedSolution(int[] nums)
        {
            if (nums.Length <= 1) return false;

            bool result = false;
            HashSet<int> unique = new();
            unique.Add( nums[0] );
            for (int j = 1 ; j < nums.Length ; j++)
            {
                if (unique.Contains( nums[j] ))
                {
                    result = true;
                    break;
                }
                else
                {
                    unique.Add( nums[j] );
                }
            }
            return result;
        }
    }
}
