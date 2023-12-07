using System;
using Chess.Classes.Utils;
using Chess.Classes.Utils.Types;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Chess.Classes.Piece.Pieces
{
    public class Rook : PieceBase
    {
		public Rook(Vector2 positon, Colors color)
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
				image.Source = new BitmapImage(new Uri(@"Mats\rook.png", UriKind.RelativeOrAbsolute));
			}
			else
			{
				image.Source = new BitmapImage(new Uri(@"Mats\b_rook.png", UriKind.RelativeOrAbsolute));
			}

			Grid.SetRow(image, Positon.Y);
			Grid.SetColumn(image, Positon.X);

			image.MouseUp += OnChessPiece_MouseUp;

			MainWindow._Current.chessBoard.Children.Add(image);

			return image;
		}

		public override void CalculateAllLegalMoves()
		{
			
		}
	}
}