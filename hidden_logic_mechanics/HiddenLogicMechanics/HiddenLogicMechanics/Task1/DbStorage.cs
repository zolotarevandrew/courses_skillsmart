using Npgsql;

namespace HiddenLogicMechanics.Task1;

public interface IStorage
{
    Task<int> SaveAsync( string data );
    Task<string?> RetrieveAsync( int id );
}

public class DbStorage( string connectionString ) : IStorage
{
    private readonly string _connectionString = connectionString;

    public async Task<int> SaveAsync( string data )
    {
        const string sql = "INSERT INTO storage (data) VALUES (@data) RETURNING id;";

        await using var connection = new NpgsqlConnection( _connectionString );
        await connection.OpenAsync( );

        await using var command = new NpgsqlCommand( sql, connection );
        command.Parameters.AddWithValue( "data", data );

        object? res = await command.ExecuteScalarAsync( );
        return (int)res!;
    }

    public async Task<string?> RetrieveAsync( int id )
    {
        const string sql = "SELECT data FROM storage WHERE id = @id;";

        await using NpgsqlConnection connection = new NpgsqlConnection( _connectionString );
        await connection.OpenAsync( );

        await using NpgsqlCommand command = new NpgsqlCommand( sql, connection );
        command.Parameters.AddWithValue( "id", id );

        object? result = await command.ExecuteScalarAsync();
        return result as string;
    }
}