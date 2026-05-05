"Какую более мощную абстракцию для представления комбинаций с возможными последствиями вы бы применили"

Попробовал сделать нечто декларативное и отделить исполнение от описания процесса, почитав про FreeMonad.
Теперь каждое правило описывается маской и декларативным пайпом эффектов.
При этом отдельные реализации интерпретаторов могут обрабатывать эффекты (последствия) по-разному.

```c#
// правило матчинга.
public record MatchRule( string Name, MatchMask Mask, MatchEffectPipe EffectPipe );


public record MatchEffect( );

public readonly record struct Bonus( uint Value );

// добавляем бонусы
public record AddBonusEffect( Bonus Bonus ) : MatchEffect;

// применяем гравитацию
public record ApplyGravityEffect( ) : MatchEffect;

// очищаем ячейки
public record RemoveCellsEffect( MatchGroup Group ) : MatchEffect;

// цементируем ячейки, и не даем двигать, допустим на несколько секунд
public record CementCellsEffect( MatchGroup Group, TimeSpan Delay ) : MatchEffect;

// отделяем интерпретацию эффекта
public abstract class MatchEffectInterpreter
{
    public abstract BoardState Interpret<TEffect>( BoardState state, MatchGroup group, TEffect effect ) where TEffect : MatchEffect;
}

public class SimpleMatchEffectInterpreter : MatchEffectInterpreter
{
    private readonly Dictionary<Type, Func<BoardState, MatchGroup, MatchEffect, BoardState>> _effects;

    public SimpleMatchEffectInterpreter( 
        Dictionary<Type, Func<BoardState, MatchGroup, MatchEffect, BoardState>> effects )
    {
        _effects = effects;
    }

    public override BoardState Interpret<TEffect>( BoardState state, MatchGroup group, TEffect effect )
    {
        return !_effects.TryGetValue( typeof(TEffect), out Func<BoardState, MatchGroup, MatchEffect, BoardState>? func )
            ? throw new InvalidOperationException( "No effect handler was found" )
            : func( state, group, effect );
    }
}

// декларативный отложенный пайп эффектов
public record MatchEffectPipe
{
    private readonly List<Func<BoardState, MatchGroup, MatchEffectInterpreter, BoardState>> _pipe;
    private MatchEffectPipe( List<Func<BoardState, MatchGroup, MatchEffectInterpreter, BoardState>> pipe )
    {
        _pipe = pipe;
    }

    public static MatchEffectPipe Empty( )
    {
        return new MatchEffectPipe( [] );
    }

    public BoardState Interpret( BoardState state, MatchGroup group, MatchEffectInterpreter interpreter )
    {
        return _pipe.Aggregate( state, ( current, item ) => item( current, group, interpreter ) );
    }

    public MatchEffectPipe Apply<TEffect>( Func<BoardState, MatchGroup, Option<TEffect>> func )
        where TEffect : MatchEffect
    {
        Func<BoardState, MatchGroup, MatchEffectInterpreter, BoardState> next = ( s, m, i ) =>
        {
            Option<TEffect> effect = func( s, m );
            return effect.HasValue
                ? i.Interpret( s, m, effect.Get( ) )
                : s;
        };
        return new MatchEffectPipe( _pipe.Concat( [next] ).ToList(  ) );
    }
}

// эффект матчинга над доской 

// маска матчинга - описывает тип и подматрицу для поиска
public record struct MatchMask( bool[,] Positions );

// группа матчей, с возможными последствиями (эффектами)
public record MatchGroup
{
    private List<MatchResult> _list = [];

    public static MatchGroup Empty = new MatchGroup( [] );
    
    public MatchGroup( IReadOnlyList<MatchResult> results )
    {
        _list.AddRange( results );
    }
    
    public int Count => _list.Count;

    public MatchGroup Combine( MatchGroup group )
    {
        return new MatchGroup( _list
            .Concat( group._list )
            .ToList( ) );
    }

    public void Add( MatchResult result )
    {
        _list.Add( result );
    }
} 

// делаем структурой, чтобы хранилось прямо в самом массиве, в памяти.
public struct MatchResult( IReadOnlyList<MatchPosition> Positions );

// позиция части матча
public struct MatchPosition( int Row, int Col );

public static class MatchRules 
{
    public static class Horizontal
    {
        private static MatchEffectPipe Pipe = MatchEffectPipe.Empty( )
            .Apply( ( state, matchGroup ) =>
            {
                Bonus bonus = new Bonus( 10 );
                return Option<Bonus>
                    .Create( bonus, b => b.Value < 100 )
                    .Map( b => new AddBonusEffect( b ) );
            } )
            .Apply( ( state, matchGroup ) =>
                Option<CementCellsEffect>.Some( new CementCellsEffect( matchGroup, TimeSpan.FromSeconds( 5 ) ) ) )
            .Apply( ( state, matchGroup ) => Option<RemoveCellsEffect>.Some( new RemoveCellsEffect( matchGroup ) ) )
            .Apply( ( state, matchGroup ) => Option<ApplyGravityEffect>.Some( new ApplyGravityEffect( ) ) );

        public static MatchRule Value = new MatchRule(
            nameof(Horizontal),
            new MatchMask( new[,]
            {
                { true, true, true }
            } ),
            Pipe
        );
    }

    internal static MatchGroup FindMatches( BoardState state, MatchRule rule )
    {
        MatchGroup result = MatchGroup.Empty;
        int size = state.Board.size;
        for ( int row = 0; row < size; row++ )
        {
            for ( int col = 0; col < size; col++ )
            {
                Option<MatchResult> matchResult = TrySearch( state.Board, rule.Mask, row, col );
                if ( !matchResult.HasValue )
                {
                    continue;
                }

                result.Add( matchResult.Get( ) );
            }
        }

        return result;
    }

    
    private static Option<MatchResult> TrySearch(
        Board board,
        MatchMask mask,
        int row,
        int col )
    {
        int maskRows = mask.Positions.GetLength( 0 );
        int maskCols = mask.Positions.GetLength( 1 );

        char? prev = null;

        List<MatchPosition> positions = [];
        for ( int maskRow = 0; maskRow < maskRows; maskRow++ )
        {
            for ( int maskCol = 0; maskCol < maskCols; maskCol++ )
            {
                // 1 1 1
                // 1 0 0
                // 1 0 0

                bool maskItem = mask.Positions[maskRow, maskCol];
                
                // пропускаем нулевые символы
                if ( !maskItem )
                {
                    continue;
                }

                int searchRow = row + maskRow;
                int searchCol = col + maskCol;
                bool isValidSearch = searchRow >= 0 && searchRow < board.size
                                                    && searchCol >= 0 && searchCol < board.size;

                // Вышли за границу, значит все, матч не пройдет
                if ( !isValidSearch )
                {
                    return Option<MatchResult>.None(  );
                }

                char symbol = board.cells[searchRow, searchCol].Symbol;
                
                // Встретили хотя бы один пустой символ
                if ( symbol == Element.EMPTY )
                {
                    return Option<MatchResult>.None(  );
                }
                
                prev ??= symbol;

                // если встретили, несовпадение, выходим
                if ( prev != symbol )
                {
                    return Option<MatchResult>.None(  );
                }

                positions.Add( new MatchPosition( searchRow, searchCol ) );
            }
        }

        return positions.Count == 0
            ? Option<MatchResult>.None( )
            : Option<MatchResult>.Some( new MatchResult( positions ) );
    }
}

public static BoardState ProcessCascadeV4( BoardState boardState )
{
    MatchRule rule = MatchRules.Horizontal.Value;
    SimpleMatchEffectInterpreter interpreter = new SimpleMatchEffectInterpreter( [] );
    MatchGroup matchGroup = MatchRules.FindMatches( boardState, rule );
    return matchGroup.Count == 0
        ? boardState
        : rule.EffectPipe
            .Interpret( boardState, matchGroup, interpreter )
            .Pipe( ProcessCascadeV4 );
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

    public T Get( )
    {
        return HasValue ? source! : throw new InvalidOperationException( );
    }

    public T GetOrElse( T fallback )
    {
        return HasValue ? source! : fallback;
    }
}
```


