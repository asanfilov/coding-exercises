using System.Collections.Generic;

namespace Interviews
{
    public class AmazingDrone
    {
        public const int MaxGridSize = 1000;

        public enum GridObjects
        {
            ClearPath = 0,
            Visited = -1,
            Target = 1,
            Wall = 9
        }

        private Queue<PathCell> bfsQueue;

        /// <summary>
        /// The drone must start from the top-left corner of the grid, which is always clear
        /// </summary>
        /// <param name="grid"></param>
        public AmazingDrone(List<List<int>> grid)
        {
            this.grid = grid;
            rows = grid.Count;
            columns = grid[0].Count;
            root.Previuos = null;
        }

        private readonly PathCell root = new( 0, 0 );
        private readonly List<List<int>> grid;
        private readonly int rows;
        private readonly int columns;

        public int GetShortestPathToTarget()
        {
            PathCell target = FindPathToTarget();
            const int TargetNotFound = -1;
            if (target == null) return TargetNotFound;

            int steps = 0;
            while (target.Previuos != null)
            {
                steps++;
                target = target.Previuos;
            }
            return steps;
        }

        /// <summary>
        /// Implements BFS algorithm https://en.wikipedia.org/wiki/Breadth-first_search
        /// </summary>
        /// <returns></returns>
        public PathCell FindPathToTarget()
        {
            PathCell target = null;

            bfsQueue = new();
            MarkVisited( root );
            bfsQueue.Enqueue( root );

            PathCell current = root;
            while (bfsQueue.Count > 0)
            {
                current = bfsQueue.Dequeue();
                if (IsTarget( current ))
                {
                    return current;
                }

                EnqueueValidStep( current.South, current );
                EnqueueValidStep( current.East, current );
                EnqueueValidStep( current.North, current );
                EnqueueValidStep( current.West, current );
            }

            return target;
        }

        private void MarkVisited(PathCell current)
        {
            int val = grid[current.Row][current.Column];
            if (val != (int)GridObjects.Target)
            {
                grid[current.Row][current.Column] = (int)GridObjects.Visited;
            }
        }

        private bool IsTarget(PathCell current)
        {
            return grid[current.Row][current.Column] == (int)GridObjects.Target;
        }

        private void EnqueueValidStep(PathCell adjacent, PathCell prev)
        {
            if (!IsValidStep( adjacent.Row, adjacent.Column )) return;

            if (!IsVisited( adjacent ))
            {
                MarkVisited( adjacent );
                adjacent.Previuos = prev;
                bfsQueue.Enqueue( adjacent );
            }
        }

        private bool IsVisited(PathCell cell)
        {
            return grid[cell.Row][cell.Column] == (int)GridObjects.Visited;
        }

        /// <summary>
        /// The drone cannot fly into walls and cannot leave the grid.
        /// </summary>
        public bool IsValidStep(int row, int col)
        {
            return IsInsideGrid( row, col ) && IsNotBlocked( row, col );
        }

        private bool IsInsideGrid(int row, int col)
        {
            return (row >= 0) && (row < rows)
                && (col >= 0) && (col < columns);
        }

        private bool IsNotBlocked(int row, int col)
        {
            return (grid[row][col] != (int)GridObjects.Wall);
        }
    }
}
