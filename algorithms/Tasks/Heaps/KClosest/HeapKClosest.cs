namespace Tasks.Heaps.KClosest;

public record struct HeapPoint( int X, int Y );

public class HeapKClosest
{
    /*
     * Given the list of coordinates where points[i] = [xi,yi]
     * represents a point on the X-Y plane, and an integer k,
     * Find the k closest point to the origin (0,0).
     *
     * The closeness of a point is determined by its Euclidean distance from the origin
     * distance = sqrt(x^2 + y^2)
     * Return the answer in any order. The answer is unique except for the order of elements.
     */
    public static List<HeapPoint> Run( HeapPoint[] points, int k )
    {
        if ( points.Length == 0 || k <= 0 || k >= points.Length ) return [];

        PriorityQueue<HeapPoint, double> heap = new PriorityQueue<HeapPoint, double>( points.Length );
        for ( int i = 0; i < points.Length; i++ )
        {
            HeapPoint point = points[i];
            double distance = CalcDistance( point );
            heap.Enqueue( point, distance );
        }

        List<HeapPoint> res = [];
        for ( int i = 0; i < k; i++ )
        {
            HeapPoint min = heap.Dequeue( );
            res.Add( min );
        }

        return res;
    }

    private static double CalcDistance( HeapPoint point )
    {
        return point.X * point.X + point.Y * point.Y;
    }
}