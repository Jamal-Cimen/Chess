using System;
using Chess.Classes.Utils;
using Chess.Classes.Piece.Pieces;
using System.Collections.Generic;
using Chess.Classes.Utils.Types;
using Chess.Classes.Piece;

namespace Chess.Classes.Board
{
    /// <summary>
    /// Des is der Hans
    /// </summary>

    public class BoardManager
    {
		public static BoardManager boardManager;

		public PieceBase[,] Pieces = new PieceBase[8, 8];
		public PieceBase selectedPiece { get; set; }

        Dictionary<char, Type> pieces = new()
        {
			{ 'r', typeof(Rook) },
			{ 'n', typeof(Knight) },
			{ 'b', typeof(Bishop) },
			{ 'q', typeof(Queen) },
			{ 'k', typeof(King) },
			{ 'p', typeof(Pawn) },
			{ 'R', typeof(Rook) },
			{ 'N', typeof(Knight) },
			{ 'B', typeof(Bishop) },
			{ 'Q', typeof(Queen) },
			{ 'K', typeof(King) },
			{ 'P', typeof(Pawn) }
		};

		public BoardManager()
		{
			boardManager = this;
		}

        public PieceBase AddPieceToBoard(char piece, Vector2 position, Colors color)
        {
			PieceBase piecebase = Activator.CreateInstance(pieces[piece], position, color) as PieceBase;

			Pieces[position.X, position.Y] = piecebase;

			return piecebase;
        }
    }
}