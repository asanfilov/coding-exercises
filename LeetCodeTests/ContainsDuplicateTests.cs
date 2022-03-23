using NUnit.Framework;

namespace LeetCode.Tests
{
    [TestFixture()]
    public class ContainsDuplicateTests
    {
        [TestCase( true, new int[] { 1, 1 } )]
        [TestCase( true, new int[] { 1, 2, 3, 1 } )]
        [TestCase( true, new int[] { 1, 1, 1, 3, 3, 4, 3, 2, 4, 2 } )]
        [TestCase( false, new int[] { } )]
        [TestCase( false, new int[] { 1 } )]
        [TestCase( false, new int[] { 1, 2 } )]
        public void SolutionsTests(bool expected, int[] nums)
        {
            Assert.AreEqual( expected, ContainsDuplicate.NaiveSolution( nums ) );
            Assert.AreEqual( expected, ContainsDuplicate.OptimizedSolution( nums ) );
        }
    }
}
