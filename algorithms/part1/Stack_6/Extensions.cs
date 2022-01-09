using AlgorithmsDataStructures;

namespace Stack_6
{
    public static class Extensions
    {
        
        public static bool IsBracketBalanced(this string str)
        { 
            char OpenBrace = '(';
            char CloseBrace = ')';

            var stack = new Stack<char>();
            for (int idx = 0; idx < str.Length; idx++)
            {
                var chr = str[idx];
                if (chr != OpenBrace && chr != CloseBrace) return false;
                if (chr == OpenBrace)
                {
                    stack.Push(OpenBrace);
                }
                if (chr == CloseBrace)
                {
                    stack.Push(CloseBrace);
                    if (stack.Size() > 0)
                    {
                        stack.Pop();
                        stack.Pop();
                    }
                }
            }

            return str.Length > 0 && stack.Size() == 0;
        }
    }
}