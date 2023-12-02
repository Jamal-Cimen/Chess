using System.Windows.Controls;
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
            Rectangle rect = new();

            if (isWhite)
            {
                rect.Fill = (SolidColorBrush)new BrushConverter().ConvertFromString(colorWhite);
            }
            else
            {
                rect.Fill = (SolidColorBrush)new BrushConverter().ConvertFromString(colorBlack);
            }

            Grid.SetColumn(rect, column);
            Grid.SetRow(rect, row);
            MainWindow._Current.chessBoard.Children.Add(rect);
        }
    }
}