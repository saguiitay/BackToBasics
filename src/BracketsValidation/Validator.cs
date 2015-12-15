using System.Collections.Generic;

namespace BracketsValidation
{
    static class Validator
    {
        public static bool IsValid(string input)
        {
            List<char> openingBrackets = new List<char> {'[', '(', '{'};
            List<char> closingBrackets = new List<char> {']', ')', '}'};

            Stack<int> currentBrackets = new Stack<int>();

            foreach (var ch in input)
            {
                var o = openingBrackets.IndexOf(ch);
                if (o >= 0)
                {
                    currentBrackets.Push(o);
                    continue;
                }
                var c = closingBrackets.IndexOf(ch);
                if (c >= 0)
                {
                    if (currentBrackets.Peek() == c)
                        currentBrackets.Pop();
                    else
                    {
                        return false;
                    }
                }
            }
            return (currentBrackets.Count == 0);
        }
    }
}