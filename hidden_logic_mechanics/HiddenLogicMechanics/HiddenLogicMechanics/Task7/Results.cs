using System.Runtime.CompilerServices;
using System.Threading.Channels;

namespace HiddenLogicMechanics.Task7;

internal class LogItem {}

/*
 * 1 - Publish Subscribe
 */
internal class BoundedDroppingLogBuffer
{
    private readonly Channel<LogItem> _channel;

    public BoundedDroppingLogBuffer( int capacity )
    {
        _channel = Channel.CreateBounded<LogItem>( new BoundedChannelOptions( capacity )
        {
            SingleReader = true,
            SingleWriter = false,
            FullMode = BoundedChannelFullMode.DropOldest
        } );
    }

    public void TryWrite( LogItem item )
    {
        _channel.Writer.TryWrite( item );
    }

    public async IAsyncEnumerable<object> ReadAllAsync( [EnumeratorCancellation] CancellationToken ct)
    {
        while ( await _channel.Reader.WaitToReadAsync( ct ) )
        {
            while ( _channel.Reader.TryRead( out LogItem? msg ) )
                yield return msg;
        }
    }

    public bool TryRead(out LogItem? item) => _channel.Reader.TryRead(out item);

    public void Complete( )
    {
        _channel.Writer.Complete();
    }
}


/*
 * 2 - асинхронный RateLimiter на основе Semaphore
 */
internal class RateLimiter( int maxCount ) : IDisposable
{
    private readonly SemaphoreSlim _semaphore = new ( maxCount, maxCount );

    public async Task<TResult> Limit<TResult>( Func<CancellationToken, Task<TResult>> func, CancellationToken cancellationToken )
    {
        await _semaphore.WaitAsync( cancellationToken );
        try
        {
            return await func( cancellationToken );
        }
        finally
        {
            _semaphore.Release( );
        }
    }

    public void Dispose( )
    {
        _semaphore.Dispose(  );
    }
}


/*
 * 3 - lock free Counter Metric, на основе Interlocked
 */
internal class CounterMetric
{
    private long _count = 0;

    public void Inc( )
    {
        Interlocked.Increment( ref _count );
    }

    public long GetValue( ) => Interlocked.Read( ref _count );

    public void Inc( int num )
    {
        if ( num <= 0 ) throw new InvalidOperationException( "num should be greater than zero" );
        Interlocked.Add( ref _count, num );
    }
}

/*
 * 4 - TaskScheduler
 */
public class TaskSchedulerExample
{
    public async Task Run( )
    {
        var urls = new[]
        {
            "https://example.com",
            "https://dotnet.microsoft.com",
            "https://github.com",
            "https://learn.microsoft.com"
        };
        using var cancellatinTokenSource = new CancellationTokenSource( );
        cancellatinTokenSource.CancelAfter( TimeSpan.FromSeconds( 5 ) );

        using var http = new HttpClient();
        string[] strings = await Task.WhenAll( urls.Select( u => http.GetStringAsync( u, cancellatinTokenSource.Token ) ) );
    }
}


public interface IConnectionFactory
{
    IConnection CreateConnection( );
}

public interface IConnection : IDisposable
{
    bool IsOpen { get; set; }
    void Close( ushort replyCode, string message );
}

/*
 * 5 - синхронный lock для блокировки создания подключей к очередям (Вырезал нюансы для RabbitMq)
 */
public class QueueConnection
{
    private readonly IConnectionFactory _connectionFactory;
    private readonly object _syncRoot = new object();
    private IConnection? _connection;
    private bool _isDisposed;

    public QueueConnection( IConnectionFactory connectionFactory )
    {
        _connectionFactory = connectionFactory;
    }

    public bool EnsureConnected()
    {
        CheckDisposed();

        if ( IsConnectionOpened )
        {
            return true;
        }

        lock ( _syncRoot )
        {
            if ( IsConnectionOpened )
            {
                return true;
            }

            CleanupConnection( "EnsureConnected" );
            _connection = _connectionFactory.CreateConnection();

            return IsConnectionOpened;
        }
    }

    public void Dispose()
    {
        if ( _isDisposed )
        {
            return;
        }

        _isDisposed = true;
        CleanupConnection( "Connection Dispose" );
    }

    private bool IsConnectionOpened => _connection?.IsOpen == true;

    private void CleanupConnection( string message, ushort replyCode = 200 )
    {
        if ( _connection == null )
        {
            return;
        }

        try
        {
            if ( _connection.IsOpen )
            {
                _connection.Close( replyCode, message );
            }
        }
        catch ( Exception )
        {
            // ignored
        }

        _connection.Dispose();
        _connection = null;
    }

    private void CheckDisposed()
    {
        if ( _isDisposed )
        {
            throw new ObjectDisposedException( nameof(QueueConnection) );
        }
    }
}