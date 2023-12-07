using Chess.Classes.Board;
using Chess.Classes.Utils;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Collections.Generic;
//using System.Drawing;

namespace Chess.Classes.Piece
{
	public abstract class PieceBase
    {
        public Image PieceImage { get; set; }

        protected abstract Image CreatePiece();

        public Colors Color;

        private Vector2 _positon;
        public Vector2 Positon
        {
            get => _positon;

            set 
            {
                if (PieceImage != null)
                {
                    BoardManager.boardManager.PiecePositions[value.X, value.Y] = null;
                    BoardManager.boardManager.PiecePositions[value.X, value.Y] = BoardManager.boardManager.SelectedPiece;

					Grid.SetColumn(PieceImage, value.X);
                    Grid.SetRow(PieceImage, value.Y);
                }

                _positon = value;
            }
        }
        
        public bool CanMove { get; set; } = true;

        public List<Vector2> StraightMoves = new()
        {
            {new(-1,0) },
            {new(1,0) },
            {new(0,1) },
            {new(0,-1) }
		};

		public List<Vector2> DiagonalMoves = new()
        {
            {new (-1,1) },
            {new (1,-1) },
            {new (-1,-1) },
            {new (1,1) }
        };

        public List<Vector2> LegalMoves = new();

        protected abstract void CalculateAllLegalMoves();

        public List<Vector2> AllMoves = new();

        public MoveTypes MoveType;

        internal void PieceMovement(PieceBase piece,Vector2 pos)
        {
            if (CanMove)
            {
                
            }
        }

        public void CalculateLine(Vector2 direction)
        {
            int column = Positon.X; // Intial Value(s);
            int row = Positon.Y;

            for (int i = 0; i < 7; i++)
            {
                column += direction.X; //Add direction to the initlaValue and update them;
                row += direction.Y;

                if (row is > -1 and < 8 && column is > -1 and < 8)
                {
					new MoveGrid(new(column, row));
				}
                else
                {
                    break;
                }
            }
        }

        public void CalculateStraightMoves()
        {
            for (int i = 0; i < StraightMoves.Count; i++)
				CalculateLine(StraightMoves[i]);
		}

        public void CalculateDiagonalMoves()
        {
            for (int i = 0; i < DiagonalMoves.Count; i++)
                CalculateLine(DiagonalMoves[i]);
			
		}

        public void DisplayLegalMoves()
        {
            foreach (Vector2 move in LegalMoves)
            {
                new MoveGrid(move);
            }
        }

        internal void OnChessPiece_MouseUp(object sender, MouseButtonEventArgs e)
        {
            PieceBase piece = this;

            if (piece != null)
            {
                BoardManager.boardManager.SelectedPiece = piece;//BoardManager.boardManager.PiecePositions[piece.Positon.X, piece.Positon.Y];
			}

            if (piece.CanMove)
            {
                piece.CalculateAllLegalMoves();

                piece.DisplayLegalMoves();
            }
		}
    }
}