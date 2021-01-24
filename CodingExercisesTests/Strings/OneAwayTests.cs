using NUnit.Framework;

namespace CodingExercises.Tests
{
    [TestFixture()]
    public class OneAwayTests
    {
        OneAway oneAway = new OneAway();

        [Test()]
        public void IsOneAway_RemovedCharInside_True()
        {
            Assert.True(oneAway.IsOneAway(
                "sale",
                "sle"));
        }

        [Test()]
        public void IsOneAway_AddedEndingChar_True()
        {
            Assert.True(oneAway.IsOneAway(
                "sale",
                "sales"));
        }

        [Test()]
        public void IsOneAway_ReplacedStartingChar_True()
        {
            Assert.True(oneAway.IsOneAway(
                "sale",
                "bale"));
        }

        [Test()]
        public void IsOneAway_ReplacedTwoChars_False()
        {
            Assert.False(oneAway.IsOneAway(
                "sale",
                "bake"));
        }

        [Test()]
        public void IsOneAway_LengthDiffersByMoreThanOne_False()
        {
            Assert.False(oneAway.IsOneAway(
                "quick",
                "quickly"));
        }
    }
}
