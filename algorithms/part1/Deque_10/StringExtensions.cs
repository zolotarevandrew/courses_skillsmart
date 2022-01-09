namespace AlgorithmsDataStructures
{
    public static class StringExtensions
    {
        public static bool IsPalindrome(this string str)
        {
            if (string.IsNullOrEmpty(str)) return false;

            var deque = new Deque<char>();
            foreach (var item in str) deque.AddTail(item);
            
            while (deque.Size() > 1)
            {
                if (deque.RemoveTail() != deque.RemoveFront()) return false;
            }

            return true;
        }
    }
}