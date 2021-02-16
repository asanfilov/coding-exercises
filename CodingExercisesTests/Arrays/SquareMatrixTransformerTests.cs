using NUnit.Framework;

namespace CodingExercises.Arrays.Tests
{
    [TestFixture()]
    public class SquareMatrixTransformerTests
    {
        [Test()]
        public void CreateSquareMatrixTest()
        {
            var matrix = SquareMatrixTransformer.CreateSquareMatrix(4);
            Assert.AreEqual(matrix4, matrix);
        }

        [Test()]
        public void CreateSquareMatrixRotatedRightTest()
        {
            var matrix = SquareMatrixTransformer.CreateSquareMatrixRotatedRight(5);
            Assert.AreEqual(matrix5RotatedRight, matrix);
        }

        [Test()]
        public void RotateRight_Matrix5()
        {
            SquareMatrixTransformer smt = new SquareMatrixTransformer();
            smt.RotateRight(matrix5, 5);
            Assert.AreEqual(matrix5RotatedRight, matrix5);
        }

        [Test()]
        public void RotateRight_Matrix4()
        {
            SquareMatrixTransformer smt = new SquareMatrixTransformer();
            smt.RotateRight(matrix4, 4);
            Assert.AreEqual(matrix4RotatedRight, matrix4);
        }

        private int[,] matrix5 = new int[5, 5] {
            {  1,  2,  3,  4,  5 },
            {  6,  7,  8,  9, 10 },
            { 11, 12, 13, 14, 15 },
            { 16, 17, 18, 19, 20 },
            { 21, 22, 23, 24, 25 },
        };

        private int[,] matrix5RotatedRight = new int[5, 5] {
            { 21, 16, 11,  6, 1 },
            { 22, 17, 12,  7, 2 },
            { 23, 18, 13,  8, 3 },
            { 24, 19, 14,  9, 4 },
            { 25, 20, 15, 10, 5 }
        };

        private int[,] matrix4 = new int[4, 4] {
            {  1,  2,  3,  4 },
            {  5,  6,  7,  8 },
            {  9, 10, 11, 12 },
            { 13, 14, 15, 16 }
        };

        private int[,] matrix4RotatedRight = new int[4, 4] {
            { 13,  9,  5,  1 },
            { 14, 10,  6,  2 },
            { 15, 11,  7,  3 },
            { 16, 12,  8,  4 }
        };
    }
}
