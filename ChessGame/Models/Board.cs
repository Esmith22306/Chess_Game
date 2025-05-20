namespace ChessGame.Models
{
    using ChessGame.Models.Pieces;

    public class Board
    {
        public Piece[,] Squares { get; set; }

        public Board()
        {
            Squares = new Piece[8, 8];
            InitializeBoard();
        }

        private void InitializeBoard()
        {
            // Place pieces on the board
            // For brevity, only Kings are placed. Add other pieces similarly.
            Squares[0, 4] = new King(Player.White);
            Squares[7, 4] = new King(Player.Black);
        }

        public void Display()
        {
            for (int row = 7; row >= 0; row--)
            {
                Console.Write($"{row + 1} ");
                for (int col = 0; col < 8; col++)
                {
                    var piece = Squares[row, col];
                    Console.Write(piece != null ? piece.Symbol : '.');
                    Console.Write(' ');
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
        }
    }
}
