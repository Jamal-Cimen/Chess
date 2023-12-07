using Chess.Classes.Utils;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Chess.Classes.Board
{
    public class ChessBoard
    {
        private bool isWhite = true;

        public void CreatePlayBoard(string colorWhite, string colorBlack)
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (j != 0)
                    {
                        isWhite = !isWhite;
                    }

                    CreateField(i, j, colorWhite, colorBlack);
                }
            }
        }

        private void CreateField(int row, int column, string colorWhite, string colorBlack)
        {
            Rectangle field = new();

            if (isWhite)
            {
                field.Fill = (SolidColorBrush)new BrushConverter().ConvertFromString(colorWhite);
            }
            else
            {
                field.Fill = (SolidColorBrush)new BrushConverter().ConvertFromString(colorBlack);
            }

            field.MouseUp += OnMouseUp;

            Grid.SetColumn(field, column);
            Grid.SetRow(field, row);
            MainWindow._Current.chessBoard.Children.Add(field);
        }

        private void OnMouseUp(object sender, MouseButtonEventArgs e)
        {
            Point point = e.GetPosition(MainWindow._Current.chessBoard);

			int column = (int)(point.X / MainWindow._Current.chessBoard.ColumnDefinitions[0].ActualWidth);
			int row = (int)(point.Y / MainWindow._Current.chessBoard.RowDefinitions[0].ActualHeight);

            BoardManager.boardManager.SelectedPostion = new(column, row);
		}
    }
}