namespace Tasks.GraphAlgorithms.TopologicalSorting;

public class TopologicalSorting
{
    public class Graph
    {
        public Dictionary<Vertex, List<Vertex>> Value { get; set; }

        public List<Vertex> Get( Vertex vertex )
        {
            return Value.TryGetValue( vertex, out List<Vertex>? value ) ? value : [ ];
        }
    }

    public record Vertex( int Value );
    
    public static List<Vertex> KahnSort( Graph graph )
    {
        Dictionary<Vertex, int> indegrees = [];
        foreach ( var vertex in graph.Value.Keys )
        {
            indegrees[vertex] = 0;
        }

        foreach ( var vertex in graph.Value.Keys )
        {
            foreach ( Vertex neighbour in graph.Value[vertex])
            {
                indegrees[neighbour]++;
            }
        }
        
        Queue<Vertex> queue = [];
        foreach ( var vertex in graph.Value.Keys )
        {
            if ( indegrees[vertex] == 0 )
            {
                queue.Enqueue( vertex );
            }
        }

        List<Vertex> result = [];
        while ( queue.TryDequeue( out var currentVertex ) )
        {
            result.Add( currentVertex );
            foreach ( Vertex neighbour in graph.Value[currentVertex])
            {
                indegrees[neighbour]--;
                if ( indegrees[neighbour] == 0 )
                {
                    queue.Enqueue( neighbour );
                }
            }
        }

        return result.Count != graph.Value.Keys.Count 
            ? throw new InvalidOperationException( "Graph contains cycle!" ) 
            : result;
    }

    public static List<Vertex> DfsSort( Graph graph )
    {
        Stack<Vertex> stack = [];
        HashSet<Vertex> visited = [];
        foreach ( Vertex vertex in graph.Value.Keys )
        {
            if ( !visited.Contains( vertex ) )
            {
                Dfs( vertex, visited, stack, graph );
            }
        }
        return stack
            .ToList(  );
    }

    static void Dfs( Vertex current, HashSet<Vertex> visited, Stack<Vertex> stack, Graph graph )
    {
        visited.Add( current );

        foreach ( var neighbour in graph.Get( current ) )
        {
            if ( visited.Contains( neighbour ) ) continue;
            Dfs( neighbour, visited, stack, graph );
        }

        stack.Push( current );
    }
    
}