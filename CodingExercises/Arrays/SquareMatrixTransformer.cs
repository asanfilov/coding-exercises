namespace CodingExercises.Arrays
{
    public class SquareMatrixTransformer
    {
        public void RotateRight(int[,] matrix, int size)
        {
            int squares = size / 2;
            int shift = size - 1;
            for (int square = 0; square < squares; square++)
            {
                RotateSquareRight(square, shift, matrix);
                shift = shift - 2;
            }
        }

        private void RotateSquareRight(int square, int shift, int[,] matrix)
        {
            int startRow = square;
            int startCol = square;
            for (int col = startCol; col < shift + startCol; col++)
            {
                ShiftElementsRight(startRow, col, shift, matrix);
            }
        }

        private void ShiftElementsRight(int startRow, int col, int shift, int[,] matrix)
        {
            int nv = matrix[startRow, col];

            int ovRow = startRow + col;
            int ovCol = shift;
            nv = Shift(nv, ovRow, ovCol, matrix);
            // step 2.
            ovRow = shift;
            ovCol = ovCol - col;
            nv = Shift(nv, ovRow, ovCol, matrix);
            //step 3.
            ovCol = ovCol - shift + col;
            ovRow = ovRow - col;
            nv = Shift(nv, ovRow, ovCol, matrix);
            //step 4.
            ovRow = ovRow - shift + col;
            ovCol = col;
            nv = Shift(nv, ovRow, ovCol, matrix);
        }

        private int Shift(int nv, int ovRow, int ovCol, int[,] matrix)
        {
            int ov = matrix[ovRow, ovCol];
            matrix[ovRow, ovCol] = nv;
            return ov;
        }

        public static int[,] CreateSquareMatrix(int n, int startValue = 1, int increment = 1)
        {
            int[,] matrix = new int[n, n];
            for (int row = 0; row < n; row++)
            {
                for (int column = 0; column < n; column++)
                {
                    matrix[row, column] = startValue;
                    startValue += increment;
                }
            }
            return matrix;
        }

        public static int[,] CreateSquareMatrixRotatedRight(int n, int startValue = 1, int increment = 1)
        {
            int[,] matrix = new int[n, n];
            for (int column = n - 1; column >= 0; column--)
            {
                for (int row = 0; row < n; row++)
                {
                    matrix[row, column] = startValue;
                    startValue += increment;
                }
            }
            return matrix;
        }
    }
}