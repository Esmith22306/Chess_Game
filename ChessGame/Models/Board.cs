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
            // Kings
            Squares[0, 4] = new King(Player.White);
            Squares[7, 4] = new King(Player.Black);

            // Pawns
            for (int col = 0; col < 8; col++)
            {
                Squares[1, col] = new Pawn(Player.White);
                Squares[6, col] = new Pawn(Player.Black);
            }

            // Add more pieces later: Rooks, Knights, Bishops, Queen
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
