using System;
using Chess.Classes.Utils;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using Chess.Classes.Board;
using System.Diagnostics;
using System.Collections.Generic;

namespace Chess.Classes.Piece.Pieces
{
	public class Knight : PieceBase
	{
		private bool hasMoved = true;

		public Knight(Vector2 position, Colors color)
		{
			Positon = position;
			Color = color;

			PieceImage = CreatePiece();
		}

		protected override Image CreatePiece()
		{
			Image image = new();

			if (Color == Colors.white)
				image.Source = new BitmapImage(new Uri(@"Mats\knight.png", UriKind.RelativeOrAbsolute));
			else
				image.Source = new BitmapImage(new Uri(@"Mats\b_knight.png", UriKind.RelativeOrAbsolute));

			image.MouseUp += OnChessPiece_MouseUp;

			Grid.SetColumn(image, Positon.X);
			Grid.SetRow(image, Positon.Y);

			MainWindow._Current.chessBoard.Children.Add(image);

			return image;
		}

		protected override void CalculateAllLegalMoves()
		{

			List<Vector2> _possibleMoves = new()
			{
				{new(-1,-2) }, //Oben Links
				{new(-2,-1) },
		
				{new(1,-2) }, //Oben Rechts
				{new(2,-1) }, 
							  
				{new(1,2) }, // Unten Links
				{new(2,1) },

				{new(-1,2) }, // Unten Rechts
				{new(-2,1) },
			};

			int column = Positon.X;
			int row = Positon.Y;

			foreach (Vector2 pos in _possibleMoves)
			{
				column = Positon.X + pos.X;
				row = Positon.Y + pos.Y;

				new MoveGrid(new Vector2(column,row));
			}

		}
	}
	
}