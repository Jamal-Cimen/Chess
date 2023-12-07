using System;
using Chess.Classes.Utils;
using System.Windows.Input;
using System.Windows.Shapes;
using System.Windows.Controls;
using System.Data.Common;

namespace Chess.Classes.Board
{
	public class MoveGrid
	{
		public Vector2 Direction { get; set; }

		public MoveGrid(Vector2 direction)
		{
			Direction = direction;

			ShowLegalMoves();
		}

		private void ShowLegalMoves()
		{
			if (Direction.Y is > -1 and < 8 && Direction.X is > -1 and < 8)
			{
				Rectangle rect = new();

				rect.Fill = System.Windows.Media.Brushes.Green;
				rect.Opacity = 0.3;

				Grid.SetColumn(rect, Direction.X);
				Grid.SetRow(rect, Direction.Y);

				MainWindow._Current.chessBoard.Children.Add(rect);
			}
		}
	}
}
