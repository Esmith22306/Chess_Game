using ChessGame.Models;
using System;

namespace ChessGame
{
    class Program
    {
        static void Main(string[] args)
        {
            var board = new Board();
            var currentPlayer = Player.White;

            while (true)
            {
                Console.Clear();
                board.Display();

                Console.WriteLine($"{currentPlayer}'s turn. Enter move (e.g., e2 e4):");
                string input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input)) continue;

                string[] parts = input.Split(' ');
                if (parts.Length != 2)
                {
                    Console.WriteLine("Invalid input. Please enter move as 'e2 e4'. Press Enter to try again.");
                    Console.ReadLine();
                    continue;
                }

                try
                {
                    Position from = Position.FromAlgebraic(parts[0]);
                    Position to = Position.FromAlgebraic(parts[1]);

                    Piece piece = board.Squares[from.Row, from.Col];

                    if (piece == null)
                    {
                        Console.WriteLine("No piece at the starting position. Press Enter to try again.");
                        Console.ReadLine();
                        continue;
                    }

                    if (piece.Owner != currentPlayer)
                    {
                        Console.WriteLine("That piece does not belong to you. Press Enter to try again.");
                        Console.ReadLine();
                        continue;
                    }

                    if (!piece.IsValidMove(from, to, board.Squares))
                    {
                        Console.WriteLine("Invalid move for that piece. Press Enter to try again.");
                        Console.ReadLine();
                        continue;
                    }

                    // Apply move
                    board.Squares[to.Row, to.Col] = piece;
                    board.Squares[from.Row, from.Col] = null;

                    // Switch player
                    currentPlayer = currentPlayer == Player.White ? Player.Black : Player.White;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}. Press Enter to try again.");
                    Console.ReadLine();
                }
            }
        }
    }
}
