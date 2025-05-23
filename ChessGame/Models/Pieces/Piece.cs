namespace ChessGame.Models.Pieces
{
    public abstract class Piece
    {
        public Player Owner { get; set; }
        public abstract char Symbol { get; }
        public abstract bool IsValidMove(Position from, Position to, Piece[,] board);

        protected Piece(Player owner)
        {
            Owner = owner;
        }
    }

        public class King : Piece
    {
        public override char Symbol => Owner == Player.White ? 'K' : 'k';

        public King(Player owner) : base(owner) { }

        public override bool IsValidMove(Position from, Position to, Piece[,] board)
        {
            int rowDiff = Math.Abs(from.Row - to.Row);
            int colDiff = Math.Abs(from.Col - to.Col);
            return rowDiff <= 1 && colDiff <= 1;
        }
    }

    public class Pawn : Piece
{
    public override char Symbol => Owner == Player.White ? 'P' : 'p';

    public Pawn(Player owner) : base(owner) { }

    public override bool IsValidMove(Position from, Position to, Piece[,] board)
    {
        int direction = Owner == Player.White ? 1 : -1;
        int startRow = Owner == Player.White ? 1 : 6;

        // Move forward
        if (from.Col == to.Col)
        {
            if (to.Row - from.Row == direction && board[to.Row, to.Col] == null)
                return true;

            // Allow double move from start position
            if (from.Row == startRow && to.Row - from.Row == 2 * direction &&
                board[from.Row + direction, from.Col] == null &&
                board[to.Row, to.Col] == null)
                return true;
        }

        // Capture
        if (Math.Abs(from.Col - to.Col) == 1 && to.Row - from.Row == direction)
        {
            if (board[to.Row, to.Col] != null && board[to.Row, to.Col].Owner != Owner)
                return true;
        }

        return false;
    }
}

}

