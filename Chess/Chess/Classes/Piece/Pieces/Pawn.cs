using System;
using Chess.Classes.Utils;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using Chess.Classes.Board;

namespace Chess.Classes.Piece.Pieces
{
    public class Pawn : PieceBase
    {
		private bool hasMoved = false;

		public Pawn(Vector2 position, Colors color)
		{
			Positon = position;
			Color = color;

			PieceImage = CreatePiece();

			CalculateAllLegalMoves();
		}

		protected override Image CreatePiece()
		{
			Image image = new();

			if (Color == Colors.white)
				image.Source = new BitmapImage(new Uri(@"Mats\pawn.png", UriKind.RelativeOrAbsolute));
			else
				image.Source = new BitmapImage(new Uri(@"Mats\b_pawn.png", UriKind.RelativeOrAbsolute));

			image.MouseUp += OnChessPiece_MouseUp;

			Grid.SetColumn(image, Positon.X);
			Grid.SetRow(image, Positon.Y);

			MainWindow._Current.chessBoard.Children.Add(image);

			return image;
		}

		protected override void CalculateAllLegalMoves()
		{
			CalculatePawnMoves();	
		}

		private void CalculatePawnMoves()
		{
			Vector2 one = new(0, 1);
			Vector2 two = new(0, 2);

			if (hasMoved)
			{
				int row = Positon.Y + one.Y;

				LegalMoves.Add(new(Positon.X, row));
			}
			else
			{
				int row = Positon.Y;

				for (int i = 1; i <= two.Y; i++)
				{
					row = Positon.Y + i;

					LegalMoves.Add(new(Positon.X, row));
				}
			}
		}
	}
}