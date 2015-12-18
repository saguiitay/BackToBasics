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
            var groups = GroupBySimilarPermutations(new[] {"cat", "act", "truck", "kcurt", "trkuc"});
            foreach (var @group in groups)
            {
                Console.WriteLine(string.Join(", ", @group));
            }

            foreach (var perm in PermutationsRecursive("abc"))
            {
                Console.WriteLine(perm);
            }
            Console.ReadLine();

        }

        static List<List<string>> GroupBySimilarPermutations(IEnumerable<string> words)
        {
            Dictionary<string, List<string>> groups = new Dictionary<string, List<string>>();

            foreach (var word in words)
            {
                var key = new string(word.ToLowerInvariant().ToCharArray().OrderBy(x => x).ToArray());

                List<string> list;
                if (!groups.TryGetValue(key, out list))
                {
                    list = new List<string>();
                    groups[key] = list;
                }

                list.Add(word);
            }

            return groups.Values.ToList();
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
