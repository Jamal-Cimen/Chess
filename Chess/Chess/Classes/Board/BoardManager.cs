using System;
using Chess.Classes.Utils;
using Chess.Classes.Piece.Pieces;
using System.Collections.Generic;
using Chess.Classes.Piece;
using System.Windows.Controls;
using Chess.Classes.Utils.Types;

namespace Chess.Classes.Board
{
    public class BoardManager
    {
        Dictionary<char, Type> pieces = new()
        {
            { 'r', typeof(Rook) },
            { 'n', typeof(Knight) },
            { 'b', typeof(Bishop) },
            { 'q', typeof(Queen) },
            { 'k', typeof(King) },
            { 'p', typeof(Pawn) },
            { 'R', typeof(Rook) },
            { 'N', typeof(Knight) },
            { 'B', typeof(Bishop) },
            { 'Q', typeof(Queen) },
            { 'K', typeof(King) },
            { 'P', typeof(Pawn) }
        };

        public void AddPieceToBoard(char piece, Vector2 position, Colors color)
        {
            PieceBase pieceInstance = Activator.CreateInstance(pieces[piece], position, color) as PieceBase;
        }
    }
}