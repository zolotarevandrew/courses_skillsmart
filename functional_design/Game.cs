

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

    public static BoardState InitializeGame( int boardSize = 8 )
    {
        return ProcessCascade( FillEmptySpaces( new BoardState( new Board( boardSize ), 0 ) ) );
    }

    public struct Option<T>
    {
        private readonly T? source;
        public bool HasValue { get; }
        
        private Option( T? source, bool hasValue )
        {
            this.source = source;
            HasValue = hasValue;
        }
        
        public static Option<T> Some( T source )
        {
            return new Option<T>( source, true );
        }

        public static Option<T> None( )
        {
            return new Option<T>( default, false );
        }

        public static Option<T> Create( T source, Func<T, bool> predicate )
        {
            return predicate( source ) ? Some( source ) : None( );
        }

        public Option<TOut> Map<TOut>( Func<T, TOut> func )
        {
            return HasValue ? Option<TOut>.Some( func( source! ) ) : Option<TOut>.None( );
        }

        public T GetOrElse( T fallback )
        {
            return HasValue ? source! : fallback;
        }
    }

    public static BoardState ProcessCascade( BoardState boardState )
    {
        (BoardState State, List<Match> Matches) foundMatches = FindMatches( boardState );
        return Option<(BoardState State, List<Match> Matches)>
            .Create( foundMatches, matches => matches.Matches.Count > 0 )
            .Map( RemoveMatches )
            .Map( FillEmptySpaces )
            .Map( ProcessCascade )
            .GetOrElse( foundMatches.State );
    }
    
    public static BoardState ProcessCascadeV2( BoardState boardState )
    {
        (BoardState State, List<Match> Matches) foundMatches = FindMatches( boardState );
        if ( foundMatches.Matches.Count == 0 ) return foundMatches.State;
        return foundMatches
            .Pipe( RemoveMatches )
            .Pipe( FillEmptySpaces )
            .Pipe( ProcessCascade );
    }
    
    public static BoardState ProcessCascadeV3( BoardState boardState )
    {
        (BoardState State, List<Match> Matches) foundMatches = FindMatches( boardState );
        return foundMatches.Matches.Count == 0 
            ? foundMatches.State 
            : ApplyCascadeStep( foundMatches );
    }
    
    private static BoardState ApplyCascadeStep( (BoardState State, List<Match> Matches) foundMatches )
    {
        return foundMatches
            .Pipe( RemoveMatches )
            .Pipe( FillEmptySpaces )
            .Pipe( ProcessCascade );
    }
    
    
    public static BoardState FillEmptySpaces(BoardState currentState)
    {
        if ( currentState.Board.cells == null )
            return currentState;

        Element[,] newCells = (Element[,])currentState.Board.cells.Clone();

        for (int row = 0; row < currentState.Board.size; row++)
        {
            for (int col = 0; col < currentState.Board.size; col++)
            {
                if (newCells[row, col].Symbol == Element.EMPTY)
                {
                    newCells[row, col] = new Element
                    {
                        Symbol = symbols[r.Next(symbols.Length)]
                    };
                }
            }
        }

        return new BoardState(
            new Board { size = currentState.Board.size, cells = newCells },
            currentState.Score
        );
    }
    
    public static (BoardState State, List<Match> Matches) FindMatches( BoardState boardState )
    {
        List<Match> matches = [];
        Board board = boardState.Board;

        // Горизонтальные комбинации
        for ( int row = 0; row < board.size; row++ )
        {
            int startCol = 0;
            for ( int col = 1; col < board.size; col++ )
            {
                // Пропускаем пустые ячейки в начале строки
                if ( board.cells[row, startCol].Symbol == Element.EMPTY )
                {
                    startCol = col;
                    continue;
                }

                // Если текущая ячейка пустая, обрываем текущую последовательность
                if ( board.cells[row, col].Symbol == Element.EMPTY )
                {
                    AddMatchIfValid( matches, row, startCol, col - startCol, MatchDirection.Horizontal );
                    startCol = col + 1;
                    continue;
                }

                // Проверяем совпадение символов для непустых ячеек
                if ( board.cells[row, col].Symbol != board.cells[row, startCol].Symbol )
                {
                    AddMatchIfValid( matches, row, startCol, col - startCol, MatchDirection.Horizontal );
                    startCol = col;
                    continue;
                }

                if ( col == board.size - 1 )
                {
                    AddMatchIfValid( matches, row, startCol, col - startCol + 1, MatchDirection.Horizontal );
                }
            }
        }

        // Вертикальные комбинации
        for ( int col = 0; col < board.size; col++ )
        {
            int startRow = 0;
            for ( int row = 1; row < board.size; row++ )
            {
                // Пропускаем пустые ячейки в начале столбца
                if ( board.cells[startRow, col].Symbol == Element.EMPTY )
                {
                    startRow = row;
                    continue;
                }

                // Если текущая ячейка пустая, обрываем текущую последовательность
                if ( board.cells[row, col].Symbol == Element.EMPTY )
                {
                    AddMatchIfValid( matches, startRow, col, row - startRow, MatchDirection.Vertical );
                    startRow = row + 1;
                    continue;
                }

                // Проверяем совпадение символов для непустых ячеек
                if ( board.cells[row, col].Symbol != board.cells[startRow, col].Symbol )
                {
                    AddMatchIfValid( matches, startRow, col, row - startRow, MatchDirection.Vertical );
                    startRow = row;
                }
                else if ( row == board.size - 1 )
                {
                    AddMatchIfValid( matches, startRow, col, row - startRow + 1, MatchDirection.Vertical );
                }
            }
        }

        return ( boardState, matches );
    }
    
    public static BoardState RemoveMatches((BoardState State, List<Match> Matches) source)
    {
        ( BoardState currentState, List<Match> matches ) = source;
        if ( matches == null || matches.Count == 0 )
            return currentState;

        // Шаг 1: Помечаем ячейки для удаления 
        Element[,] markedCells = MarkCellsForRemoval(currentState.Board, matches);

        // Шаг 2: Применяем гравитацию
        Element[,] gravityAppliedCells = ApplyGravity(markedCells, currentState.Board.size);

        // Шаг 3: Подсчитываем очки
        int removedCount = matches.Sum(m => m.Length);
        int newScore = currentState.Score + CalculateScore(removedCount);

        // Возвращаем НОВОЕ состояние
        return new BoardState(
            currentState.Board with { cells = gravityAppliedCells },
            newScore
        );
    }
    
    private static Element[,] MarkCellsForRemoval(Board board, List<Match> matches)
    {
        Element[,] newCells = (Element[,])board.cells.Clone();

        foreach (var match in matches)
        {
            for (int i = 0; i < match.Length; i++)
            {
                int row = match.Direction == MatchDirection.Horizontal ? match.Row : match.Row + i;
                int col = match.Direction == MatchDirection.Horizontal ? match.Col + i : match.Col;

                newCells[row, col] = new Element { Symbol = Element.EMPTY };
            }
        }

        return newCells;
    }
    
    private static Element[,] ApplyGravity(Element[,] cells, int size)
    {
        Element[,] newCells = new Element[size, size];

        for (int row = 0; row < size; row++)
        {
            for (int col = 0; col < size; col++)
            {
                newCells[row, col] = new Element { Symbol = Element.EMPTY };
            }
        }

        for (int col = 0; col < size; col++)
        {
            int newRow = size - 1;
            for (int row = size - 1; row >= 0; row--)
            {
                if (cells[row, col].Symbol != Element.EMPTY)
                {
                    newCells[newRow, col] = cells[row, col];
                    newRow--;
                }
            }
        }

        return newCells;
    }
    
    private static int CalculateScore(int removedCount)
    {
        // Базовая система подсчета очков: 10 за каждый элемент
        return removedCount * 10;
    }

    private static void AddMatchIfValid( List<Match> matches, int row, int col,
        int length, MatchDirection direction )
    {
        // Учитываем только комбинации из 3 и более элементов (ТЗ)
        if ( length >= 3 )
        {
            matches.Add( new Match( direction, row, col, length ) );
        }
    }
}

public static class FuncExtensions
{
    public static TOut Pipe<TIn, TOut>( this TIn source, Func<TIn, TOut> func )
    {
        return func( source );
    }
}