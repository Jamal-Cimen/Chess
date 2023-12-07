using System;
using Chess.Classes.Utils;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Chess.Classes.Piece.Pieces
{
	public class Bishop : PieceBase
	{
		public Bishop(Vector2 position, Colors color)
		{
			Positon = position;
			Color = color;

			PieceImage = CreatePiece();
		}

		protected override Image CreatePiece()
		{
			Image image = new();

			if (Color == Colors.white)
				image.Source = new BitmapImage(new Uri(@"Mats\bishop.png", UriKind.RelativeOrAbsolute));
			else
				image.Source = new BitmapImage(new Uri(@"Mats\b_bishop.png", UriKind.RelativeOrAbsolute));

			image.MouseUp += OnChessPiece_MouseUp;

			Grid.SetColumn(image, Positon.X);
			Grid.SetRow(image, Positon.Y);

			MainWindow._Current.chessBoard.Children.Add(image);

			return image;
		}

		protected override void CalculateAllLegalMoves()
		{
			
		}

	}
}