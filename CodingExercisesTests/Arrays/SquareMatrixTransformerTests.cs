using NUnit.Framework;

namespace CodingExercises.Arrays.Tests
{
    [TestFixture()]
    public class SquareMatrixTransformerTests
    {
        private SquareMatrixTransformer smt = new SquareMatrixTransformer();

        [Test()]
        public void RotateRight_Matrix5()
        {
            smt.RotateRight( matrix5, 5 );
            Assert.AreEqual( matrix5RotatedRight, matrix5 );
        }

        [Test()]
        public void RotateRight_Matrix4()
        {
            smt.RotateRight( matrix4, 4 );
            Assert.AreEqual( matrix4RotatedRight, matrix4 );
        }

        [TestCase( 13 )]
        [TestCase( 12 )]
        public void RotateRight(int size)
        {
            var matrix = SquareMatrixTransformer.CreateSquareMatrix( size );
            var matrixRotated = SquareMatrixTransformer.CreateSquareMatrixRotatedRight( size );

            smt.RotateRight( matrix, size );
            Assert.AreEqual( matrixRotated, matrix );
        }

        [TestCase( 4 )]
        [TestCase( 5 )]
        public void ReferenceRotateRight(int size)
        {
            var matrix = SquareMatrixTransformer.CreateSquareMatrix( size );
            var matrixRotated = SquareMatrixTransformer.CreateSquareMatrixRotatedRight( size );

            smt.ReferenceRotateRight( matrix, size );
            Assert.AreEqual( matrixRotated, matrix );
        }

        [Test()]
        public void RotateRight_Matrix3()
        {
            smt.RotateRight( matrix3, 3 );
            Assert.AreEqual( matrix3RotatedRight, matrix3 );
        }

        private int[,] matrix3 = new int[3, 3] {
            {  1,  2,  3 },
            {  5,  6,  7 },
            {  9, 10, 11 }
        };

        private int[,] matrix3RotatedRight = new int[3, 3] {
            {  9,  5,  1 },
            {  10,  6,  2 },
            {  11,  7,  3 }
        };

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
