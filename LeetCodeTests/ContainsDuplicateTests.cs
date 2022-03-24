using NUnit.Framework;

namespace LeetCode.Tests
{
    [TestFixture()]
    public class ContainsDuplicateTests
    {
        [TestCase(true, new int[] { 1, 1 })]
        [TestCase(true, new int[] { 1, 2, 3, 1 })]
        [TestCase(true, new int[] { 1, 1, 1, 3, 3, 4, 3, 2, 4, 2 })]
        [TestCase(false, new int[] { })]
        [TestCase(false, new int[] { 1 })]
        [TestCase(false, new int[] { 1, 2 })]
        public void Solutions_217_Tests(bool expected, int[] nums)
        {
            Assert.AreEqual(expected, ContainsDuplicateI_217.NaiveSolution(nums));
            Assert.AreEqual(expected, ContainsDuplicateI_217.OptimizedSolution(nums));
        }

        [TestCase(true, new int[] { 1, 2, 3, 1 }, 3)]
        [TestCase(true, new int[] { 1, 0, 1, 1 }, 1)]
        [TestCase(false, new int[] { 1, 2, 3, 1, 2, 3 }, 2)]
        public void Solutions_219_Tests(bool expected, int[] nums, int k)
        {
            Assert.AreEqual(expected, ContainsDuplicateII_219.ContainsNearbyDuplicate(nums, k));
        }
    }
}
