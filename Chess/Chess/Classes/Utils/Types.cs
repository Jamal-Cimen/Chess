namespace Chess.Classes.Utils.Types
{
    public enum PieceTypes
    {
        King = 'k',
        Queen = 'q',
        Rook = 'r',
        Bishop = 'b',
        Knight = 'n',
        Pawn = 'p',
        B_King = 'K',
        B_Queen = 'Q',
        B_Rook = 'R',
        B_Bishop = 'B',
        B_Knight = 'N',
        B_Pawn = 'P',s
    }

    public enum Colors
    {
        Black,
        white
    }

    public enum FieldStates
    {
        Empty,
        Full
    }

    public enum MoveTypes
    {
        Linear,
        Diagonal,
        King,
        Queen,
        Rook
    }
}