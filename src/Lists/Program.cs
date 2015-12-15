using System;
using System.Collections.Generic;

namespace Lists
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new List<int> {1, 2, 3, 4, 5, 6, 7, 8, 9};
            Console.WriteLine(string.Join(" ", list));

            Reverse(list);
            Console.WriteLine(string.Join(" ", list));

            Shuffle(list);
            Console.WriteLine(string.Join(" ", list));
        }

        public static void Reverse<T>(List<T> list)
        {
            var start = 0;
            var end = list.Count - 1;

            while (start < end)
            {
                var temp = list[start];
                list[start] = list[end];
                list[end] = temp;

                start++;
                end--;
            }
        }

        public static void Shuffle<T>(List<T> list)
        {
            var start = 0;
            Random random = new Random();

            while (start < list.Count - 1)
            {
                var indexToReplace = random.Next(start + 1, list.Count);

                var temp = list[start];
                list[start] = list[indexToReplace];
                list[indexToReplace] = temp;

                start++;
            }
        }
    }
}
