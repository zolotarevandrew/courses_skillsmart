using System.Text;

namespace Tasks.Strings.GroupAnagrams;

public class GroupAnagram
{
    /*
     * Given an array of strings, group all anagrams together.
     * Return a list of groups, where each group contains strings that are anagrams of each other.
     * Strings in each group can be in any order
     * 
     */
    public static List<List<string>> Run(List<string> strings)
    {
        var dict = new Dictionary<int[], List<string>>(new IntArrayComparer());

        foreach (var s in strings)
        {
            var counts = new int[26]; 
            foreach (var ch in s)
            {
                var c = ch;
                if (c is >= 'A' and <= 'Z') c = (char)(c + 32);   // to lower fast
                int idx = c - 'a';
                if ((uint)idx < 26u) counts[idx]++;
            }

            if (!dict.TryGetValue(counts, out var group))
                dict[counts] = group = new List<string>();

            group.Add(s);
        }

        return dict.Values.ToList();
    }
    
    class IntArrayComparer : IEqualityComparer<int[]>
    {
        public bool Equals(int[]? x, int[]? y)
        {
            if (ReferenceEquals(x, y)) return true;
            if (x is null || y is null || x.Length != y.Length) return false;
            return !x
                .Where( ( t, i ) => t != y[i] )
                .Any( );
        }

        public int GetHashCode(int[] obj)
        {
            HashCode hc = new HashCode();
            foreach ( int t in obj )
                hc.Add(t);

            return hc.ToHashCode();
        }
    }
}