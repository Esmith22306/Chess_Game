namespace ChessGame.Models
{
    public class Position
    {
        public int Row { get; set; }
        public int Col { get; set; }

        public Position(int row, int col)
        {
            Row = row;
            Col = col;
        }

        public static Position FromAlgebraic(string notation)
    {
        if (notation.Length != 2) throw new ArgumentException("Invalid position string");

        int col = notation[0] - 'a';
        int row = int.Parse(notation[1].ToString()) - 1;

        return new Position(row, col);
    }

    }
}
