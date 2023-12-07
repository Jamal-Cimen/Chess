using System;
using Chess.Classes.Utils;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Collections.Generic;
using Chess.Classes.Board;
using System.Diagnostics;

namespace Chess.Classes.Piece.Pieces
{
	public class King : PieceBase
    {
        private List<Vector2> _possibleMoves = new()
        {
            {new(-1,-1) },
            {new(0,-1) },
            {new(1,-1) }, 
            {new(1,0) },  
            {new(1,1) }, 
            {new(0,1) },
            {new(-1,1) },
            {new(-1,0) }, 
		};

        public King(Vector2 positon, Colors color)
        {
            Positon = positon;
            Color = color;
            CanMove = true;

            PieceImage = CreatePiece();
		}

		protected override Image CreatePiece()
        {
            Image image = new();

            if (Color == Colors.white)
                image.Source = new BitmapImage(new Uri(@"Mats\king.png", UriKind.RelativeOrAbsolute));
            else
				image.Source = new BitmapImage(new Uri(@"Mats\b_king.png", UriKind.RelativeOrAbsolute));		
            
            image.MouseUp += OnChessPiece_MouseUp;

            Grid.SetRow(image, Positon.Y);
            Grid.SetColumn(image, Positon.X);

            MainWindow._Current.chessBoard.Children.Add(image);

            return image;
        }

        private void CalculateKingMoves()
        {
            int column = Positon.X;
            int row = Positon.Y;

            foreach (Vector2 pos in _possibleMoves)
            {
				column = Positon.X + pos.X;
                row = Positon.Y + pos.Y;

				new MoveGrid(new(column, row));
			}
        }

		protected override void CalculateAllLegalMoves()
		{
            CalculateKingMoves();
		}
	}
}