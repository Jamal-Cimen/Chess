using System;
using Chess.Classes.Utils;
using Chess.Classes.Utils.Types;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Collections.Generic;

namespace Chess.Classes.Piece.Pieces
{
	public class King : PieceBase
    {
        private List<Vector2> _possibleMoves = new();

        public King(Vector2 positon, Colors color)
        {
            Positon = positon;
            Color = color;

            PieceImage = CreatePiece();

		}

        public override Image CreatePiece()
        {
            Image image = new();

            if (Color == Colors.white)
            {
                image.Source = new BitmapImage(new Uri(@"Mats\king.png", UriKind.RelativeOrAbsolute));
            }
            else
            {
				image.Source = new BitmapImage(new Uri(@"Mats\b_king.png", UriKind.RelativeOrAbsolute));
			}

            Grid.SetRow(image, Positon.Y);
            Grid.SetColumn(image, Positon.X);

            image.MouseUp += OnChessPiece_MouseUp;

            MainWindow._Current.chessBoard.Children.Add(image);

            return image;
        }

		public override void CalculateAllLegalMoves()
		{
            CalculateStraightMoves();
		}
	}
}