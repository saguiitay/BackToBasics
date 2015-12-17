using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strings
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (var perm in PermutationsRecursive("abcdef"))
            {
                Console.WriteLine(perm);
            }
            Console.ReadLine();

        }

        static IEnumerable<string> PermutationsRecursive(string text)
        {
            if (text.Length <= 1)
            {
                yield return text;
                yield break;
            }

            for (int i = 0; i < text.Length; i++)
            {
                var chars = text.ToCharArray();
                var temp = chars[0];
                chars[0] = chars[i];
                chars[i] = temp;

                var permutations = PermutationsRecursive(string.Join("", chars.Skip(1))).ToList();
                foreach (var sub in permutations)
                    yield return chars[0] + sub;
            }
        }
    }
}
