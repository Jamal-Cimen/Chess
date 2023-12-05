using Chess.Classes.Board;
using Chess.Classes.Utils;
using Chess.Classes.Utils.Types;

namespace Chess.Classes.FEN
{
	public class FEN
    {
        private string _fen;

        public FEN(string fen)
        {
            _fen = fen;
            ReadFEN();
        }

        private void ReadFEN()
        {
            char[] piecePosition = _fen.ToCharArray();
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
						BoardManager.boardManager.AddPieceToBoard(piece, positon, GetColor(piece));
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