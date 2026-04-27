namespace FunctionalGame;

public struct BoardState( Board board, int score )
{
    public readonly Board Board = board;
    public readonly int Score = score;
}