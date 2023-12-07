using Chess.Classes.Board;
using Chess.Classes.Utils;
using Chess.Classes.Utils.Types;
using System;
using System.Linq;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Collections.Generic;
//using System.Drawing;
using System.Windows.Shapes;

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
                    BoardManager.boardManager.PiecePositions[value.X, value.Y] = null;
                    BoardManager.boardManager.PiecePositions[value.X, value.Y] = BoardManager.boardManager.SelectedPiece;

					Grid.SetColumn(PieceImage, value.X);
                    Grid.SetRow(PieceImage, value.Y);
                }

                _positon = value;
            }
        }
        
        public bool CanMove { get; set; } = true;
        public bool IsPieceSelected { get; set; }
        //private PieceBase _piece;

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

        public abstract void CalculateAllLegalMoves();

        public List<Vector2> AllMoves = new();

        public MoveTypes MoveType;

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
				BoardManager.boardManager.SelectedPiece = BoardManager.boardManager.PiecePositions[piece.Positon.X, piece.Positon.Y];
			}

            if (e.LeftButton == MouseButtonState.Released)
            {
                Debug.WriteLine(CheckPosition().X);
            }
		}

		private Vector2 CheckPosition()
		{
			Point point = Mouse.GetPosition(MainWindow._Current.chessBoard);

			int column = (int)(point.X / MainWindow._Current.chessBoard.ColumnDefinitions[0].ActualWidth);
			int row = (int)(point.Y / MainWindow._Current.chessBoard.RowDefinitions[0].ActualHeight);

			return new(column, row);
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

        public void CalculateDiagonalMoves(Vector2 direction)
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

    }
}