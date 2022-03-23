using System;

namespace Interviews
{
    public class PathCell
    {
        public PathCell(int row, int column)
        {
            this.Row = row;
            this.Column = column;
        }

        public int Row { get; set; }
        public int Column { get; set; }
        public PathCell Previuos { get; set; }
        public PathCell North => new(Row - 1, Column);
        public PathCell South => new(Row + 1, Column);
        public PathCell East => new(Row, Column + 1);
        public PathCell West => new(Row, Column - 1);

        public override bool Equals(object obj)
        {
            return obj is PathCell cell &&
                   Row == cell.Row &&
                   Column == cell.Column;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Row, Column);
        }
    }
}
