using System.Diagnostics;
using Chess.Classes.Utils;
using System;
using System.IO;
using System.Windows.Media.Imaging;
using Chess.Classes.Piece;
using System.Windows.Controls;
using System.Windows.Automation;
using Chess.Classes.Utils.Types;

namespace Chess.Classes.Piece.Pieces
{
    public class King : PieceBase
    {
        public King(Vector2 positon, Colors color)
        {
            Positon = positon;
            Color = color;

            Create();
        }

        protected override Image Create()
        {
            Image image = new();

            if (Color == Colors.white)
                image.Source = new BitmapImage(new Uri(@"Mats\king.png", UriKind.RelativeOrAbsolute));
            else
                image.Source = new BitmapImage(new Uri(@"Mats\b_king.png", UriKind.RelativeOrAbsolute));

            Grid.SetRow(image, Positon.Y);
            Grid.SetColumn(image, Positon.X);

            MainWindow._Current.chessBoard.Children.Add(image);

            return image;
        }
    }
}