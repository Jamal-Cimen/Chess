using System;
using Chess.Classes.FEN;
using Chess.Classes.Board;
using Chess.Classes.Piece.Pieces;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Reflection;
using System.Diagnostics;
using System.IO;
using Chess.Classes.Utils;
using Microsoft.VisualBasic;
using Chess.Classes.Piece;

namespace Chess
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static MainWindow _Current;

        public MainWindow()
        {
            InitializeComponent();
            _Current = this;

            //Directory.SetCurrentDirectory("C:\\Users\\jamal\\Desktop\\Chess\\Chess\\");

            ChessBoard chessBoard = new();
            chessBoard.CreatePlayBoard("#ffffff", "#090820");

            FEN fen = new("4K3/8/8/5K2/8/8/6k1/7k");
        }

        private void OnMouseMove(object sender, MouseEventArgs e)
        {
            Point point = e.GetPosition(chessBoard);

            if (e.LeftButton == MouseButtonState.Pressed)
            {
                int column = (int)(point.X / chessBoard.ColumnDefinitions[0].ActualWidth);
                int row = (int)(point.Y / chessBoard.RowDefinitions[0].ActualHeight);

                Debug.WriteLine("Column: " + column);
                Debug.WriteLine("Row: " + row);

                Debug.WriteLine("Pos: " + Grid.get);
            }
        }

        private void OnResizeWindow(object sender, SizeChangedEventArgs e)
        {
            if (e.HeightChanged)
            {
                chessBoard.Width = Math.Round(e.NewSize.Height / 1.1);
                chessBoard.Height = Math.Round(e.NewSize.Height / 1.1);
            }

            if (WindowState == WindowState.Maximized || WindowState == WindowState.Normal)
            {
                chessBoard.Width = Math.Round(e.NewSize.Height / 1.1);
                chessBoard.Height = Math.Round(e.NewSize.Height / 1.1);
            }
        }
    }
}
