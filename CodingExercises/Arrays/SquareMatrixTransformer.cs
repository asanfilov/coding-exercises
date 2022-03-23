namespace CodingExercises.Arrays
{
    public class SquareMatrixTransformer
    {
        public void ReferenceRotateRight(int[,] matrix, int n)
        {
            for (var layer = 0 ; layer < n / 2 ; ++layer)
            {
                var first = layer;
                var last = n - 1 - layer;

                for (var i = first ; i < last ; ++i)
                {
                    var offset = i - first;
                    var top = matrix[first, i]; // save top
                    // left -> top
                    matrix[first, i] = matrix[last - offset, first];
                    // bottom -> left
                    matrix[last - offset, first] = matrix[last, last - offset];
                    // right -> bottom
                    matrix[last, last - offset] = matrix[i, last];
                    // top -> right
                    matrix[i, last] = top; // right <- saved top
                }
            }
        }

        public void RotateRight(int[,] matrix, int size)
        {
            //The square matrix of size N contains N/2 inner squares
            int innerSquares = size / 2;
            // Perform circular rotation of each inner square by 90 degress by shifting each element clockwise
            int elementShift = size - 1;
            for (int squareId = 0 ; squareId < innerSquares ; squareId++)
            {
                RotateSquareRight(squareId, elementShift, matrix);
                elementShift -= 2;
            }
        }

        private void RotateSquareRight(int squareId, int elementShift, int[,] matrix)
        {
            int topLeftIndex = squareId;
            int bottomRightindex = squareId + elementShift;
            for (int column = topLeftIndex ; column < bottomRightindex ; column++)
            {
                ShiftElementsRight(topLeftIndex, column, elementShift, matrix);
            }
        }

        private void ShiftElementsRight(int topLeftIndex, int column, int elementShift, int[,] matrix)
        {
            int bottomRightindex = topLeftIndex + elementShift;

            int valueMoved = matrix[topLeftIndex, column];

            // step 1: top row becomes last column. All elements in the row will have the same column index:
            int moveToColumn = bottomRightindex;
            // Old column index becomes new row index in the last column:
            int moveToRow = column;
            valueMoved = Shift(valueMoved, moveToRow, moveToColumn, matrix);

            // step 2: last column rotates to last row. Element with the last column index moves to the first position in the row
            moveToRow = bottomRightindex;
            // New column in this inner square is relative. Use 0-based indexing:
            moveToColumn = bottomRightindex - (column - topLeftIndex);
            valueMoved = Shift(valueMoved, moveToRow, moveToColumn, matrix);

            // step 3: last row rotates to first column
            moveToRow = moveToColumn;
            moveToColumn = topLeftIndex;
            valueMoved = Shift(valueMoved, moveToRow, moveToColumn, matrix);

            // step 4: first column rotates to first row
            moveToRow = topLeftIndex;
            moveToColumn = column;
            Shift(valueMoved, moveToRow, moveToColumn, matrix);
        }

        private int Shift(int valueToWrite, int moveToRow, int moveToColumn, int[,] matrix)
        {
            int oldValue = matrix[moveToRow, moveToColumn];
            matrix[moveToRow, moveToColumn] = valueToWrite;
            return oldValue;
        }

        public static int[,] CreateSquareMatrix(int n, int startValue = 1, int increment = 1)
        {
            int[,] matrix = new int[n, n];
            for (int row = 0 ; row < n ; row++)
            {
                for (int column = 0 ; column < n ; column++)
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
            for (int column = n - 1 ; column >= 0 ; column--)
            {
                for (int row = 0 ; row < n ; row++)
                {
                    matrix[row, column] = startValue;
                    startValue += increment;
                }
            }
            return matrix;
        }
    }
}
