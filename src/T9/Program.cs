using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using DataStructures.Suffix;

namespace T9
{
    class Program
    {
        private static readonly Dictionary<char, char> CharToNumber = new Dictionary<char, char>
            {
                {'a', '2' }, {'b', '2' }, {'c', '2' },
                {'d', '3' }, {'e', '3' }, {'f', '3' },
                {'g', '4' }, {'h', '4' }, {'i', '4' },
                {'j', '5' }, {'k', '5' }, {'l', '5' },
                {'m', '6' }, {'n', '6' }, {'o', '6' },
                {'p', '7' }, {'q', '7' }, {'r', '7' }, {'s', '7' },
                {'t', '8' }, {'u', '8' }, {'v', '8' },
                {'w', '7' }, {'x', '9' }, {'y', '9' }, {'z', '9' }
            };

        private static void Main(string[] args)
        {
            var codeToWords = new Suffix<List<string>>();

            var lines = File.ReadAllLines("words.txt");
            foreach (var line in lines)
            {
                var code = GetCode(line);

                var node = codeToWords.Insert(code);
                if (node.Value == null)
                    node.Value = new List<string>();
                node.Value.Add(line);
            }

            string input;

            while ((input = Console.ReadLine()) != "")
            {
                var nodes = codeToWords.Values(input).ToList();

                Console.WriteLine(string.Join(", ", nodes.SelectMany(n => n.Value)));
            }
        }

        private static string GetCode(string line)
        {
            var code = "";
            foreach (var ch in line)
            {
                char c;
                if (CharToNumber.TryGetValue(ch, out c))
                    code += c;
            }
            return code;
        }
    }
}
