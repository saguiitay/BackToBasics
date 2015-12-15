using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BracketsValidation
{
    class Program
    {
        static void Main(string[] args)
        {
            List<char> openingBrackets = new List<char> { '[', '(', '{'};
            List<char> closingBrackets = new List<char> { ']', ')', '}'};

            Stack<int> currentBrackets = new Stack<int>();

            var input = "{(1+1)*2}/[3-1)]";
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
                        Console.WriteLine("Invalid input");
                        return;
                    }
                }
            }
            if (currentBrackets.Count > 0)
                Console.WriteLine("Invalid input");
            else
                Console.WriteLine("Valid input");
        }
    }
}
