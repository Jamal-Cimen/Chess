using System;
using Chess.Classes.Utils;
using Chess.Classes.Piece.Pieces;
using System.Collections.Generic;
using Chess.Classes.Piece;
using System.Windows.Controls;
using System.Diagnostics;
using System.Windows.Media.Converters;

namespace Chess.Classes.Board
{
    /// <summary>
    /// Des is der Hans
    /// </summary>

    public class BoardManager
    {
		public static BoardManager boardManager;

		public Colors whosTurn = Colors.white;

		public List<PieceBase> BlackPieces = new();
		public List<PieceBase> WhitePieces = new();

		public PieceBase[,] PiecePositions = new PieceBase[8, 8];
		public PieceBase _selectedPiece;
		public PieceBase SelectedPiece
		{
			get => _selectedPiece;

			set
			{
				_selectedPiece = value;
			}
		}
		private Vector2 _selectedPosition;
		public Vector2 SelectedPostion
		{
			get => _selectedPosition;

			set
			{
				if (SelectedPiece != null)
				{
					MovePieceTo();

					Grid.SetColumn(SelectedPiece.PieceImage, value.X);
					Grid.SetRow(SelectedPiece.PieceImage, value.Y);
				}

				_selectedPosition = value;
				SelectedPiece = null;
				//Debug.WriteLine(PiecePositions[SelectedPiece.Positon.X, SelectedPiece.Positon.Y]);
			}
		}

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

			if (piecebase.Color == Colors.Black)
				BlackPieces.Add(piecebase);
			else
				WhitePieces.Add(piecebase);

			PiecePositions[position.X, position.Y] = piecebase;

			return piecebase;
        }
    
		public void MovePieceTo()
		{
			PiecePositions[SelectedPiece.Positon.X, SelectedPiece.Positon.Y] = null;
			PiecePositions[SelectedPostion.X, SelectedPostion.Y] = SelectedPiece;
		}
	}
}