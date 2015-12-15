using System;

namespace T9
{
    class Program
    {
        private static void Main(string[] args)
        {
            WordsDictionary dictionary = new WordsDictionary();
            dictionary.Build("words.txt");
           
            string input;

            while ((input = Console.ReadLine()) != "")
            {
                Console.WriteLine(string.Join(", ", dictionary.GetWords(input)));
            }
        }

        
    }
}
