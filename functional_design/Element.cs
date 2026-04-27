namespace FunctionalGame;

/// <summary>
/// Symbol хранит один из шести символов A..F, а пустой элемент будем обозначать символом 0.
/// </summary>
/// <param name="c"></param>
public struct Element( char c )
{
    public const char EMPTY = '0';
    public char Symbol = c;
}