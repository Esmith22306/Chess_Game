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
}

