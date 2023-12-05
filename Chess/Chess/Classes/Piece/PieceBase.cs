using Chess.Classes.Board;
using Chess.Classes.Utils;
using Chess.Classes.Utils.Types;
using System;
using System.Diagnostics;
using System.Windows.Controls;
using System.Windows.Input;

namespace Chess.Classes.Piece
{
	public abstract class PieceBase
    {
        public Image PieceImage { get; set; }
        public abstract Image CreatePiece();
        public Colors Color;
        private Vector2 _positon;
        public Vector2 Positon
        {
            get => _positon;

            set 
            {
                if (PieceImage != null)
                {
                    Debug.WriteLine("HAns");

                    BoardManager.boardManager.Pieces[value.X, value.Y] = null;
                    BoardManager.boardManager.Pieces[value.X, value.Y] = BoardManager.boardManager.selectedPiece;

					Grid.SetColumn(PieceImage, value.X);
                    Grid.SetRow(PieceImage, value.Y);
                }

                _positon = value;
            }
        }

        public bool CanMove { get; set; } = true;
        public bool IsPieceSelected { get; set; }
        //private PieceBase _piece;

        internal void PieceMovement(PieceBase piece,Vector2 pos)
        {
            if (CanMove)
            {
                
            }
        }

        internal void OnChessPiece_MouseUp(object sender, MouseButtonEventArgs e)
        {
            PieceBase piece = this;

            if (piece != null)
            {
				BoardManager.boardManager.selectedPiece = BoardManager.boardManager.Pieces[piece.Positon.X, piece.Positon.Y];

                BoardManager.boardManager.selectedPiece.Positon = new(1, 1);
			}
		}
    }
}