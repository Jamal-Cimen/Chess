using System;
using Chess.Classes.Board;
using System.Collections.Generic;
using Chess;
using System.Windows.Controls;
using Chess.Classes.Utils;
using Chess.Classes.Piece.Pieces;
using System.Diagnostics;
using Chess.Classes.Utils.Types;

namespace Chess.Classes.FEN
{
    public class FEN
    {
        private string Fen;
        private BoardManager boardManager;

        public FEN(string FEN)
        {
            Fen = FEN;
            boardManager = new();
            ReadFEN();
        }

        private void ReadFEN()
        {
            char[] piecePosition = Fen.ToCharArray();
            Vector2 positon = new(0, 0);

            foreach (char piece in piecePosition)
            {
                if (piece != '/')
                {
                    int skip;

                    if (int.TryParse(piece.ToString(), out skip))
                    {
                        positon.X += skip;
                    }
                    else
                    {
                        boardManager.AddPieceToBoard(piece, positon, GetColor(piece));
                        positon.X++;
                    }
                }
                else
                {
                    positon.Y++;
                    positon.X = 0;
                }
            }
        }

        private Colors GetColor(char piece)
        {
            if (char.IsLower(piece))
            {
                return Colors.Black;
            }
            else
            {
                return Colors.white;
            }
        }
    }
}