using System.Collections.Generic;

namespace LeetCode
{
    // Given an integer array nums, return true if any value appears at least twice in the array, and return false if every element is distinct.
    // Constraints:
    // 1 <= nums.length <= 10^5
    // -10^9 <= nums[i] <= 10^9
    public class ContainsDuplicateI_217
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
            unique.Add(nums[0]);
            for (int j = 1 ; j < nums.Length ; j++)
            {
                if (unique.Contains(nums[j]))
                {
                    result = true;
                    break;
                }
                else
                {
                    unique.Add(nums[j]);
                }
            }
            return result;
        }
    }

    public class ContainsDuplicateII_219
    {
        /// <summary>
        /// Given an integer array nums and an integer k,
        /// return true if there are two distinct indices i and j in the array
        /// such that nums[i] == nums[j] and abs(i - j) <= k.
        /// </summary>
        /// <example>Input: nums = [1,2,3,1], k = 3. Output: true</example>
        /// <example>Input: nums = [1,0,1,1], k = 1. Output: true</example>
        /// <example>Input: nums = [1,2,3,1,2,3], k = 2. Output: false</example>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        public static bool ContainsNearbyDuplicate(int[] nums, int k)
        {
            bool result = false;
            Dictionary<int, int> kByNum = new();
            kByNum.Add(nums[0], 0);
            // Runtime: O(n)
            for (int i = 1 ; i < nums.Length ; i++)
            {
                if (kByNum.ContainsKey(nums[i]))//This method approaches an O(1) operation.
                {
                    result = (i - kByNum[nums[i]]) <= k;
                }

                if (result) break;
                kByNum[nums[i]] = i;
            }

            return result;
            // Runtime: 244 ms, faster than 74.87 % of C# online submissions for Contains Duplicate II.
            // Memory Usage: 49.8 MB, less than 54.34 % of C# online submissions for Contains Duplicate II.
            //Runtime: 245 ms, faster than 74.34% of C# online submissions for Contains Duplicate II.
            //Memory Usage: 50.5 MB, less than 39.29 % of C# online submissions for Contains Duplicate II.
        }
    }
}
