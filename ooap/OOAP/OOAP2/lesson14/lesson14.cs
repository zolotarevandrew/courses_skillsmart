using System.Collections.Generic;
using System.Numerics;

namespace OOAP2.lesson14
{
    public class General {}

    //IAdditionOperators<IInt,IInt,IInt> .net 7 new interface, it has static operator method, static abstract TResult operator +(TSelf left, TOther right);

    public class Vector<T> : General, IAdditionOperators<Vector<T>,Vector<T>,Vector<T>> 
        where T : IAdditionOperators<T, T, T>
    {
        private readonly List<T> _source;

        public Vector(List<T> from)
        {
            _source = from;
        }

        public static Vector<T> operator +(Vector<T> left, Vector<T> right)
        {
            if (left._source.Count != right._source.Count) return null;

            var lst = new List<T>();
            for (int idx = 0; idx < left._source.Count; idx++)
            {
                var item1 = left._source[idx];
                var item2 = left._source[idx];
                lst.Add(item1 + item2);
            }
            return new Vector<T>(lst);
        }
    }
    
    public static class Lesson14Program
    {
        public static void Main(string[] args)
        {
            var g1 = 1;
            var g2 = 2;

            //3
            var g3 = g1 + g2;

            var vector1 = new Vector<int>(new List<int>
            {
                g1, g2
            });
            var vector2 = new Vector<int>(new List<int>
            {
                g1, g2
            });

            //2, 4
            var vector3 = vector1 + vector2;

            var vVector1 = new Vector<Vector<int>>(new List<Vector<int>>
            {
                vector1,
                vector2
            });
            var vVector2 = new Vector<Vector<int>>(new List<Vector<int>>
            {
                vector1,
                vector2
            });

            //2,4 , 2,4
            var vVector = vVector1 + vVector2;
            
        }
    } 
}