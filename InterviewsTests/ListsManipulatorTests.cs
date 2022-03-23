using System.Collections.Generic;

using NUnit.Framework;

namespace Interviews.Tests
{
    internal class ListsManipulatorTests
    {
        [Test]
        public void EDTest()
        {
            List<string> original = new List<string> { "one", "two", "three" };
            List<string> addList = new List<string> { "one", "two", "five", "six" };
            List<string> deleteList = new List<string> { "two", "five" };

            List<string> expected = new List<string> { "three", "six", "one" };

            Assert.AreEqual(expected, ListsManipulator.Merge(original, addList, deleteList));
        }

        [Test]
        public void MyTest()
        {
            List<string> original = new List<string> { "one" };
            List<string> addList = new List<string> { "two" };
            List<string> deleteList = new List<string> { "five" };

            List<string> expected = new List<string> { "two", "one" };

            Assert.AreEqual(expected, ListsManipulator.Merge(original, addList, deleteList));
        }
    }
}
