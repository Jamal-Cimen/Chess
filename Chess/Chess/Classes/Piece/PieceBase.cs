using System;
using Chess.Classes.Utils;
using System.Windows.Shapes;
using System.Windows.Controls;
using Chess.Classes.Utils.Types;

namespace Chess.Classes.Piece
{
    public abstract class PieceBase
    {
        protected abstract Image Create();
        public Colors Color;
        public Vector2 Positon;
        public bool canMove;
    }
}