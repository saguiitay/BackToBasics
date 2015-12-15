using System.Collections.Generic;
using System.IO;
using System.Linq;
using DataStructures.Suffix;

namespace T9
{
    public class WordsDictionary
    {
        private static readonly Dictionary<char, char> CharToNumber = new Dictionary<char, char>
            {
                {'a', '2'},
                {'b', '2'},
                {'c', '2'},
                {'d', '3'},
                {'e', '3'},
                {'f', '3'},
                {'g', '4'},
                {'h', '4'},
                {'i', '4'},
                {'j', '5'},
                {'k', '5'},
                {'l', '5'},
                {'m', '6'},
                {'n', '6'},
                {'o', '6'},
                {'p', '7'},
                {'q', '7'},
                {'r', '7'},
                {'s', '7'},
                {'t', '8'},
                {'u', '8'},
                {'v', '8'},
                {'w', '7'},
                {'x', '9'},
                {'y', '9'},
                {'z', '9'}
            };

        private readonly Suffix<List<string>> _codeToWords = new Suffix<List<string>>();

        public void Build(string dictionaryFile)
        {
            var lines = File.ReadAllLines("words.txt");
            foreach (var line in lines)
            {
                var code = GetCode(line);

                var node = _codeToWords.Insert(code);
                if (node.Value == null)
                    node.Value = new List<string>();
                node.Value.Add(line);
            }
        }

        public IEnumerable<string> GetWords(string code)
        {
            return _codeToWords.Values(code).SelectMany(n => n.Value);
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