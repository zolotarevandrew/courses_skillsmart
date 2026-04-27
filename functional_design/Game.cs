namespace FunctionalGame;

public static partial class Game
{
    static Random r = new Random( );
    static char[] symbols = ['A', 'B', 'C', 'D', 'E', 'F'];

    private static int DefaultSize = 8;

    public static void Draw( Board board )
    {
        Console.WriteLine( "  0 1 2 3 4 5 6 7" );
        for ( int i = 0; i < DefaultSize; i++ )
        {
            Console.Write( i + " " );
            for ( int j = 0; j < DefaultSize; j++ )
            {
                Console.Write( board.cells[i, j].Symbol + " " );
            }

            Console.WriteLine( );
        }

        Console.WriteLine( );
    }

    public static Board CloneBoard( Board board )
    {
        Board b = new Board( board.size );
        for ( int row = 0; row < board.size; row++ )
        for ( int col = 0; col < board.size; col++ )
            b.cells[row, col] = board.cells[row, col];
        return b;
    }
    
    public static BoardState ReadMove(BoardState bs) {
        Console.WriteLine(">");
        string input = Console.ReadLine()!;
        if (input == "q") 
            Environment.Exit(0);

        Board board = CloneBoard(bs.Board);
        string[] coords = input.Split(' ');
        int x = int.Parse(coords[1]);
        int y = int.Parse(coords[0]);
        int x1 = int.Parse(coords[3]);
        int y1 = int.Parse(coords[2]);
        ( board.cells[x,y], board.cells[x1,y1] ) = ( board.cells[x1,y1], board.cells[x,y] );
        BoardState bb = new BoardState(board, bs.Score);
        return bb;
    }

    public static BoardState InitializeGame( )
    {
        Board board = new Board( DefaultSize );
        for ( int row = 0; row < board.size; row++ )
        for ( int col = 0; col < board.size; col++ )
            board.cells[row, col] = new Element( symbols[r.Next( 0, symbols.Length )] );

        return new BoardState( board, 0 );
    }
}